namespace InfoManager.Application.Features.FamilyMembers.Queries.GetFamilyMembers;

public record GetSelectListFamilyMemberQuery() : IRequest<Result<List<SelectListItemDto>>>;

public class GetSelectListFamilyMemberQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSelectListFamilyMemberQuery, Result<List<SelectListItemDto>>>
{
    public async Task<Result<List<SelectListItemDto>>> Handle(GetSelectListFamilyMemberQuery request, CancellationToken ct)
    {
        var selectList = await context.FamilyMembers
            .ApplySorting()
            .Select(fm => new SelectListItemDto
            (
                Id: fm.Id,
                Name: fm.FullName
            )).ToListAsync(ct);
        return Result<List<SelectListItemDto>>.Success(selectList);
    }
}