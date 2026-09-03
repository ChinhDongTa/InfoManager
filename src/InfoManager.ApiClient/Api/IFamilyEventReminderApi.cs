using InfoManager.Shared.Dtos.FamilyEventReminders;

namespace InfoManager.ApiClient.Api;

public interface IFamilyEventReminderApi
{
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/FamilyEventReminders")]
    Task<ApiResponse<PaginatedList<FamilyEventReminderSummaryDto>>> GetFamilyEventRemindersAsync([Query] int? pageNumber, [Query] int? pageSize, CancellationToken ct = default);

    /// <param name="command">command parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Post("/api/FamilyEventReminders")]
    Task<ApiResponse<string>> CreateFamilyEventReminderAsync([Body] CreateFamilyEventReminderRequest dto, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/FamilyEventReminders/{id}/member")]
    Task<ApiResponse<PaginatedList<FamilyEventReminderSummaryDto>>> GetFamilyEventRemindersByMemberIdAsync(string memberId, int pageNumber, int pageSize, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/FamilyEventReminders/{id}/event")]
    Task<ApiResponse<FamilyEventReminderDto?>> GetFamilyEventReminderByIdAsync(string id, CancellationToken ct = default);

    /// <param name="minDaysBefore">minDaysBefore parameter</param>
    /// <param name="maxDaysBefore">maxDaysBefore parameter</param>
    /// <param name="channel">channel parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/FamilyEventReminders/search")]
    Task<ApiResponse<PaginatedList<FamilyEventReminderSummaryDto>>> SearchFamilyEventRemindersAsync([Query, AliasAs("MinDaysBefore")] int? minDaysBefore,
                                                       [Query, AliasAs("MaxDaysBefore")] int? maxDaysBefore,
                                                       [Query, AliasAs("Channel")] ReminderChannel? channel,
                                                       [Query, AliasAs("PageNumber")] int? pageNumber,
                                                       [Query, AliasAs("PageSize")] int? pageSize,
                                                       CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <param name="command">command parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Put("/api/FamilyEventReminders/{id}")]
    Task<IApiResponse> UpdateFamilyEventReminderAsync(string id, [Body] UpdateFamilyEventReminderRequest dto, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Delete("/api/FamilyEventReminders/{id}")]
    Task<IApiResponse> DeleteFamilyEventReminderAsync(string id, CancellationToken ct = default);
}