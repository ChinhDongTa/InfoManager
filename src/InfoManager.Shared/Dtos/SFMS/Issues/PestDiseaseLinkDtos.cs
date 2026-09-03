namespace InfoManager.Shared.Dtos.SFMS.Issues;

/// <summary>
/// Chi tiết liên kết sâu hại — bệnh
/// </summary>
public record PestDiseaseLinkDto(
    string Id,

    /// <summary>ID sâu hại</summary>
    string PestId,

    /// <summary>Tên sâu hại</summary>
    string? PestName,

    /// <summary>ID bệnh</summary>
    string DiseaseId,

    /// <summary>Tên bệnh</summary>
    string? DiseaseName,

    /// <summary>Mô tả quan hệ</summary>
    string? RelationshipDescription,

    DateTimeOffset Created
);

/// <summary>
/// Liên kết dùng cho danh sách
/// </summary>
public record PestDiseaseLinkSummaryDto(
    string Id,

    /// <summary>Tên sâu hại</summary>
    string? PestName,

    /// <summary>Tên bệnh</summary>
    string? DiseaseName,

    /// <summary>Mô tả quan hệ</summary>
    string? RelationshipDescription
);

/// <summary>
/// Request tạo liên kết sâu hại — bệnh
/// </summary>
public record CreatePestDiseaseLinkRequest(
    /// <summary>ID sâu hại. Bắt buộc.</summary>
    string PestId,

    /// <summary>ID bệnh. Bắt buộc.</summary>
    string DiseaseId,

    /// <summary>Mô tả quan hệ. Tối đa 500 ký tự.</summary>
    string? RelationshipDescription
);

/// <summary>
/// Request cập nhật liên kết. Field null = không đổi.
/// </summary>
public record UpdatePestDiseaseLinkRequest(
    /// <summary>ID liên kết. Bắt buộc.</summary>
    string Id,

    /// <summary>ID sâu hại.</summary>
    string? PestId,

    /// <summary>ID bệnh.</summary>
    string? DiseaseId,

    /// <summary>Mô tả quan hệ. Tối đa 500 ký tự.</summary>
    string? RelationshipDescription
);