using InfoManager.Shared.Dtos.Categories;

namespace InfoManager.Application.Features.Categories.Queries.GetCategories;

public record GetCategoriesQuery(string? Group = null, string? KeyName = null, int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<CategoryDto>>>;

public class GetCategoriesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCategoriesQuery, Result<PaginatedList<CategoryDto>>>
{
    public async Task<Result<PaginatedList<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken ct)
    {
        // Note: User filtering is now handled automatically by global query filter in DbContext
        var query = context.Categories.AsQueryable();
        if (!string.IsNullOrEmpty(request.Group))
            query = query.Where(c => c.Group == request.Group);
        if (!string.IsNullOrEmpty(request.KeyName))
            query = query.Where(c => c.KeyName == request.KeyName);

        var paginatedList = await query.ApplySorting().ToCategoryDto().PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<CategoryDto>>.Success(paginatedList);
    }
}