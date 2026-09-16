using InfoManager.Shared.Dtos.FamilyEventOccurrences;

namespace InfoManager.Application.Features.FamilyEventOccurrences.Queries;

public record GetFamilyEventOccurrenceByIdQuery(string Id) : IRequest<Result<FamilyEventOccurrenceDto?>>;

public class GetFamilyEventOccurrenceByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFamilyEventOccurrenceByIdQuery, Result<FamilyEventOccurrenceDto?>>
{
    public async Task<Result<FamilyEventOccurrenceDto?>> Handle(GetFamilyEventOccurrenceByIdQuery request, CancellationToken ct)
    {
        return await context.FamilyEventOccurrences
            .Where(e => e.Id == request.Id)
            .ToFamilyEventOccurrenceDto()
            .SingleOrNotFoundAsync(nameof(FamilyEventOccurrence), request.Id, ct);
    }
}