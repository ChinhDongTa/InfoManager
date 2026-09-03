using InfoManager.Domain.Entities.Authentication;
using InfoManager.Shared.Dtos.UserProfiles;

namespace InfoManager.Application.Features.UserProfiles.Queries.GetUserProfiles;

public record GetUserProfileByIdQuery(string UserId): IRequest<Result<UserProfileDto?>>;
public class GetUserProfileByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetUserProfileByIdQuery, Result<UserProfileDto?>>
{
    public async Task<Result<UserProfileDto?>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.UserProfiles
            .Where(u => u.UserId == request.UserId)
            .ToUserProfileDto()
            .SingleOrNotFoundAsync(nameof(UserProfile), request.UserId, cancellationToken);
        return result;
    }
}
