namespace InfoManager.Shared.Dtos.SFMS.Monitoring;

/// <summary>
/// Chi tiết phân tích đất
/// </summary>
public record SoilAnalysisDto(
    string Id,

    /// <summary>ID thửa ruộng</summary>
    string FieldId,

    /// <summary>Tên thửa ruộng</summary>
    string? FieldName,

    /// <summary>ID nông trại</summary>
    string? FarmId,

    /// <summary>Tên nông trại</summary>
    string? FarmName,

    /// <summary>Ngày phân tích</summary>
    DateTimeOffset AnalysisDate,

    /// <summary>Tên phòng thí nghiệm</summary>
    string? LabName,

    /// <summary>Độ sâu lấy mẫu (cm)</summary>
    decimal? SamplingDepth,

    /// <summary>pH đất</summary>
    decimal? PH,

    /// <summary>Độ dẫn điện (dS/m)</summary>
    decimal? ElectricalConductivity,

    /// <summary>Đạm (mg/kg)</summary>
    decimal? Nitrogen,

    /// <summary>Lân (mg/kg)</summary>
    decimal? Phosphorus,

    /// <summary>Kali (mg/kg)</summary>
    decimal? Potassium,

    /// <summary>Canxi (mg/kg)</summary>
    decimal? Calcium,

    /// <summary>Magie (mg/kg)</summary>
    decimal? Magnesium,

    /// <summary>Lưu huỳnh (mg/kg)</summary>
    decimal? Sulfur,

    /// <summary>Chất hữu cơ (%)</summary>
    decimal? OrganicMatter,

    /// <summary>Sắt (mg/kg)</summary>
    decimal? Iron,

    /// <summary>Mangan (mg/kg)</summary>
    decimal? Manganese,

    /// <summary>Kẽm (mg/kg)</summary>
    decimal? Zinc,

    /// <summary>Đồng (mg/kg)</summary>
    decimal? Copper,

    /// <summary>Bo (mg/kg)</summary>
    decimal? Boron,

    /// <summary>CEC (meq/100g)</summary>
    decimal? CationExchangeCapacity,

    /// <summary>Cát (%)</summary>
    decimal? SandPercentage,

    /// <summary>Thịt (%)</summary>
    decimal? SiltPercentage,

    /// <summary>Sét (%)</summary>
    decimal? ClayPercentage,

    /// <summary>Đường dẫn báo cáo</summary>
    string? ReportUrl,

    /// <summary>Nhận xét phòng thí nghiệm</summary>
    string? LabRemarks,

    /// <summary>Khuyến nghị</summary>
    string? Recommendations,

    DateTimeOffset Created
);

/// <summary>
/// Phân tích đất dùng cho danh sách
/// </summary>
public record SoilAnalysisSummaryDto(
    string Id,

    /// <summary>Tên thửa ruộng</summary>
    string? FieldName,

    /// <summary>Ngày phân tích</summary>
    DateTimeOffset AnalysisDate,

    /// <summary>pH đất</summary>
    decimal? PH,

    /// <summary>Đạm (mg/kg)</summary>
    decimal? Nitrogen,

    /// <summary>Lân (mg/kg)</summary>
    decimal? Phosphorus,

    /// <summary>Kali (mg/kg)</summary>
    decimal? Potassium,

    /// <summary>Chất hữu cơ (%)</summary>
    decimal? OrganicMatter
);

/// <summary>
/// Request tạo kết quả phân tích đất
/// </summary>
public record CreateSoilAnalysisRequest(
    /// <summary>ID thửa ruộng. Bắt buộc.</summary>
    string FieldId,

    /// <summary>Ngày phân tích. Bắt buộc.</summary>
    DateTimeOffset AnalysisDate,

    /// <summary>Tên phòng thí nghiệm. Tối đa 200 ký tự.</summary>
    string? LabName,

    /// <summary>Độ sâu lấy mẫu (cm). ≥ 0.</summary>
    decimal? SamplingDepth,

    /// <summary>pH đất. Thường 0–14.</summary>
    decimal? PH,

    /// <summary>Độ dẫn điện (dS/m). ≥ 0.</summary>
    decimal? ElectricalConductivity,

    /// <summary>Đạm (mg/kg). ≥ 0.</summary>
    decimal? Nitrogen,

    /// <summary>Lân (mg/kg). ≥ 0.</summary>
    decimal? Phosphorus,

    /// <summary>Kali (mg/kg). ≥ 0.</summary>
    decimal? Potassium,

    /// <summary>Canxi (mg/kg). ≥ 0.</summary>
    decimal? Calcium,

    /// <summary>Magie (mg/kg). ≥ 0.</summary>
    decimal? Magnesium,

    /// <summary>Lưu huỳnh (mg/kg). ≥ 0.</summary>
    decimal? Sulfur,

    /// <summary>Chất hữu cơ (%). 0–100.</summary>
    decimal? OrganicMatter,

    /// <summary>Sắt (mg/kg). ≥ 0.</summary>
    decimal? Iron,

    /// <summary>Mangan (mg/kg). ≥ 0.</summary>
    decimal? Manganese,

    /// <summary>Kẽm (mg/kg). ≥ 0.</summary>
    decimal? Zinc,

    /// <summary>Đồng (mg/kg). ≥ 0.</summary>
    decimal? Copper,

    /// <summary>Bo (mg/kg). ≥ 0.</summary>
    decimal? Boron,

    /// <summary>CEC (meq/100g). ≥ 0.</summary>
    decimal? CationExchangeCapacity,

    /// <summary>Cát (%). 0–100. Tổng cát + thịt + sét nên ≈ 100 nếu cả ba có giá trị.</summary>
    decimal? SandPercentage,

    /// <summary>Thịt (%). 0–100.</summary>
    decimal? SiltPercentage,

    /// <summary>Sét (%). 0–100.</summary>
    decimal? ClayPercentage,

    /// <summary>Đường dẫn báo cáo. Tối đa 500 ký tự.</summary>
    string? ReportUrl,

    /// <summary>Nhận xét phòng thí nghiệm. Tối đa 1000 ký tự.</summary>
    string? LabRemarks,

    /// <summary>Khuyến nghị. Tối đa 1000 ký tự.</summary>
    string? Recommendations
);

/// <summary>
/// Request cập nhật phân tích đất. Field null = không đổi.
/// </summary>
public record UpdateSoilAnalysisRequest(
    /// <summary>ID bản ghi. Bắt buộc.</summary>
    string Id,

    /// <summary>ID thửa ruộng.</summary>
    string? FieldId,

    /// <summary>Ngày phân tích.</summary>
    DateTimeOffset? AnalysisDate,

    /// <summary>Tên phòng thí nghiệm. Tối đa 200 ký tự.</summary>
    string? LabName,

    /// <summary>Độ sâu lấy mẫu (cm). ≥ 0.</summary>
    decimal? SamplingDepth,

    /// <summary>pH đất. 0–14.</summary>
    decimal? PH,

    /// <summary>Độ dẫn điện (dS/m). ≥ 0.</summary>
    decimal? ElectricalConductivity,

    /// <summary>Đạm (mg/kg). ≥ 0.</summary>
    decimal? Nitrogen,

    /// <summary>Lân (mg/kg). ≥ 0.</summary>
    decimal? Phosphorus,

    /// <summary>Kali (mg/kg). ≥ 0.</summary>
    decimal? Potassium,

    /// <summary>Canxi (mg/kg). ≥ 0.</summary>
    decimal? Calcium,

    /// <summary>Magie (mg/kg). ≥ 0.</summary>
    decimal? Magnesium,

    /// <summary>Lưu huỳnh (mg/kg). ≥ 0.</summary>
    decimal? Sulfur,

    /// <summary>Chất hữu cơ (%). 0–100.</summary>
    decimal? OrganicMatter,

    /// <summary>Sắt (mg/kg). ≥ 0.</summary>
    decimal? Iron,

    /// <summary>Mangan (mg/kg). ≥ 0.</summary>
    decimal? Manganese,

    /// <summary>Kẽm (mg/kg). ≥ 0.</summary>
    decimal? Zinc,

    /// <summary>Đồng (mg/kg). ≥ 0.</summary>
    decimal? Copper,

    /// <summary>Bo (mg/kg). ≥ 0.</summary>
    decimal? Boron,

    /// <summary>CEC (meq/100g). ≥ 0.</summary>
    decimal? CationExchangeCapacity,

    /// <summary>Cát (%). 0–100.</summary>
    decimal? SandPercentage,

    /// <summary>Thịt (%). 0–100.</summary>
    decimal? SiltPercentage,

    /// <summary>Sét (%). 0–100.</summary>
    decimal? ClayPercentage,

    /// <summary>Đường dẫn báo cáo. Tối đa 500 ký tự.</summary>
    string? ReportUrl,

    /// <summary>Nhận xét phòng thí nghiệm. Tối đa 1000 ký tự.</summary>
    string? LabRemarks,

    /// <summary>Khuyến nghị. Tối đa 1000 ký tự.</summary>
    string? Recommendations
);