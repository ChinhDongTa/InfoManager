using InfoManager.Shared.Dtos.Experiences;

namespace InfoManager.Application.Features.Experiences.Queries.GetExperiences;

public record GetExperienceByIdQuery(string Id) : IRequest<Result<ExperienceDto?>>;

public class GetExperienceByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetExperienceByIdQuery, Result<ExperienceDto?>>
{
    public async Task<Result<ExperienceDto?>> Handle(GetExperienceByIdQuery request, CancellationToken ct)
    {
        // Note: User filtering is now handled automatically by global query filter in DbContext
        var result = await context.Experiences
            .Where(e => e.Id == request.Id)
            .ApplySorting()
            .ToQueryDto()
            .SingleOrNotFoundAsync(nameof(Experience), request.Id, ct);
        return result;
    }
}