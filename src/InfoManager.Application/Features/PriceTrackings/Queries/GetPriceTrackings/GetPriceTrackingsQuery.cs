using InfoManager.Shared.Dtos.PriceTrackings;

namespace InfoManager.Application.Features.PriceTrackings.Queries.GetPriceTrackings;

public record GetPriceTrackingsQuery(int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<PriceTrackingDto>>>;

public class GetPriceTrackingsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPriceTrackingsQuery, Result<PaginatedList<PriceTrackingDto>>>
{
    public async Task<Result<PaginatedList<PriceTrackingDto>>> Handle(GetPriceTrackingsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.PriceTrackings
            .ApplySorting()
            .ToPriceTrackingDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<PriceTrackingDto>>.Success(result);
    }
}