namespace InfoManager.Shared.Dtos.SFMS.Issues;

/// <summary>
/// Chi tiết sâu hại
/// </summary>
public record PestDto(
    string Id,

    /// <summary>Tên thông thường</summary>
    string CommonName,

    /// <summary>Tên khoa học</summary>
    string? ScientificName,

    /// <summary>Loại sâu hại</summary>
    string? PestType,

    /// <summary>Mô tả</summary>
    string? Description,

    /// <summary>Cây bị ảnh hưởng</summary>
    string? AffectedCrops,

    /// <summary>Triệu chứng gây hại</summary>
    string? DamageSymptoms,

    /// <summary>Vòng đời</summary>
    string? LifeCycle,

    /// <summary>Biện pháp phòng ngừa</summary>
    string? PreventionMethods,

    /// <summary>Thuốc BVTV khuyến nghị</summary>
    string? RecommendedPesticides,

    /// <summary>Biện pháp sinh học</summary>
    string? BiologicalControl,

    /// <summary>Mức độ nghiêm trọng</summary>
    SeverityLevel? SeverityLevel,

    /// <summary>Tên mức độ nghiêm trọng</summary>
    string? SeverityLevelName,

    /// <summary>Đường dẫn ảnh</summary>
    string? ImageUrl,

    /// <summary>Số vụ nhiễm ghi nhận</summary>
    int InfestationCount,

    DateTimeOffset Created
);

/// <summary>
/// Sâu hại dùng cho danh sách
/// </summary>
public record PestSummaryDto(
    string Id,

    /// <summary>Tên thông thường</summary>
    string CommonName,

    /// <summary>Tên khoa học</summary>
    string? ScientificName,

    /// <summary>Loại sâu hại</summary>
    string? PestType,

    /// <summary>Mức độ nghiêm trọng</summary>
    SeverityLevel? SeverityLevel,

    /// <summary>Tên mức độ nghiêm trọng</summary>
    string? SeverityLevelName
);

/// <summary>
/// Request tạo sâu hại trong danh mục
/// </summary>
public record CreatePestRequest(
    /// <summary>Tên thông thường. Bắt buộc, tối đa 100 ký tự.</summary>
    string CommonName,

    /// <summary>Tên khoa học. Tối đa 200 ký tự.</summary>
    string? ScientificName,

    /// <summary>Loại sâu hại. Tối đa 50 ký tự.</summary>
    string? PestType,

    /// <summary>Mô tả. Tối đa 1000 ký tự.</summary>
    string? Description,

    /// <summary>Cây bị ảnh hưởng. Tối đa 500 ký tự.</summary>
    string? AffectedCrops,

    /// <summary>Triệu chứng gây hại. Tối đa 1000 ký tự.</summary>
    string? DamageSymptoms,

    /// <summary>Vòng đời. Tối đa 1000 ký tự.</summary>
    string? LifeCycle,

    /// <summary>Biện pháp phòng ngừa. Tối đa 1000 ký tự.</summary>
    string? PreventionMethods,

    /// <summary>Thuốc BVTV khuyến nghị. Tối đa 1000 ký tự.</summary>
    string? RecommendedPesticides,

    /// <summary>Biện pháp sinh học. Tối đa 1000 ký tự.</summary>
    string? BiologicalControl,

    /// <summary>Mức độ nghiêm trọng.</summary>
    SeverityLevel? SeverityLevel,

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    string? ImageUrl
);

/// <summary>
/// Request cập nhật sâu hại. Field null = không đổi.
/// </summary>
public record UpdatePestRequest(
    /// <summary>ID sâu hại. Bắt buộc.</summary>
    string Id,

    /// <summary>Tên thông thường. Tối đa 100 ký tự.</summary>
    string? CommonName,

    /// <summary>Tên khoa học. Tối đa 200 ký tự.</summary>
    string? ScientificName,

    /// <summary>Loại sâu hại. Tối đa 50 ký tự.</summary>
    string? PestType,

    /// <summary>Mô tả. Tối đa 1000 ký tự.</summary>
    string? Description,

    /// <summary>Cây bị ảnh hưởng. Tối đa 500 ký tự.</summary>
    string? AffectedCrops,

    /// <summary>Triệu chứng gây hại. Tối đa 1000 ký tự.</summary>
    string? DamageSymptoms,

    /// <summary>Vòng đời. Tối đa 1000 ký tự.</summary>
    string? LifeCycle,

    /// <summary>Biện pháp phòng ngừa. Tối đa 1000 ký tự.</summary>
    string? PreventionMethods,

    /// <summary>Thuốc BVTV khuyến nghị. Tối đa 1000 ký tự.</summary>
    string? RecommendedPesticides,

    /// <summary>Biện pháp sinh học. Tối đa 1000 ký tự.</summary>
    string? BiologicalControl,

    /// <summary>Mức độ nghiêm trọng.</summary>
    SeverityLevel? SeverityLevel,

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    string? ImageUrl
);