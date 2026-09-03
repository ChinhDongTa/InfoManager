namespace InfoManager.Shared.Dtos.SFMS.Production;

/// <summary>
/// Chi tiết sản phẩm sau thu hoạch
/// </summary>
public record ProductDto(
    string Id,

    /// <summary>ID đợt thu hoạch</summary>
    string HarvestId,

    /// <summary>Ngày thu hoạch</summary>
    DateTimeOffset? HarvestDate,

    /// <summary>Mã lần trồng</summary>
    string? PlantingCode,

    /// <summary>Tên sản phẩm</summary>
    string ProductName,

    /// <summary>Mô tả</summary>
    string? Description,

    /// <summary>Hình thức chế biến</summary>
    string? ProcessingType,

    /// <summary>Số lượng</summary>
    decimal Quantity,

    /// <summary>Đơn vị</summary>
    string Unit,

    /// <summary>Vị trí lưu kho</summary>
    string? StorageLocation,

    /// <summary>Hạn sử dụng</summary>
    DateTimeOffset? ExpiryDate,

    /// <summary>Giá vốn / đơn vị</summary>
    decimal? CostPerUnit,

    /// <summary>Giá bán / đơn vị</summary>
    decimal? SellingPrice,

    /// <summary>Thành tiền</summary>
    decimal? TotalValue,

    /// <summary>Trạng thái</summary>
    ProductStatus Status,

    /// <summary>Tên trạng thái</summary>
    string? StatusName,

    /// <summary>Chứng nhận</summary>
    string? Certification,

    /// <summary>Ghi chú</summary>
    string? Notes,

    DateTimeOffset Created
);

/// <summary>
/// Sản phẩm dùng cho danh sách
/// </summary>
public record ProductSummaryDto(
    string Id,

    /// <summary>Tên sản phẩm</summary>
    string ProductName,

    /// <summary>Mã lần trồng</summary>
    string? PlantingCode,

    /// <summary>Số lượng</summary>
    decimal Quantity,

    /// <summary>Đơn vị</summary>
    string Unit,

    /// <summary>Giá bán / đơn vị</summary>
    decimal? SellingPrice,

    /// <summary>Trạng thái</summary>
    ProductStatus Status,

    /// <summary>Tên trạng thái</summary>
    string? StatusName,

    /// <summary>Hạn sử dụng</summary>
    DateTimeOffset? ExpiryDate
);

/// <summary>
/// Request tạo sản phẩm từ đợt thu hoạch
/// </summary>
public record CreateProductRequest(
    /// <summary>ID đợt thu hoạch. Bắt buộc.</summary>
    string HarvestId,

    /// <summary>Tên sản phẩm. Bắt buộc, tối đa 200 ký tự.</summary>
    string ProductName,

    /// <summary>Mô tả. Tối đa 500 ký tự.</summary>
    string? Description,

    /// <summary>Hình thức chế biến. Tối đa 50 ký tự.</summary>
    string? ProcessingType,

    /// <summary>Số lượng. Bắt buộc, > 0.</summary>
    decimal Quantity,

    /// <summary>Đơn vị. Bắt buộc, tối đa 50 ký tự.</summary>
    string Unit,

    /// <summary>Vị trí lưu kho. Tối đa 200 ký tự.</summary>
    string? StorageLocation,

    /// <summary>Hạn sử dụng.</summary>
    DateTimeOffset? ExpiryDate,

    /// <summary>Giá vốn / đơn vị. Không âm.</summary>
    decimal? CostPerUnit,

    /// <summary>Giá bán / đơn vị. Không âm.</summary>
    decimal? SellingPrice,

    /// <summary>Thành tiền. Để trống thì server tính = Quantity × SellingPrice.</summary>
    decimal? TotalValue,

    /// <summary>Trạng thái. Mặc định Available.</summary>
    ProductStatus Status = ProductStatus.Available,

    /// <summary>Chứng nhận. Tối đa 200 ký tự.</summary>
    string? Certification = null,

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    string? Notes = null
);

/// <summary>
/// Request cập nhật sản phẩm. Field null = không đổi.
/// </summary>
public record UpdateProductRequest(
    /// <summary>ID sản phẩm. Bắt buộc.</summary>
    string Id,

    /// <summary>ID đợt thu hoạch.</summary>
    string? HarvestId,

    /// <summary>Tên sản phẩm. Tối đa 200 ký tự.</summary>
    string? ProductName,

    /// <summary>Mô tả. Tối đa 500 ký tự.</summary>
    string? Description,

    /// <summary>Hình thức chế biến. Tối đa 50 ký tự.</summary>
    string? ProcessingType,

    /// <summary>Số lượng. > 0.</summary>
    decimal? Quantity,

    /// <summary>Đơn vị. Tối đa 50 ký tự.</summary>
    string? Unit,

    /// <summary>Vị trí lưu kho. Tối đa 200 ký tự.</summary>
    string? StorageLocation,

    /// <summary>Hạn sử dụng.</summary>
    DateTimeOffset? ExpiryDate,

    /// <summary>Giá vốn / đơn vị. Không âm.</summary>
    decimal? CostPerUnit,

    /// <summary>Giá bán / đơn vị. Không âm.</summary>
    decimal? SellingPrice,

    /// <summary>Thành tiền. Để trống thì server tính lại nếu Quantity hoặc SellingPrice đổi.</summary>
    decimal? TotalValue,

    /// <summary>Trạng thái.</summary>
    ProductStatus? Status,

    /// <summary>Chứng nhận. Tối đa 200 ký tự.</summary>
    string? Certification,

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    string? Notes
);