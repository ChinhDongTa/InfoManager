namespace InfoManager.Application.Common.Services;

public class InventoryAlertService : IInventoryAlertService
{
    private readonly IApplicationDbContext _db;
    private readonly TimeProvider _clock;

    public InventoryAlertService(IApplicationDbContext db, TimeProvider clock)
    {
        _db = db;
        _clock = clock;
    }

    public async Task RefreshAsync(string farmInventoryId, CancellationToken ct = default)
    {
        var item = await _db.FarmInventories
            .Include(x => x.Fertilizer)
            .Include(x => x.Pesticide)
            .FirstOrDefaultAsync(x => x.Id == farmInventoryId, ct);

        if (item is null) return;

        var setting = await _db.InventoryAlertSettings
            .FirstOrDefaultAsync(x => x.FarmId == item.FarmId, ct);

        await SyncItemAlertsAsync(item, setting, saveChanges: true, ct);
    }

    public async Task RefreshFarmAsync(string farmId, CancellationToken ct = default)
    {
        var setting = await _db.InventoryAlertSettings
            .FirstOrDefaultAsync(x => x.FarmId == farmId, ct);

        var items = await _db.FarmInventories
            .Include(x => x.Fertilizer)
            .Include(x => x.Pesticide)
            .Where(x => x.FarmId == farmId)
            .ToListAsync(ct);

        foreach (var item in items)
            await SyncItemAlertsAsync(item, setting, saveChanges: false, ct);

        await _db.SaveChangesAsync(ct);
    }

    private async Task SyncItemAlertsAsync(
        FarmInventory item,
        InventoryAlertSetting? setting,
        bool saveChanges,
        CancellationToken ct)
    {
        var now = _clock.GetUtcNow();
        var today = DateOnly.FromDateTime(now.UtcDateTime);
        var itemName = ResolveItemName(item);

        var openAlerts = await _db.InventoryAlerts
            .Where(x => x.FarmInventoryId == item.Id && !x.IsResolved)
            .ToListAsync(ct);

        var needed = item.IsActive
            ? BuildNeededAlerts(item, itemName, setting, today)
            : [];

        foreach (var alert in openAlerts)
        {
            if (needed.Any(x => x.Type == alert.AlertType))
                continue;

            alert.IsResolved = true;
            alert.ResolvedTime = now;
            alert.ResolutionNotes = item.IsActive
                ? "Tự đóng vì không còn thỏa điều kiện."
                : "Tự đóng vì vật tư ngưng sử dụng.";
        }

        foreach (var row in needed)
        {
            if (openAlerts.Any(x => x.AlertType == row.Type))
                continue;

            _db.InventoryAlerts.Add(new InventoryAlert
            {
                FarmId = item.FarmId,
                FarmInventoryId = item.Id,
                FertilizerId = item.FertilizerId,
                PesticideId = item.PesticideId,
                CropVarietyId = item.CropVarietyId,
                ItemType = MapItemType(item.ResourceType),
                ItemName = itemName,
                AlertType = row.Type,
                Severity = row.Severity,
                CurrentQuantity = item.CurrentQuantity,
                MinQuantity = item.MinQuantity,
                ExpiryDate = item.ExpiryDate,
                Message = row.Message,
                AlertTime = now,
                IsResolved = false
            });
        }

        if (saveChanges)
            await _db.SaveChangesAsync(ct);
    }

    private static List<(InventoryAlertType Type, AlertSeverity Severity, string Message)> BuildNeededAlerts(FarmInventory item,
                                                                                                             string itemName,
                                                                                                             InventoryAlertSetting? setting,
                                                                                                             DateOnly today)
    {
        var result = new List<(InventoryAlertType, AlertSeverity, string)>();

        var enableLow = setting?.EnableLowStockAlert ?? true;
        var enableOut = setting?.EnableOutOfStockAlert ?? true;
        var enableExpiry = setting?.EnableExpiryAlert ?? true;
        var expiringDays = setting?.ExpiringSoonDays ?? 30;

        if (enableOut && item.CurrentQuantity <= 0)
        {
            result.Add((
                InventoryAlertType.OutOfStock,
                AlertSeverity.Critical,
                $"{itemName} đã hết hàng."));
        }
        else if (enableLow && item.MinQuantity is decimal min && item.CurrentQuantity <= min)
        {
            result.Add((
                InventoryAlertType.LowStock,
                AlertSeverity.Info,
                $"{itemName} còn {item.CurrentQuantity} {item.Unit}, dưới mức tối thiểu {min}."));
        }

        var expiry = item.ExpiryDate;
        if (enableExpiry && expiry.HasValue)
        {
            if (expiry.Value < today)
            {
                result.Add((
                    InventoryAlertType.Expired,
                    AlertSeverity.Critical,
                    $"{itemName} đã hết hạn từ {expiry:dd/MM/yyyy}."));
            }
            else if (expiry.Value <= today.AddDays(expiringDays))
            {
                var days = expiry.Value.DayNumber - today.DayNumber;
                result.Add((
                    InventoryAlertType.ExpiringSoon,
                    AlertSeverity.Info,
                    $"{itemName} còn {days} ngày nữa hết hạn ({expiry:dd/MM/yyyy})."));
            }
        }

        return result;
    }

    private static string ResolveItemName(FarmInventory item)
        => item.Pesticide?.Name
        ?? item.Fertilizer?.Name
        ?? item.ResourceName;

    private static InventoryItemType MapItemType(ResourceType type) => type switch
    {
        ResourceType.Fertilizer => InventoryItemType.Fertilizer,
        ResourceType.Pesticide => InventoryItemType.Pesticide,
        ResourceType.Seed => InventoryItemType.Seed,
        ResourceType.Fuel => InventoryItemType.Fuel,
        _ => InventoryItemType.Other
    };
}