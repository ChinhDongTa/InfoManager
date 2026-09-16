using InfoManager.Shared.Dtos.SocialAccounts;

namespace InfoManager.Application.Features.SocialAccounts.Queries.GetSocialAccounts;

public record GetSocialAccountByIdQuery(string Id) : IRequest<Result<SocialAccountDto?>>;

public class GetSocialAccountByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSocialAccountByIdQuery, Result<SocialAccountDto?>>
{
    public async Task<Result<SocialAccountDto?>> Handle(GetSocialAccountByIdQuery request, CancellationToken ct)
    {
        var result = await context.SocialAccounts
            .Where(s => s.Id == request.Id)
            .ToSocialAccountDto()
            .SingleOrNotFoundAsync(nameof(SocialAccount), request.Id, ct);
        return result;
    }
}