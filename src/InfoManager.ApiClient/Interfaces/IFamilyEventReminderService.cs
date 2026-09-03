using InfoManager.Shared.Dtos.FamilyEventReminders;

namespace InfoManager.ApiClient.Interfaces;

public interface IFamilyEventReminderService
{
    Task<ApiResult<FamilyEventReminderDto?>> GetFamilyEventReminderByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<FamilyEventReminderSummaryDto>>> GetFamilyEventRemindersAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateFamilyEventReminderAsync(CreateFamilyEventReminderRequest dto, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<FamilyEventReminderSummaryDto>>> GetFamilyEventRemindersByMemberIdAsync(string memberId, int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult> DeleteFamilyEventReminderAsync(string memberId, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<FamilyEventReminderSummaryDto>>> SearchFamilyEventRemindersAsync(SearchFamilyEventReminderRequest dto, CancellationToken ct = default);
    Task<ApiResult> UpdateFamilyEventReminderAsync(string id, UpdateFamilyEventReminderRequest dto, CancellationToken ct = default);
}