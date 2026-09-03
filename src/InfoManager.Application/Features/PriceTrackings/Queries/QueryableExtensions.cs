using InfoManager.Shared.Dtos.PriceTrackings;

namespace InfoManager.Application.Features.PriceTrackings.Queries;

public static class QueryableExtensions
{
    public static IQueryable<PriceTrackingDto> ToPriceTrackingDto(this IQueryable<PriceTracking> query)
    {
        return query.Select(pt => new PriceTrackingDto(
            Id: pt.Id,
            ProductName: pt.ProductName,
            Description: pt.Description,
            CurrentPrice: pt.CurrentPrice,
            DesiredPrice: pt.DesiredPrice,
            LowestPriceSeen: pt.LowestPriceSeen,
            StoreName: pt.StoreName,
            ProductUrl: pt.ProductUrl,
            IsPurchased: pt.IsPurchased,
            LastCheckedDate: pt.LastCheckedDate.ToLocalDateTime()
        ));
    }
    public static IQueryable<PriceTrackingSummaryDto> ToPriceTrackingSummaryDto(this IQueryable<PriceTracking> query)
    {
        return query.Select(pt => new PriceTrackingSummaryDto(
            Id: pt.Id,
            ProductName: pt.ProductName,
            CurrentPrice: pt.CurrentPrice,
            LowestPriceSeen: pt.LowestPriceSeen,
            IsPurchased: pt.IsPurchased,
            ProductUrl: pt.ProductUrl
        ));
    }
    /// <summary>
    /// Applies sorting to the PriceTracking query based on the provided sortBy parameter.
    /// </summary>
    /// <param name="query">The queryable collection of PriceTracking entities to sort.</param>
    /// <param name="sortBy">The field (currentPrice, desiredPrice, lowestPriceSeen) to sort by. If null or empty, defaults to sorting by LastCheckedDate in descending order.</param>
    /// <param name="ascending">Determines the sort order. True for ascending, false for descending.</param>
    /// <returns>The sorted queryable collection of PriceTracking entities.</returns>
    public static IQueryable<PriceTracking> ApplySorting(this IQueryable<PriceTracking> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(pt => pt.LastCheckedDate);
        }
        return sortBy.ToLower() switch
        {
            "currentprice" => ascending ? query.OrderBy(pt => pt.CurrentPrice) : query.OrderByDescending(pt => pt.CurrentPrice),
            "desiredprice" => ascending ? query.OrderBy(pt => pt.DesiredPrice) : query.OrderByDescending(pt => pt.DesiredPrice),
            "lowestpriceseen" => ascending ? query.OrderBy(pt => pt.LowestPriceSeen) : query.OrderByDescending(pt => pt.LowestPriceSeen),
            _ => query
        };
    }
}