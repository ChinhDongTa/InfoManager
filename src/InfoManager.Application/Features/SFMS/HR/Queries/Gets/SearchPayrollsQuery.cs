namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record SearchPayrollsQuery(string? Term, string? HREmployeeId, PayrollStatus? PaymentStatus, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<PayrollSummaryDto>>>;

public class SearchPayrollsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchPayrollsQuery, Result<PaginatedList<PayrollSummaryDto>>>
{
    public async Task<Result<PaginatedList<PayrollSummaryDto>>> Handle(SearchPayrollsQuery request, CancellationToken ct)
    {
        var paged = await context.Payrolls.BuildSearchQuery(request)
            .ApplySorting()
            .ToPayrollSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PayrollSummaryDto>>.Success(paged);
    }
}