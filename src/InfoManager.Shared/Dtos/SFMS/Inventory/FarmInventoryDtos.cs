namespace InfoManager.Shared.Dtos.SFMS.Inventory;

/// <summary>
/// Chi tiết tồn kho vật tư (một lô trong nông trại).
/// </summary>
public record FarmInventoryDto(
    string Id,

    /// <summary>ID nông trại</summary>
    string FarmId,

    /// <summary>Tên nông trại</summary>
    string? FarmName,

    /// <summary>Tên vật tư</summary>
    string ResourceName,

    /// <summary>Nhóm vật tư</summary>
    ResourceType ResourceType,

    /// <summary>ID phân bón (nếu là phân)</summary>
    string? FertilizerId,

    /// <summary>Tên phân bón</summary>
    string? FertilizerName,

    /// <summary>ID thuốc BVTV (nếu là thuốc)</summary>
    string? PesticideId,

    /// <summary>Tên thuốc BVTV</summary>
    string? PesticideName,
    /// <summary>ID giống cây (nếu là hạt giống / cây giống).</summary>
    string? CropVarietyId,
    /// <summary>Tên giống cây (nếu là hạt giống / cây giống).</summary>
    string? CropVarietyName,

    /// <summary>Thương hiệu / nhà sản xuất</summary>
    string? Brand,

    /// <summary>Số lượng tồn hiện tại</summary>
    decimal CurrentQuantity,

    /// <summary>Đơn vị tính</summary>
    string Unit,

    /// <summary>Tồn tối thiểu để cảnh báo</summary>
    decimal? MinQuantity,

    /// <summary>Tồn tối đa</summary>
    decimal? MaxQuantity,

    /// <summary>Đơn giá</summary>
    decimal? CostPerUnit,

    /// <summary>Vị trí lưu kho</summary>
    string? StorageLocation,

    /// <summary>Hạn sử dụng</summary>
    DateOnly? ExpiryDate,

    /// <summary>Số lô</summary>
    string? BatchNumber,

    /// <summary>Ngày nhập / mua</summary>
    DateTimeOffset? PurchaseDate,

    /// <summary>Nhà cung cấp</summary>
    string? Supplier,

    /// <summary>Chứng nhận (Organic, ISO...)</summary>
    string? Certification,

    /// <summary>Quy cách / mô tả kỹ thuật</summary>
    string? Specification,

    /// <summary>Ghi chú</summary>
    string? Notes,

    /// <summary>Còn sử dụng hay không</summary>
    bool IsActive,

    DateTimeOffset Created
);

/// <summary>
/// Tồn kho dùng cho danh sách.
/// </summary>
public record FarmInventorySummaryDto(
    string Id,

    /// <summary>Tên vật tư</summary>
    string ResourceName,

    /// <summary>Nhóm vật tư</summary>
    ResourceType ResourceType,

    /// <summary>Tên thuốc BVTV hoặc phân bón hoặc giống cây</summary>
    string? Name,

    /// <summary>Số lượng tồn hiện tại</summary>
    decimal CurrentQuantity,

    /// <summary>Đơn vị tính</summary>
    string Unit,

    /// <summary>Tồn tối thiểu</summary>
    decimal? MinQuantity,

    /// <summary>Hạn sử dụng</summary>
    DateOnly? ExpiryDate,

    /// <summary>Số lô</summary>
    string? BatchNumber,

    /// <summary>Còn sử dụng hay không</summary>
    bool IsActive
);

public record SearchFarmInventoryRequest(
    /// <summary>Tên vật tư. Bắt buộc, tối đa 200 ký tự.</summary>
    string? Tern,

    /// <summary>Nhóm vật tư. Bắt buộc.</summary>
    ResourceType? ResourceType,

    /// <summary>Số lượng.</summary>
    decimal? Quantity,

    /// <summary>Hạn sử dụng. Không được trước ngày mua nếu có PurchaseDate.</summary>
    DateOnly? ExpiryDate,

    DateTimeOffset? StartCreated,
    DateTimeOffset? EndCreated
    );

/// <summary>
/// Request tạo mới một lô tồn kho.
/// </summary>
public record CreateFarmInventoryRequest(
    /// <summary>ID nông trại. Bắt buộc.</summary>
    string FarmId,

    /// <summary>Tên vật tư. Bắt buộc, tối đa 200 ký tự.</summary>
    string ResourceName,

    /// <summary>Nhóm vật tư. Bắt buộc.</summary>
    ResourceType ResourceType,

    /// <summary>Đơn vị tính. Bắt buộc, tối đa 50 ký tự.</summary>
    string Unit,

    /// <summary>ID phân bón. Bắt buộc nếu ResourceType = Fertilizer.</summary>
    string? FertilizerId,

    /// <summary>ID thuốc BVTV. Bắt buộc nếu ResourceType = Pesticide.</summary>
    string? PesticideId,

    /// <summary>ID giống cây (nếu là hạt giống / cây giống).</summary>
    string? CropVarietyId,

    /// <summary>Thương hiệu. Tối đa 200 ký tự.</summary>
    string? Brand,

    /// <summary>Số lượng tồn. Mặc định 0, không âm.</summary>
    decimal CurrentQuantity,

    /// <summary>Tồn tối thiểu để cảnh báo. Không âm. Phải ≤ MaxQuantity nếu cả hai có giá trị.</summary>
    decimal? MinQuantity,

    /// <summary>Tồn tối đa. Không âm.</summary>
    decimal? MaxQuantity,

    /// <summary>Đơn giá. Không âm.</summary>
    decimal? CostPerUnit,

    /// <summary>Vị trí lưu kho. Tối đa 200 ký tự.</summary>
    string? StorageLocation,

    /// <summary>Hạn sử dụng. Không được trước ngày mua nếu có PurchaseDate.</summary>
    DateOnly? ExpiryDate,

    /// <summary>Số lô. Tối đa 100 ký tự.</summary>
    string? BatchNumber,

    /// <summary>Ngày nhập / mua.</summary>
    DateTimeOffset? PurchaseDate,

    /// <summary>Nhà cung cấp. Tối đa 200 ký tự.</summary>
    string? Supplier,

    /// <summary>Chứng nhận. Tối đa 200 ký tự.</summary>
    string? Certification,

    /// <summary>Quy cách. Tối đa 500 ký tự.</summary>
    string? Specification,

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    string? Notes,

    /// <summary>Còn sử dụng hay không. Mặc định true.</summary>
    bool IsActive = true
);

/// <summary>
/// Request cập nhật tồn kho. Field null = không đổi.
/// </summary>
public record UpdateFarmInventoryRequest(
    /// <summary>ID tồn kho. Bắt buộc.</summary>
    string Id,

    /// <summary>ID nông trại.</summary>
    string? FarmId,

    /// <summary>Tên vật tư. Tối đa 200 ký tự.</summary>
    string? ResourceName,

    /// <summary>Nhóm vật tư.</summary>
    ResourceType? ResourceType,

    /// <summary>ID phân bón. Bắt buộc nếu ResourceType = Fertilizer.</summary>
    string? FertilizerId,

    /// <summary>ID thuốc BVTV. Bắt buộc nếu ResourceType = Pesticide.</summary>
    string? PesticideId,

    /// <summary>ID giống cây (nếu là hạt giống / cây giống).</summary>
    string? CropVarietyId,

    /// <summary>Thương hiệu. Tối đa 200 ký tự.</summary>
    string? Brand,

    /// <summary>Số lượng tồn. Không âm.</summary>
    decimal? CurrentQuantity,

    /// <summary>Đơn vị tính. Tối đa 50 ký tự.</summary>
    string? Unit,

    /// <summary>Tồn tối thiểu. Không âm.</summary>
    decimal? MinQuantity,

    /// <summary>Tồn tối đa. Không âm.</summary>
    decimal? MaxQuantity,

    /// <summary>Đơn giá. Không âm.</summary>
    decimal? CostPerUnit,

    /// <summary>Vị trí lưu kho. Tối đa 200 ký tự.</summary>
    string? StorageLocation,

    /// <summary>Hạn sử dụng.</summary>
    DateOnly? ExpiryDate,

    /// <summary>Số lô. Tối đa 100 ký tự.</summary>
    string? BatchNumber,

    /// <summary>Ngày nhập / mua.</summary>
    DateTimeOffset? PurchaseDate,

    /// <summary>Nhà cung cấp. Tối đa 200 ký tự.</summary>
    string? Supplier,

    /// <summary>Chứng nhận. Tối đa 200 ký tự.</summary>
    string? Certification,

    /// <summary>Quy cách. Tối đa 500 ký tự.</summary>
    string? Specification,

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    string? Notes,

    /// <summary>Còn sử dụng hay không.</summary>
    bool? IsActive
);