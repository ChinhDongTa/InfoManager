namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record SearchWorkShiftsQuery(string? Term, string? FarmId, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<WorkShiftSummaryDto>>>;

public class SearchWorkShiftsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchWorkShiftsQuery, Result<PaginatedList<WorkShiftSummaryDto>>>
{
    public async Task<Result<PaginatedList<WorkShiftSummaryDto>>> Handle(SearchWorkShiftsQuery request, CancellationToken ct)
    {
        var paged = await context.WorkShifts.BuildSearchQuery(request)
            .ApplySorting()
            .ToWorkShiftSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<WorkShiftSummaryDto>>.Success(paged);
    }
}