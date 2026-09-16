using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

/// <summary>
/// Mapping từ Request sang Command của Farm.
/// </summary>
public static class FarmMappings
{
    public static CreateFarmCommand ToCreateCommand(CreateFarmRequest request)
        => new()
        {
            Name = request.Name,
            Description = request.Description,
            TotalArea = request.TotalArea,
            CultivableArea = request.CultivableArea,
            Location = request.Location,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            FarmerId = request.FarmerId,
            LicenseNumber = request.LicenseNumber,
            Status = request.Status,
            EstablishedDate = request.EstablishedDate
        };

    public static UpdateFarmCommand ToUpdateCommand(UpdateFarmRequest request, string id)
        => new()
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            TotalArea = request.TotalArea,
            CultivableArea = request.CultivableArea,
            Location = request.Location,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            FarmerId = request.FarmerId,
            LicenseNumber = request.LicenseNumber,
            Status = request.Status,
            EstablishedDate = request.EstablishedDate
        };

    public static SearchFarmsQuery ToSearchQuery(SearchFarmsRequest request)
        => new(Term: request.Term,
               MinCultivableArea: request.MinCultivableArea,
               MaxCultivableArea: request.MaxCultivableArea,
               Status: request.Status,
               PageNumber: request.PageNumber,
               PageSize: request.PageSize);
}