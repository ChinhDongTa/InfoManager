namespace InfoManager.Shared.Dtos.Families;

public record FamilyDto(string Id, string Name, string? RepresentativeName, string? Address, string? Email);
public record FamilySummaryDto(string Id, string Name, string? Email);
public record InitDataForUserRequest(string FullName, string Email, DateOnly BirthDate, Gender Gender, string? PhoneNumber);
public record CreateFamilyRequest(string Name, string? RepresentativeId, string? Address, string? Email);
public record UpdateFamilyRequest(string Id, string? Name, string? RepresentativeId, string? Address, string? Email);
public record SearchFamilyRequest(string? SearchTerm, int PageNumber, int PageSize);