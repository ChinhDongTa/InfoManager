using InfoManager.Shared.Dtos.SocialAccounts;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Features.SocialAccounts.Queries.GetSocialAccounts;

public record GetSocialAccountsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<SocialAccountSummaryDto>>>;
public class GetSocialAccountsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSocialAccountsQuery, Result<PaginatedList<SocialAccountSummaryDto>>>
{
    public async Task<Result<PaginatedList<SocialAccountSummaryDto>>> Handle(GetSocialAccountsQuery request, CancellationToken cancellationToken)
    {
        var paginated = await context.SocialAccounts
            .ApplySorting()
            .ToSocialAccountSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<SocialAccountSummaryDto>>.Success(paginated);
    }
}