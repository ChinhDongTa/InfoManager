namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record GetFarmExpensesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FarmExpenseSummaryDto>>>;
public class GetFarmExpensesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFarmExpensesQuery, Result<PaginatedList<FarmExpenseSummaryDto>>>
{
    public async Task<Result<PaginatedList<FarmExpenseSummaryDto>>> Handle(GetFarmExpensesQuery request, CancellationToken cancellationToken)
    {
        var result = await context.FarmExpenses
            .ApplySorting()
            .ToFarmExpenseSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<FarmExpenseSummaryDto>>.Success(result);
    }
}