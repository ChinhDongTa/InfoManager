namespace InfoManager.Shared.Dtos.Common;

public record SelectListItemDto(string Id, string Name);

/// <summary>
/// Generic message response DTO for simple success/status messages
/// </summary>
public record MessageResponse
{
    public string Message { get; init; } = string.Empty;
}