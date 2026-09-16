using InfoManager.Shared.Dtos.FamilyEvents;

namespace InfoManager.Application.Features.FamilyEvents.Queries.GetFamilyEvents;

public record GetFamilyEventByIdQuery(string Id) : IRequest<Result<FamilyEventDto?>>;

public class GetFamilyEventByIdQueryHandler(IApplicationDbContext Context) : IRequestHandler<GetFamilyEventByIdQuery, Result<FamilyEventDto?>>
{
    public async Task<Result<FamilyEventDto?>> Handle(GetFamilyEventByIdQuery request, CancellationToken ct)
    {
        // Note: User filtering is now handled automatically by global query filter in DbContext
        var familyEvent = await Context.FamilyEvents
            .Where(fe => fe.Id == request.Id)
            .ToQueryDto()
            .SingleOrNotFoundAsync(nameof(FamilyEvent), request.Id, ct);

        return familyEvent;
    }
}