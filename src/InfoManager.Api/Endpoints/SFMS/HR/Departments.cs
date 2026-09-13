using InfoManager.Application.Features.SFMS.HR.Commands;
using InfoManager.Application.Features.SFMS.HR.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.HR;

public class Departments : EndpointGroupBase
{
    public override string GroupName => "Departments";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetDepartmentByIdAsync, "{id}");
        api.MapGet(GetDepartmentsAsync);
        api.MapGet(SearchDepartmentsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateDepartmentAsync);
        api.MapPut(UpdateDepartmentAsync, "{id}");
        api.MapDelete(DeleteDepartmentAsync, "{id}");
    }
    public async Task<IResult> GetDepartmentByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetDepartmentByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetDepartmentsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetDepartmentsQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchDepartmentsAsync([AsParameters] SearchDepartmentsRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(HRMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateDepartmentAsync(CreateDepartmentRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(HRMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateDepartmentAsync(string id, UpdateDepartmentRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(HRMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteDepartmentAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteDepartmentCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}