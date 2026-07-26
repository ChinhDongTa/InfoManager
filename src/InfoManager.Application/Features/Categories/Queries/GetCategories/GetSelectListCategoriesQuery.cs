using InfoManager.Shared.Dtos.Common;

namespace InfoManager.Application.Features.Categories.Queries.GetCategories;

public record GetSelectListCategoriesQuery(string? Group = null, string? KeyName = null) : IRequest<Result<List<SelectListItemDto>>>;
public class GetSelectListCategoriesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSelectListCategoriesQuery, Result<List<SelectListItemDto>>>
{
    public async Task<Result<List<SelectListItemDto>>> Handle(GetSelectListCategoriesQuery request, CancellationToken ct)
    {
        var query = context.Categories.AsQueryable();
        if (!string.IsNullOrEmpty(request.Group))
            query = query.Where(c => c.Group == request.Group);
        if (!string.IsNullOrEmpty(request.KeyName))
            query = query.Where(c => c.KeyName == request.KeyName);
        var selectList = await query
            .ApplySorting()
            .Select(c => new SelectListItemDto
                (
                    Id: c.Id,
                    Name: c.Name
                )).ToListAsync(ct);
        return Result<List<SelectListItemDto>>.Success(selectList);
    }
}