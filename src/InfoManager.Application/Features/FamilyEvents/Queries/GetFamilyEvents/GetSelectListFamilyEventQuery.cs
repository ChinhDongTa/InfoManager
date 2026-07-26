namespace InfoManager.Application.Features.FamilyEvents.Queries.GetFamilyEvents;

public record GetSelectListFamilyEventQuery(string FamilyMemberId) : IRequest<Result<List<SelectListItemDto>>>;
public class GetSelectListFamilyEventQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSelectListFamilyEventQuery, Result<List<SelectListItemDto>>>
{
    public async Task<Result<List<SelectListItemDto>>> Handle(GetSelectListFamilyEventQuery request, CancellationToken ct)
    {
        var selectList = await context.FamilyEvents
            .Where(e => e.FamilyMemberId == request.FamilyMemberId)
            .ApplySorting()
            .Select(e => new SelectListItemDto
            (
                Id: e.Id,
                Name: e.Title
            )).ToListAsync(ct);
        return Result<List<SelectListItemDto>>.Success(selectList);
    }
}