namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record SearchFarmExpensesQuery(
    string? Term,
    string? FarmId,
    string? CropPlantingId,
    ExpenseType? ExpenseType,
    PaymentStatus? PaymentStatus,
    ApprovalStatus? ApprovalStatus,
    DateTimeOffset? StartExpenseDate,
    DateTimeOffset? EndExpenseDate,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<FarmExpenseSummaryDto>>>;

public class SearchFarmExpensesQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchFarmExpensesQuery, Result<PaginatedList<FarmExpenseSummaryDto>>>
{
    public async Task<Result<PaginatedList<FarmExpenseSummaryDto>>> Handle(SearchFarmExpensesQuery request, CancellationToken ct)
    {
        var page = await context.FarmExpenses.BuildSearchQuery(request)
                                            .ApplySorting()
                                            .ToFarmExpenseSummaryDto()
                                            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FarmExpenseSummaryDto>>.Success(page);
    }
}