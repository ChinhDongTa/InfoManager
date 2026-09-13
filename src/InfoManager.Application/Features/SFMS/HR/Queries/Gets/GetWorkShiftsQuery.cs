namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetWorkShiftsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<WorkShiftSummaryDto>>>;
public class GetWorkShiftsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetWorkShiftsQuery, Result<PaginatedList<WorkShiftSummaryDto>>>
{
    public async Task<Result<PaginatedList<WorkShiftSummaryDto>>> Handle(GetWorkShiftsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.WorkShifts
            .ApplySorting()
            .ToWorkShiftSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<WorkShiftSummaryDto>>.Success(result);
    }
}
