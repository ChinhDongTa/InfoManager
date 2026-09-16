namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record SearchHREmployeesQuery(string? Term, string? FarmId, string? HREmployeeId, EmploymentStatus? Status, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<HREmployeeSummaryDto>>>;

public class SearchHREmployeesQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchHREmployeesQuery, Result<PaginatedList<HREmployeeSummaryDto>>>
{
    public async Task<Result<PaginatedList<HREmployeeSummaryDto>>> Handle(SearchHREmployeesQuery request, CancellationToken ct)
    {
        var paged = await context.HREmployees.BuildSearchQuery(request)
            .ApplySorting()
            .ToHREmployeeSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<HREmployeeSummaryDto>>.Success(paged);
    }
}