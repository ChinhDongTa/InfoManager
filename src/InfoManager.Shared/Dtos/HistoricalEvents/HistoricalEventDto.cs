namespace InfoManager.Shared.Dtos.HistoricalEvents;

public record HistoricalEventDto(
    string Id,
    DateOnly? EventDate,
    string Title,
    string? EventName,
    string? Location,
    string Summary,
    string? ReferenceSource,
    HistoricalEventType EventType
);
public record HistoricalEventSummaryDto(
    string Id,
    DateOnly? EventDate,
    string Title,
    string? EventType
);
public record SearchHistoricalEventRequest(string? SearchTerm,
                                           DateOnly? StartDate,
                                           DateOnly? EndDate,
                                           int PageNumber = 1,
                                           int PageSize = 20);
public record CreateHistoricalEventRequest
{
    public DateOnly? EventDate { get; init; }
    public required string Title { get; init; }
    public HistoricalEventType EventType { get; init; }
    public string? Location { get; init; }
    public required string Summary { get; init; }
    public string? ReferenceSource { get; init; }
}
public record UpdateHistoricalEventRequest
{
    public string Id { get; init; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateOnly? EventDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HistoricalEventType? EventType { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Location { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Summary { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ReferenceSource { get; init; }
}