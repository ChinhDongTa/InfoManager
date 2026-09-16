using InfoManager.Shared.Dtos.Categories;

namespace InfoManager.Application.Features.Categories.Queries.GetCategories;

public record GetCategoryByIdQuery(string Id) : IRequest<Result<CategoryDto?>>;

public class GetCategoryByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCategoryByIdQuery, Result<CategoryDto?>>
{
    public async Task<Result<CategoryDto?>> Handle(GetCategoryByIdQuery request, CancellationToken ct)
    {
        // Note: User filtering is now handled automatically by global query filter in DbContext
        var result = await context.Categories
            .Where(c => c.Id == request.Id)
            .ApplySorting()
            .ToCategoryDto()
            .SingleOrNotFoundAsync("Category", request.Id, ct);
        return result;
    }
}