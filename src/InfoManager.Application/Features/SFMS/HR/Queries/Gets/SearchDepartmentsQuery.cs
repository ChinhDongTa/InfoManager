namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record SearchDepartmentsQuery(string? Term, string? FarmId, string? ParentId, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<DepartmentSummaryDto>>>;

public class SearchDepartmentsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchDepartmentsQuery, Result<PaginatedList<DepartmentSummaryDto>>>
{
    public async Task<Result<PaginatedList<DepartmentSummaryDto>>> Handle(SearchDepartmentsQuery request, CancellationToken ct)
    {
        var paged = await context.Departments.BuildSearchQuery(request)
            .ApplySorting()
            .ToDepartmentSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<DepartmentSummaryDto>>.Success(paged);
    }
}