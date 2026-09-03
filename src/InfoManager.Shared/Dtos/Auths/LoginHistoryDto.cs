namespace InfoManager.Shared.Dtos.Auths;

public record LoginHistoryDto(
    string Id,
    string UserId,
    DateTimeOffset LoginTime,
    string? IPAddress,
    string? DeviceInfo
    );