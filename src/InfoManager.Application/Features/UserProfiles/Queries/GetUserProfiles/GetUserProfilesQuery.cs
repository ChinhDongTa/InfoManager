using InfoManager.Shared.Dtos.UserProfiles;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Features.UserProfiles.Queries.GetUserProfiles;

public record GetUserProfilesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<UserProfileDto>>>;
public class GetUserProfilesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetUserProfilesQuery, Result<PaginatedList<UserProfileDto>>>
{
    public async Task<Result<PaginatedList<UserProfileDto>>> Handle(GetUserProfilesQuery request, CancellationToken cancellationToken)
    {
        var paginated = await context.UserProfiles
            .ApplySorting()
            .ToUserProfileDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<UserProfileDto>>.Success(paginated);
    }
}