using InfoManager.Application.Features.SocialAccounts.Commands;
using InfoManager.Application.Features.SocialAccounts.Queries.GetSocialAccounts;
using InfoManager.Shared.Dtos.SocialAccounts;

namespace InfoManager.Api.Endpoints.Auth;

public class SocialAccounts : EndpointGroupBase
{
    public override string GroupName => "SocialAccounts";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetSocialAccountByIdAsync, "{id}");
        api.MapGet(GetSocialAccountsAsync);

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateSocialAccountAsync);
        api.MapPut(UpdateSocialAccountAsync, "{id}");
        api.MapDelete(DeleteSocialAccountAsync, "{id}");
    }
    public async Task<IResult> GetSocialAccountByIdAsync(string id,
                                                         [FromServices] ISender sender,
                                                         CancellationToken cancellationToken)
    {
        var query = new GetSocialAccountByIdQuery(id);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> GetSocialAccountsAsync(int pageNumber,
                                                      int pageSize,
                                                      [FromServices] ISender sender,
                                                      CancellationToken cancellationToken)
    {
        var query = new GetSocialAccountsQuery(pageNumber, pageSize);
        var result = await sender.Send(query, cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> CreateSocialAccountAsync([FromBody] CreateSocialAccountRequest request,
                                                        [FromServices] ISender sender,
                                                        [FromServices] IUser user,
                                                        CancellationToken cancellationToken)
    {
        var command = new CreateSocialAccountCommand()
        {
            UserId = request.UserId,
            Provider = request.Provider,
            ProviderAccountId = request.ProviderAccountId,
            DisplayName = request.DisplayName,
            HomepageUrl = request.HomepageUrl
        };
        var result = await sender.Send(command, cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }

    public async Task<IResult> UpdateSocialAccountAsync(string id,
                                                        [FromBody] UpdateSocialAccountRequest request,
                                                        [FromServices] ISender sender,
                                                        [FromServices] IUser user,
                                                        CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("Id in the URL does not match Id in the request body.");
        }
        var command = new UpdateSocialAccountCommand()
        {
            Id = id,
            UserId = request.UserId,
            Provider = request.Provider,
            ProviderAccountId = request.ProviderAccountId,
            DisplayName = request.DisplayName,
            HomepageUrl = request.HomepageUrl
        };
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> DeleteSocialAccountAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var command = new DeleteSocialAccountCommand(id);
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }
}