namespace InfoManager.Shared.Dtos.Common;

/// <summary>
/// Tìm kiếm đơn giản chung cho nhưng entity dựa vào 1 kiểu string để so sánh với nhiều trường kiểu string trong entity
/// </summary>
/// <param name="Term"></param>
/// <param name="PageNumber"></param>
/// <param name="PageSize"></param>
public record SearchTermRequest(
    string? Term,
    int PageNumber,
    int PageSize
    );