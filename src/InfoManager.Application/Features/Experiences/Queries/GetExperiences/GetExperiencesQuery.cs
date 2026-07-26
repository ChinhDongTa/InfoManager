using InfoManager.Shared.Dtos.Experiences;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Features.Experiences.Queries.GetExperiences;

public record GetExperiencesQuery(int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<ExperienceSummaryDto>>>;
public class GetExperiencesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetExperiencesQuery, Result<PaginatedList<ExperienceSummaryDto>>>
{
    public async Task<Result<PaginatedList<ExperienceSummaryDto>>> Handle(GetExperiencesQuery request, CancellationToken ct)
    {
        // Note: User filtering is now handled automatically by global query filter in DbContext
        var paginated = await context.Experiences
            .ApplySorting()
            .ToSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<ExperienceSummaryDto>>.Success(paginated);
    }
}