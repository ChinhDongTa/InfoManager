namespace InfoManager.Shared.Dtos.SFMS.Issues;

/// <summary>
/// Chi tiết bệnh cây trồng
/// </summary>
public record DiseaseDto(
    string Id,

    /// <summary>Tên thông thường</summary>
    string CommonName,

    /// <summary>Tên khoa học</summary>
    string? ScientificName,

    /// <summary>Loại bệnh</summary>
    string? DiseaseType,

    /// <summary>Tác nhân gây bệnh</summary>
    string? CausativeOrganism,

    /// <summary>Cây bị ảnh hưởng</summary>
    string? AffectedCrops,

    /// <summary>Triệu chứng</summary>
    string? Symptoms,

    /// <summary>Điều kiện thuận lợi</summary>
    string? FavorableConditions,

    /// <summary>Con đường lây truyền</summary>
    string? TransmissionMethod,

    /// <summary>Biện pháp phòng ngừa</summary>
    string? PreventionMethods,

    /// <summary>Biện pháp xử lý khuyến nghị</summary>
    string? RecommendedTreatments,

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
/// Bệnh dùng cho danh sách
/// </summary>
public record DiseaseSummaryDto(
    string Id,

    /// <summary>Tên thông thường</summary>
    string CommonName,

    /// <summary>Tên khoa học</summary>
    string? ScientificName,

    /// <summary>Loại bệnh</summary>
    string? DiseaseType,

    /// <summary>Mức độ nghiêm trọng</summary>
    SeverityLevel? SeverityLevel,

    /// <summary>Tên mức độ nghiêm trọng</summary>
    string? SeverityLevelName
);

/// <summary>
/// Request tạo bệnh trong danh mục
/// </summary>
public record CreateDiseaseRequest(
    /// <summary>Tên thông thường. Bắt buộc, tối đa 100 ký tự.</summary>
    string CommonName,

    /// <summary>Tên khoa học. Tối đa 200 ký tự.</summary>
    string? ScientificName,

    /// <summary>Loại bệnh. Tối đa 50 ký tự.</summary>
    string? DiseaseType,

    /// <summary>Tác nhân gây bệnh. Tối đa 200 ký tự.</summary>
    string? CausativeOrganism,

    /// <summary>Cây bị ảnh hưởng. Tối đa 500 ký tự.</summary>
    string? AffectedCrops,

    /// <summary>Triệu chứng. Tối đa 1000 ký tự.</summary>
    string? Symptoms,

    /// <summary>Điều kiện thuận lợi. Tối đa 500 ký tự.</summary>
    string? FavorableConditions,

    /// <summary>Con đường lây truyền. Tối đa 500 ký tự.</summary>
    string? TransmissionMethod,

    /// <summary>Biện pháp phòng ngừa. Tối đa 1000 ký tự.</summary>
    string? PreventionMethods,

    /// <summary>Biện pháp xử lý khuyến nghị. Tối đa 1000 ký tự.</summary>
    string? RecommendedTreatments,

    /// <summary>Mức độ nghiêm trọng.</summary>
    SeverityLevel? SeverityLevel,

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    string? ImageUrl
);

/// <summary>
/// Request cập nhật bệnh. Field null = không đổi.
/// </summary>
public record UpdateDiseaseRequest(
    /// <summary>ID bệnh. Bắt buộc.</summary>
    string Id,

    /// <summary>Tên thông thường. Tối đa 100 ký tự.</summary>
    string? CommonName,

    /// <summary>Tên khoa học. Tối đa 200 ký tự.</summary>
    string? ScientificName,

    /// <summary>Loại bệnh. Tối đa 50 ký tự.</summary>
    string? DiseaseType,

    /// <summary>Tác nhân gây bệnh. Tối đa 200 ký tự.</summary>
    string? CausativeOrganism,

    /// <summary>Cây bị ảnh hưởng. Tối đa 500 ký tự.</summary>
    string? AffectedCrops,

    /// <summary>Triệu chứng. Tối đa 1000 ký tự.</summary>
    string? Symptoms,

    /// <summary>Điều kiện thuận lợi. Tối đa 500 ký tự.</summary>
    string? FavorableConditions,

    /// <summary>Con đường lây truyền. Tối đa 500 ký tự.</summary>
    string? TransmissionMethod,

    /// <summary>Biện pháp phòng ngừa. Tối đa 1000 ký tự.</summary>
    string? PreventionMethods,

    /// <summary>Biện pháp xử lý khuyến nghị. Tối đa 1000 ký tự.</summary>
    string? RecommendedTreatments,

    /// <summary>Mức độ nghiêm trọng.</summary>
    SeverityLevel? SeverityLevel,

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    string? ImageUrl
);
public record SearchDiseasesRequest(string? Term, string? DiseaseType, SeverityLevel? SeverityLevel, int PageNumber, int PageSize);