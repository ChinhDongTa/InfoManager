namespace InfoManager.Shared.Dtos.PriceTrackings;

public record PriceTrackingDto(
    string Id,
    string ProductName,
    string? Description,
    decimal CurrentPrice,
    decimal? DesiredPrice,
    decimal? LowestPriceSeen,
    string? StoreName,
    string? ProductUrl,
    bool IsPurchased,
    DateTime? LastCheckedDate
);
public record PriceTrackingSummaryDto(
    string Id,
    string ProductName,
    decimal CurrentPrice,
    decimal? LowestPriceSeen,
    bool IsPurchased,
    string? ProductUrl
);
public record SearchPriceTrackingRequest(
    string? SearchTerm = null,
    decimal? MinPrice = null,
    decimal? MaxPrice = null,
    string? SortBy = null,
    bool Ascending = true,
    int PageNumber = 1,
    int PageSize = 20);
public record CreatePriceTrackingRequest
{
    public string ProductName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public decimal CurrentPrice { get; init; }
    public decimal? DesiredPrice { get; init; }
    public decimal? LowestPriceSeen { get; init; }
    public string? StoreName { get; init; }
    public string? ProductUrl { get; init; }
    public bool IsPurchased { get; init; } = false;
    public DateTimeOffset? LastCheckedDate { get; init; }
}
public record UpdatePriceTrackingRequest
{
    public required string Id { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ProductName { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public decimal? CurrentPrice { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public decimal? DesiredPrice { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public decimal? LowestPriceSeen { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StoreName { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ProductUrl { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsPurchased { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTimeOffset? LastCheckedDate { get; init; }
}