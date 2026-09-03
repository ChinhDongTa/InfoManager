namespace InfoManager.Shared.Dtos.SFMS.Monitoring;

/// <summary>
/// Chi tiết đánh giá sức khỏe cây
/// </summary>
public record CropHealthDto(
    string Id,

    /// <summary>ID lần trồng</summary>
    string CropPlantingId,

    /// <summary>Mã lần trồng</summary>
    string? PlantingCode,

    /// <summary>Tên cây trồng</summary>
    string? CropName,

    /// <summary>Ngày đánh giá</summary>
    DateTimeOffset AssessmentDate,

    /// <summary>Tên tình trạng sức khỏe</summary>
    string? HealthStatusName,

    /// <summary>Tình trạng lá</summary>
    string? LeafCondition,

    /// <summary>Tình trạng thân</summary>
    string? StemCondition,

    /// <summary>Tình trạng rễ</summary>
    string? RootCondition,

    /// <summary>Chiều cao cây (cm)</summary>
    decimal? PlantHeight,

    /// <summary>Mật độ thực vật (%)</summary>
    decimal? VegetationDensity,

    /// <summary>Thiệt hại do sâu (%)</summary>
    decimal? PestDamagePercentage,

    /// <summary>Triệu chứng bệnh</summary>
    string? DiseaseSymptoms,

    /// <summary>Sinh khối ước tính (tấn/ha)</summary>
    decimal? BiomassEstimate,

    /// <summary>Chỉ số diện tích lá (LAI)</summary>
    decimal? LeafAreaIndex,

    /// <summary>Ghi chú</summary>
    string? Notes,

    /// <summary>Việc nên làm tiếp</summary>
    string? RecommendedActions,

    /// <summary>Đường dẫn ảnh</summary>
    string? PhotoUrl,

    DateTimeOffset Created
);

/// <summary>
/// Đánh giá sức khỏe dùng cho danh sách
/// </summary>
public record CropHealthSummaryDto(
    string Id,

    /// <summary>Mã lần trồng</summary>
    string? PlantingCode,

    /// <summary>Tên cây trồng</summary>
    string? CropName,

    /// <summary>Ngày đánh giá</summary>
    DateTimeOffset AssessmentDate,


    /// <summary>Tên tình trạng sức khỏe</summary>
    string? HealthStatusName,

    /// <summary>Thiệt hại do sâu (%)</summary>
    decimal? PestDamagePercentage,

     /// <summary>Việc nên làm tiếp</summary>
    string? RecommendedActions
);

/// <summary>
/// Request tạo đánh giá sức khỏe cây
/// </summary>
public record CreateCropHealthRequest(
    /// <summary>ID lần trồng. Bắt buộc.</summary>
    string CropPlantingId,

    /// <summary>Ngày đánh giá. Bắt buộc.</summary>
    DateTimeOffset AssessmentDate,

    /// <summary>Tình trạng sức khỏe. Bắt buộc.</summary>
    HealthStatus HealthStatus,

    /// <summary>Tình trạng lá. Tối đa 500 ký tự.</summary>
    string? LeafCondition,

    /// <summary>Tình trạng thân. Tối đa 500 ký tự.</summary>
    string? StemCondition,

    /// <summary>Tình trạng rễ. Tối đa 500 ký tự.</summary>
    string? RootCondition,

    /// <summary>Chiều cao cây (cm). ≥ 0.</summary>
    decimal? PlantHeight,

    /// <summary>Mật độ thực vật (%). 0–100.</summary>
    decimal? VegetationDensity,

    /// <summary>Thiệt hại do sâu (%). 0–100.</summary>
    decimal? PestDamagePercentage,

    /// <summary>Triệu chứng bệnh. Tối đa 500 ký tự.</summary>
    string? DiseaseSymptoms,

    /// <summary>Sinh khối ước tính (tấn/ha). ≥ 0.</summary>
    decimal? BiomassEstimate,

    /// <summary>Chỉ số LAI. ≥ 0.</summary>
    decimal? LeafAreaIndex,

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    string? Notes,

    /// <summary>Việc nên làm tiếp. Tối đa 1000 ký tự.</summary>
    string? RecommendedActions,

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    string? PhotoUrl
);

/// <summary>
/// Request cập nhật đánh giá sức khỏe. Field null = không đổi.
/// </summary>
public record UpdateCropHealthRequest(
    /// <summary>ID bản ghi. Bắt buộc.</summary>
    string Id,

    /// <summary>ID lần trồng.</summary>
    string? CropPlantingId,

    /// <summary>Ngày đánh giá.</summary>
    DateTimeOffset? AssessmentDate,

    /// <summary>Tình trạng sức khỏe.</summary>
    HealthStatus? HealthStatus,

    /// <summary>Tình trạng lá. Tối đa 500 ký tự.</summary>
    string? LeafCondition,

    /// <summary>Tình trạng thân. Tối đa 500 ký tự.</summary>
    string? StemCondition,

    /// <summary>Tình trạng rễ. Tối đa 500 ký tự.</summary>
    string? RootCondition,

    /// <summary>Chiều cao cây (cm). ≥ 0.</summary>
    decimal? PlantHeight,

    /// <summary>Mật độ thực vật (%). 0–100.</summary>
    decimal? VegetationDensity,

    /// <summary>Thiệt hại do sâu (%). 0–100.</summary>
    decimal? PestDamagePercentage,

    /// <summary>Triệu chứng bệnh. Tối đa 500 ký tự.</summary>
    string? DiseaseSymptoms,

    /// <summary>Sinh khối ước tính. ≥ 0.</summary>
    decimal? BiomassEstimate,

    /// <summary>Chỉ số LAI. ≥ 0.</summary>
    decimal? LeafAreaIndex,

    /// <summary>Ghi chú. Tối đa 1000 ký tự.</summary>
    string? Notes,

    /// <summary>Việc nên làm tiếp. Tối đa 1000 ký tự.</summary>
    string? RecommendedActions,

    /// <summary>Đường dẫn ảnh. Tối đa 500 ký tự.</summary>
    string? PhotoUrl
);