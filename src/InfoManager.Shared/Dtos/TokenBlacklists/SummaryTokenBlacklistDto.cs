namespace InfoManager.Shared.Dtos.TokenBlacklists;

public record SummaryTokenBlacklistDto(string Id, string Reason, string Status, DateTimeOffset ExpiresAt, string? Note);