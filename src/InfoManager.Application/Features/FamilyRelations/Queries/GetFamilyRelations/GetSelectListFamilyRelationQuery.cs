namespace InfoManager.Application.Features.FamilyRelations.Queries.GetFamilyRelations;

public record GetSelectListFamilyRelationsQuery() : IRequest<Result<List<SelectListItemDto>>>;

public class GetSelectListFamilyRelationsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSelectListFamilyRelationsQuery, Result<List<SelectListItemDto>>>
{
    public async Task<Result<List<SelectListItemDto>>> Handle(GetSelectListFamilyRelationsQuery request, CancellationToken ct)
    {
        var selectList = await context.FamilyRelations
            .ApplySorting()
            .Select(fr => new SelectListItemDto
            (
                Id: fr.Id,
                Name: fr.Name
            )).ToListAsync(ct);
        return Result<List<SelectListItemDto>>.Success(selectList);
    }
}