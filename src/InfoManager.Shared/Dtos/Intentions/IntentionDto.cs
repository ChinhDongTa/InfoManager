namespace InfoManager.Shared.Dtos.Intentions;

public record IntentionDto(string Id,
                           string Content,
                           string? Description,
                           DateTime? PlannDate,
                           bool IsCompleted,
                           string? PriorityName,
                           string? CategoryName,
                           string? CategoryId,
                           Priority Priority);
public record IntentionSummaryDto(string Id,
                                  string Content,
                                  bool IsCompleted,
                                  string? PriorityName);
public record SearchIntentionRequest(string? SearchTerm,
                                     string? CategoryId,
                                     DateTime? StartDate,
                                     DateTime? EndDate,
                                     int PageNumber = 1,
                                     int PageSize = 20);

public record CreateIntentionRequest
{
    public required string Content { get; init; }
    public string? Description { get; init; }
    public DateTimeOffset? PlannDate { get; init; }
    public bool IsCompleted { get; init; } = false;
    public Priority Priority { get; init; } = Priority.Medium;
    public string? CategoryId { get; init; }
}
public record UpdateIntentionRequest
{
    public required string Id { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public  string? Content { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTimeOffset? PlannDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsCompleted { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Priority? Priority { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CategoryId { get; init; }
}