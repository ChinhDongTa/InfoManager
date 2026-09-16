namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record SearchFarmRevenuesQuery(
    string? Term,
    string? FarmId,
    string? CropPlantingId,
    string? HarvestId,
    string? SaleId,
    PaymentStatus? PaymentStatus,
    DateTimeOffset? StartRevenueDate,
    DateTimeOffset? EndRevenueDate,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<FarmRevenueSummaryDto>>>;

public class SearchFarmRevenuesQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchFarmRevenuesQuery, Result<PaginatedList<FarmRevenueSummaryDto>>>
{
    public async Task<Result<PaginatedList<FarmRevenueSummaryDto>>> Handle(SearchFarmRevenuesQuery request, CancellationToken ct)
    {
        var paged = await context.FarmRevenues.BuildSearchQuery(request)
            .ApplySorting()
            .ToFarmRevenueSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FarmRevenueSummaryDto>>.Success(paged);
    }
}