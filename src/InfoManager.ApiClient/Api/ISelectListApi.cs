namespace InfoManager.ApiClient.Api;

/// <summary>
/// Giao diện API để lấy danh sách các giá trị của Enum, kiểu selectList (cặp key-value thường là của khóa ngoại) từ server.
/// </summary>
public interface ISelectListApi
{
    /// <param name="enumName">enumName parameter</param>
    /// <returns>A <see cref="Task"/> representing the result of the request.</returns>
    /// <exception cref="ApiException">
    /// Thrown when the request returns a non-success status code:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>404</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </exception>
    [Headers("Accept: application/json")]
    [Get("/api/Enums/{enumName}")]
    Task<ApiResponse<IEnumerable<SelectListItemDto>>> GetEnumValues(string enumName, CancellationToken ct);
}