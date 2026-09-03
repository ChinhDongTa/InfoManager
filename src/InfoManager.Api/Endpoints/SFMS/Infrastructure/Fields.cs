using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.Infrastructure;

public class Fields : EndpointGroupBase
{
    override public string GroupName => "Fields";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetFieldByIdAsync, "{id}");
        api.MapGet(GetFieldsAsync);
        api.MapGet(SearchFieldsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateFieldAsync);
        api.MapPut(UpdateFieldAsync, "{id}");
        api.MapDelete(DeleteFieldAsync, "{id}");
    }
    public async Task<IResult> GetFieldByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetFieldByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetFieldsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetFieldsQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchFieldsAsync([AsParameters] SearchFieldsRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(FieldMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateFieldAsync(CreateFieldRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(FieldMappings.ToCreateCommand(request), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> UpdateFieldAsync(string id, UpdateFieldRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if(id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(FieldMappings.ToUpdateCommand(id, request), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteFieldAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteFieldCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}
