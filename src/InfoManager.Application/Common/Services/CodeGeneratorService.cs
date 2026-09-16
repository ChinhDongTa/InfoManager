namespace InfoManager.Application.Common.Services;

public class CodeGeneratorService(IApplicationDbContext context) : ICodeGeneratorService
{
    public async Task<string> PlantingCodeGenerator(string fieldId, string cropId, DateTimeOffset plantingDate, CancellationToken cancellationToken = default)
    {
        var field = await context.Fields
           .AsNoTracking()
           .FirstAsync(x => x.Id == fieldId, cancellationToken);

        var crop = await context.Crops
            .AsNoTracking()
            .FirstAsync(x => x.Id == cropId, cancellationToken);

        var datePart = plantingDate.ToString("yyyyMMdd");
        var fieldPart = StringHelpers.SanitizeName(field.Name);
        var cropPart = StringHelpers.SanitizeName(crop.CommonName);
        var prefix = $"{datePart}-{fieldPart}-{cropPart}";

        var existedCount = await context.CropPlantings
            .AsNoTracking()
            .CountAsync(x => x.PlantingCode == prefix
                          || x.PlantingCode.StartsWith(prefix + "-"),
                        cancellationToken);

        return existedCount == 0
            ? prefix
            : $"{prefix}-{(existedCount + 1):00}";
    }
}