using InfoManager.Application.Features.SFMS.Infrastructure.Commands;

namespace InfoManager.Application.Common.Mappings;

/// <summary>
/// Mapping từ Request sang Command của Farmer.
/// </summary>
public static class FarmerMappings
{
    public static CreateFarmerCommand ToCreateCommand(CreateFarmerRequest request)
        => new()
        {
            UserId = request.UserId,
            FullName = request.FullName,
            FamilyMemberId = request.FamilyMemberId,
            FarmerCode = request.FarmerCode,
            Phone = request.Phone,
            Email = request.Email,
            IdentityNumber = request.IdentityNumber,
            Address = request.Address,
            Notes = request.Notes
        };

    public static UpdateFarmerCommand ToUpdateCommand(UpdateFarmerRequest request, string id)
        => new()
        {
            Id = id,
            FamilyMemberId = request.FamilyMemberId,
            FarmerCode = request.FarmerCode,
            FullName = request.FullName,
            Phone = request.Phone,
            Email = request.Email,
            IdentityNumber = request.IdentityNumber,
            Address = request.Address,
            Notes = request.Notes
        };
}