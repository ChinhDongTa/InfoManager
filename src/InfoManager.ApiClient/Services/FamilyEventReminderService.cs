using InfoManager.Shared.Dtos.FamilyEventReminders;

namespace InfoManager.ApiClient.Services;

public class FamilyEventReminderService(IFamilyEventReminderApi api) : IFamilyEventReminderService
{
    public async Task<ApiResult<string>> CreateFamilyEventReminderAsync(CreateFamilyEventReminderRequest dto, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.CreateFamilyEventReminderAsync(dto, ct));

    public async Task<ApiResult> DeleteFamilyEventReminderAsync(string memberId, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.DeleteFamilyEventReminderAsync(memberId, ct));

    public async Task<ApiResult<FamilyEventReminderDto?>> GetFamilyEventReminderByIdAsync(string id, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyEventReminderByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<FamilyEventReminderSummaryDto>>> GetFamilyEventRemindersAsync(int pageNumber, int pageSize, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyEventRemindersAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FamilyEventReminderSummaryDto>>> GetFamilyEventRemindersByMemberIdAsync(string memberId,
                                                                                                                      int pageNumber,
                                                                                                                      int pageSize,
                                                                                                                      CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.GetFamilyEventRemindersByMemberIdAsync(memberId, pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<FamilyEventReminderSummaryDto>>> SearchFamilyEventRemindersAsync(SearchFamilyEventReminderRequest dto,
                                                                                                               CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.SearchFamilyEventRemindersAsync(dto.MinDaysBefore,
                                                                                          dto.MaxDaysBefore,
                                                                                          dto.Channel,
                                                                                          dto.PageNumber,
                                                                                          dto.PageSize,
                                                                                          ct));

    public async Task<ApiResult> UpdateFamilyEventReminderAsync(string id, UpdateFamilyEventReminderRequest dto, CancellationToken ct = default)
        => await ApiResponseHandler.HandleAsync(await api.UpdateFamilyEventReminderAsync(id, dto, ct));
}