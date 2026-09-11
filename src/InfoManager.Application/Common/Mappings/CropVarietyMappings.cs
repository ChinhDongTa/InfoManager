using InfoManager.Application.Features.SFMS.Agricultural.Commands;
using InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;
public static class CropVarietyMappings
{
    public static CreateCropVarietyCommand ToCreateCommand(CreateCropVarietyRequest request)
    {
        return new CreateCropVarietyCommand
        {
            CropId = request.CropId,
            VarietyName = request.VarietyName,
            BreederName = request.BreederName,
            DaysToMaturity = request.DaysToMaturity,
            ExpectedYield = request.ExpectedYield,
            DiseaseResistance = request.DiseaseResistance,
            PestResistance = request.PestResistance,
            ClimateSuitability = request.ClimateSuitability,
            IsActive = request.IsActive
        };
    }
    public static UpdateCropVarietyCommand ToUpdateCommand(string id, UpdateCropVarietyRequest request)
    {
        return new UpdateCropVarietyCommand
        {
            Id = id,
            CropId = request.CropId,
            VarietyName = request.VarietyName,
            BreederName = request.BreederName,
            DaysToMaturity = request.DaysToMaturity,
            ExpectedYield = request.ExpectedYield,
            DiseaseResistance = request.DiseaseResistance,
            PestResistance = request.PestResistance,
            ClimateSuitability = request.ClimateSuitability,
            IsActive = request.IsActive
        };
    }
    public static SearchCropVarietiesQuery ToSearchQuery(SearchCropVarietyRequest request)
    {
        return new SearchCropVarietiesQuery(request.Term,
                                            request.CropId,
                                            request.DaysToMaturity,
                                            request.MinExpectedYield,
                                            request.MaxExpectedYield,
                                            request.IsActive,
                                            request.PageNumber,
                                            request.PageSize);
    }
}