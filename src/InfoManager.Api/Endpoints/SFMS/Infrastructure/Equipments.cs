using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.Infrastructure;

public class Equipments : EndpointGroupBase
{
    public override string GroupName => "Equipments";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetEquipmentByIdAsync, "{id}");
        api.MapGet(GetEquipmentsAsync);
        api.MapGet(SearchEquipmentsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateEquipmentAsync);
        api.MapPut(UpdateEquipmentAsync, "{id}");
        api.MapDelete(DeleteEquipmentAsync, "{id}");
    }

    public async Task<IResult> GetEquipmentByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetEquipmentByIdQuery(id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetEquipmentsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new GetEquipmentsQuery(pageNumber, pageSize), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchEquipmentsAsync([AsParameters] SearchEquipmentsRequest request, [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(EquipmentMappings.ToSearchQuery(request), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateEquipmentAsync(CreateEquipmentRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(EquipmentMappings.ToCreateCommand(request), ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateEquipmentAsync(string id, UpdateEquipmentRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(EquipmentMappings.ToUpdateCommand(request, id), ct);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteEquipmentAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken ct)
    {
        var result = await sender.Send(new DeleteEquipmentCommand(id), ct);
        return result.ToHttpResult();
    }
}