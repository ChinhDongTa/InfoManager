namespace InfoManager.Shared.Dtos.Experiences;

public record ExperienceDto(string Id, string Content, string? Description, DateOnly? ExperienceDate, string? CategoryName, string? CategoryId);
public record ExperienceSummaryDto(string Id, string Content, DateOnly? ExperienceDate);
public record SearchExperiencesRequest
(
     string? Keyword,
     string? CategoryId ,
     int PageNumber= 1,
     int PageSize = 20
);

public record CreateExperienceRequest
{
    public required string Content { get; init; }
    public string? Description { get; init; }
    public DateOnly? ExperienceDate { get; init; }
    public string? CategoryId { get; init; }
}

public record UpdateExperienceRequest
{
    public string Id { get; init; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Content { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateOnly? ExperienceDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CategoryId { get; init; }
}