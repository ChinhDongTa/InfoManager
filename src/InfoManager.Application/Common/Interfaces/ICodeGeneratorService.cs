namespace InfoManager.Application.Common.Interfaces;

public interface ICodeGeneratorService
{
    Task<string> PlantingCodeGenerator(string fieldId, string cropId, DateTimeOffset plantingDate, CancellationToken ct = default);
}