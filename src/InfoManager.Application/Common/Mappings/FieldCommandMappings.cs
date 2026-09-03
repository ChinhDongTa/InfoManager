using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

public static class FieldMappings
{
    public static CreateFieldCommand ToCreateCommand(CreateFieldRequest request)
        => new()
        {
            Name = request.Name,
            Description = request.Description,
            Area = request.Area,
            FarmId = request.FarmId,
            SoilType = request.SoilType,
            SoilCondition = request.SoilCondition,
            Elevation = request.Elevation,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Status = request.Status,
            LastPreparationDate = request.LastPreparationDate,
            DrainageCondition = request.DrainageCondition,
            HasIrrigation = request.HasIrrigation
        };

    public static UpdateFieldCommand ToUpdateCommand(string id, UpdateFieldRequest request)
        => new()
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            Area = request.Area,
            FarmId = request.FarmId,
            SoilType = request.SoilType,
            SoilCondition = request.SoilCondition,
            Elevation = request.Elevation,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Status = request.Status,
            LastPreparationDate = request.LastPreparationDate,
            DrainageCondition = request.DrainageCondition,
            HasIrrigation = request.HasIrrigation
        };

    public static SearchFieldsQuery ToSearchQuery(SearchFieldsRequest request, int pageNumber = 1, int pageSize = 20)
        => new(
        
            Term : request.Term,
            FarmId : request.FarmId,
            SoilCondition : request.SoilCondition,
            Status : request.Status,
            StartLastPreparationDate : request.StartLastPreparationDate,
            EndLastPreparationDate : request.EndLastPreparationDate,
            HasIrrigation : request.HasIrrigation,
            PageNumber : pageNumber,
            PageSize : pageSize
        );
}