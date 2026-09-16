namespace InfoManager.Application.Common.Interfaces;

public interface IInventoryAlertService
{
    Task RefreshAsync(string farmInventoryId, CancellationToken ct = default);

    Task RefreshFarmAsync(string farmId, CancellationToken ct = default);
}