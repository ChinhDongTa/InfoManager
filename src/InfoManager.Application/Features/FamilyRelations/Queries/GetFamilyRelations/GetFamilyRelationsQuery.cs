using InfoManager.Shared.Dtos.FamilyRelations;

namespace InfoManager.Application.Features.FamilyRelations.Queries.GetFamilyRelations;

public record GetFamilyRelationsQuery(string? Name = null, int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<FamilyRelationDto>>>;

public class GetFamilyRelationsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFamilyRelationsQuery, Result<PaginatedList<FamilyRelationDto>>>
{
    public async Task<Result<PaginatedList<FamilyRelationDto>>> Handle(GetFamilyRelationsQuery request, CancellationToken ct)
    {
        var query = context.FamilyRelations.AsQueryable();
        if (!string.IsNullOrEmpty(request.Name))
            query = query.Where(fr => EF.Functions.ILike(fr.Name, $"%{request.Name}%")).ApplySorting();
        var paginatedList = await query.ToFamilyRelationDto().PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FamilyRelationDto>>.Success(paginatedList);
    }
}