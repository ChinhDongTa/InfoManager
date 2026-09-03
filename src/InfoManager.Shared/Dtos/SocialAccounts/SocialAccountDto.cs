namespace InfoManager.Shared.Dtos.SocialAccounts;

public record SocialAccountDto(string Id,
                               string UserId,
                               string Provider,
                               string ProviderAccountId,
                               string? DisplayName,
                               bool IsPrimary,
                               string? HomepageUrl);
public record SocialAccountSummaryDto(string Id,
                                      string UserName,
                                      string Provider,
                                      string? DisplayName,
                                      bool IsPrimary);
public record CreateSocialAccountRequest(string UserId,
                                         string Provider,
                                         string ProviderAccountId,
                                         string? DisplayName,
                                         bool IsPrimary,
                                         string? HomepageUrl);
public record UpdateSocialAccountRequest(string Id,
                                         string? UserId,
                                         string? Provider,
                                         string? ProviderAccountId,
                                         string? DisplayName,
                                         bool? IsPrimary,
                                         string? HomepageUrl);