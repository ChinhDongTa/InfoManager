using InfoManager.Application.Features.SFMS.HR.Commands;
using InfoManager.Application.Features.SFMS.HR.Queries.Gets;

namespace InfoManager.Api.Endpoints.SFMS.HR;

public class EmployeeContracts : EndpointGroupBase
{
    public override string GroupName => "EmployeeContracts";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetEmployeeContractByIdAsync, "{id}");
        api.MapGet(GetEmployeeContractsAsync);
        api.MapGet(SearchEmployeeContractsAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateEmployeeContractAsync);
        api.MapPut(UpdateEmployeeContractAsync, "{id}");
        api.MapDelete(DeleteEmployeeContractAsync, "{id}");
    }
    public async Task<IResult> GetEmployeeContractByIdAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetEmployeeContractByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> GetEmployeeContractsAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetEmployeeContractsQuery(pageNumber, pageSize), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> SearchEmployeeContractsAsync([AsParameters] SearchEmployeeContractsRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(HRMappings.ToSearchQuery(request), cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> CreateEmployeeContractAsync(CreateEmployeeContractRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(HRMappings.ToCreateCommand(request), cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateEmployeeContractAsync(string id, UpdateEmployeeContractRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var result = await sender.Send(HRMappings.ToUpdateCommand(request, id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteEmployeeContractAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteEmployeeContractCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}