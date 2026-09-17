namespace InfoManager.ApiClient.Api;

internal interface IFarmExpenseApi
{
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
    [Get("/api/FarmExpenses/{id}")]
    Task<ApiResponse<FarmExpenseDto?>> GetFarmExpenseByIdAsync(string id, CancellationToken ct = default);
    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
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
    [Put("/api/FarmExpenses/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateFarmExpenseAsync(string id, [Body] UpdateFarmExpenseRequest request, CancellationToken ct = default);
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
    [Delete("/api/FarmExpenses/{id}")]
    Task<IApiResponse> DeleteFarmExpenseAsync(string id, CancellationToken ct = default);
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
    [Get("/api/FarmExpenses")]
    Task<ApiResponse<PaginatedList<FarmExpenseSummaryDto>>> GetFarmExpensesAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);
    /// <param name="request">request parameter</param>
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
    [Post("/api/FarmExpenses")]
    Task<ApiResponse<string>> CreateFarmExpenseAsync([Body] CreateFarmExpenseRequest request, CancellationToken ct = default);
    /// <param name="term">term parameter</param>
    /// <param name="farmId">farmId parameter</param>
    /// <param name="cropPlantingId">cropPlantingId parameter</param>
    /// <param name="expenseType">expenseType parameter</param>
    /// <param name="paymentStatus">paymentStatus parameter</param>
    /// <param name="approvalStatus">approvalStatus parameter</param>
    /// <param name="startExpenseDate">startExpenseDate parameter</param>
    /// <param name="endExpenseDate">endExpenseDate parameter</param>
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
    [Get("/api/FarmExpenses/search")]
    Task<ApiResponse<PaginatedList<FarmExpenseSummaryDto>>> SearchFarmExpensesAsync([Query, AliasAs("Term")] string? term,
                                          [Query, AliasAs("FarmId")] string? farmId,
                                          [Query, AliasAs("CropPlantingId")] string? cropPlantingId,
                                          [Query, AliasAs("ExpenseType")] ExpenseType? expenseType,
                                          [Query, AliasAs("PaymentStatus")] PaymentStatus? paymentStatus,
                                          [Query, AliasAs("ApprovalStatus")] ApprovalStatus? approvalStatus,
                                          [Query, AliasAs("StartExpenseDate")] System.DateTimeOffset? startExpenseDate,
                                          [Query, AliasAs("EndExpenseDate")] System.DateTimeOffset? endExpenseDate,
                                          [Query, AliasAs("PageNumber")] int pageNumber,
                                          [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);
}
