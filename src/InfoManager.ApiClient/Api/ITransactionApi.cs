using InfoManager.Shared.Dtos.Transactions;

namespace InfoManager.ApiClient.Api;

internal interface ITransactionApi
{
    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/PriceTrackings/{id}")]
    Task<IApiResponse> DeletePriceTrackingAsync(string id, CancellationToken ct);

    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Transactions/pending")]
    Task<ApiResponse<List<TransactionSummaryDto>>> GetTransactionsPendingAsync(CancellationToken ct);

    [Get("/api/Transactions/financial-summary-report")]
    Task<ApiResponse<FinancialSummaryReportDto>> GetFinancialSummaryReportAsync([Query, AliasAs("Month")] int month,
                                                                                 [Query, AliasAs("Year")] int year,
                                                                                 CancellationToken ct);

    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Post("/api/Transactions")]
    Task<ApiResponse<string>> CreateTransactionAsync([Body] CreateTransactionRequest request, CancellationToken ct);

    /// <param name="top">top parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Transactions/top/{top}")]
    Task<ApiResponse<List<TransactionSummaryDto>>> GetTopTransactionsAsync(int top, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Transactions/{id}")]
    Task<ApiResponse<TransactionDto?>> GetTransactionByIdAsync(string id, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Headers("Content-Type: application/json")]
    [Put("/api/Transactions/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateTransactionAsync(string id, [Body] UpdateTransactionRequest request, CancellationToken ct);

    /// <param name="id">id parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Delete("/api/Transactions/{id}")]
    Task<IApiResponse> DeleteTransactionAsync(string id, CancellationToken ct);

    /// <param name="minAmount">minAmount parameter</param>
    /// <param name="maxAmount">maxAmount parameter</param>
    /// <param name="startDate">startDate parameter</param>
    /// <param name="endDate">endDate parameter</param>
    /// <param name="categoryId">categoryId parameter</param>
    /// <param name="paymentMethod">paymentMethod parameter</param>
    /// <param name="transactionType">transactionType parameter</param>
    /// <param name="sortBy">sortBy parameter</param>
    /// <param name="ascending">ascending parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Transactions/search")]
    Task<ApiResponse<PaginatedList<TransactionSummaryDto>>> SearchTransactionsAsync([Query, AliasAs("MinAmount")] decimal? minAmount,
                                                                                    [Query, AliasAs("MaxAmount")] decimal? maxAmount,
                                                                                    [Query, AliasAs("StartDate")] DateTimeOffset? startDate,
                                                                                    [Query, AliasAs("EndDate")] DateTimeOffset? endDate,
                                                                                    [Query, AliasAs("CategoryId")] string? categoryId,
                                                                                    [Query, AliasAs("PaymentMethod")] PaymentMethod? paymentMethod,
                                                                                    [Query, AliasAs("TransactionType")] TransactionType? transactionType,
                                                                                    [Query, AliasAs("SortBy")] string? sortBy,
                                                                                    [Query, AliasAs("Ascending")] bool? ascending,
                                                                                    [Query, AliasAs("PageNumber")] int pageNumber,
                                                                                    [Query, AliasAs("PageSize")] int pageSize,
                                                                                    CancellationToken ct);

    /// <summary>
    /// Gets a paginated list of transactions.
    /// </summary>
    /// <param name="pageNumber">The page number to retrieve.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>A <see cref="Task"/> that completes when the request is finished.</returns>
    /// <exception cref="ApiException">Thrown when the request returns a non-success status code.</exception>
    [Get("/api/Transactions/")]
    public Task<ApiResponse<PaginatedList<TransactionSummaryDto>>> GetTransactionsAsync([Query, AliasAs("PageNumber")] int pageNumber,
                                                                                         [Query, AliasAs("PageSize")] int pageSize,
                                                                                         CancellationToken ct);
}