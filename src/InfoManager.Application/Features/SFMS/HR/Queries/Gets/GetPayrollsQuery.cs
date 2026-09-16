namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetPayrollsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<PayrollSummaryDto>>>;

public class GetPayrollsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPayrollsQuery, Result<PaginatedList<PayrollSummaryDto>>>
{
    public async Task<Result<PaginatedList<PayrollSummaryDto>>> Handle(GetPayrollsQuery request, CancellationToken ct)
    {
        var result = await context.Payrolls
            .ApplySorting()
            .ToPayrollSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PayrollSummaryDto>>.Success(result);
    }
}