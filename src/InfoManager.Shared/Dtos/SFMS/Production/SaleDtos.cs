namespace InfoManager.Shared.Dtos.SFMS.Production;

/// <summary>
/// Chi tiết đơn bán
/// </summary>
public record SaleDto(
    string Id,

    /// <summary>ID sản phẩm</summary>
    string ProductId,

    /// <summary>Tên sản phẩm</summary>
    string? ProductName,

    /// <summary>Đơn vị sản phẩm</summary>
    string? ProductUnit,

    /// <summary>Ngày bán</summary>
    DateTimeOffset SaleDate,

    /// <summary>Tên người mua</summary>
    string BuyerName,

    /// <summary>Số lượng bán</summary>
    decimal QuantitySold,

    /// <summary>Đơn giá</summary>
    decimal UnitPrice,

    /// <summary>Thành tiền trước chiết khấu</summary>
    decimal TotalAmount,

    /// <summary>Chiết khấu (%)</summary>
    decimal? DiscountPercentage,

    /// <summary>Số tiền thực nhận</summary>
    decimal NetAmount,

    /// <summary>Kênh bán</summary>
    string? SaleChannel,

    /// <summary>Trạng thái thanh toán</summary>
    PaymentStatus PaymentStatus,

    /// <summary>Tên trạng thái thanh toán</summary>
    string? PaymentStatusName,

    /// <summary>Ngày thanh toán</summary>
    DateTimeOffset? PaymentDate,

    /// <summary>Số hóa đơn</summary>
    string? InvoiceNumber,

    /// <summary>Ghi chú</summary>
    string? Notes,

    DateTimeOffset Created
);

/// <summary>
/// Đơn bán dùng cho danh sách
/// </summary>
public record SaleSummaryDto(
    string Id,

    /// <summary>Tên sản phẩm</summary>
    string? ProductName,

    /// <summary>Ngày bán</summary>
    DateTimeOffset SaleDate,

    /// <summary>Tên người mua</summary>
    string BuyerName,

    /// <summary>Số lượng bán</summary>
    decimal QuantitySold,

    /// <summary>Số tiền thực nhận</summary>
    decimal NetAmount,

    /// <summary>Trạng thái thanh toán</summary>
    PaymentStatus PaymentStatus,

    /// <summary>Tên trạng thái thanh toán</summary>
    string? PaymentStatusName
);

/// <summary>
/// Request tạo đơn bán
/// </summary>
public record CreateSaleRequest(
    /// <summary>ID sản phẩm. Bắt buộc.</summary>
    string ProductId,

    /// <summary>Ngày bán. Bắt buộc.</summary>
    DateTimeOffset SaleDate,

    /// <summary>Tên người mua. Bắt buộc, tối đa 200 ký tự.</summary>
    string BuyerName,

    /// <summary>Số lượng bán. Bắt buộc, > 0, không vượt tồn sản phẩm.</summary>
    decimal QuantitySold,

    /// <summary>Đơn giá. Bắt buộc, ≥ 0.</summary>
    decimal UnitPrice,

    /// <summary>Thành tiền. Để trống thì server tính = QuantitySold × UnitPrice.</summary>
    decimal? TotalAmount,

    /// <summary>Chiết khấu (%). 0–100.</summary>
    decimal? DiscountPercentage,

    /// <summary>Thực nhận. Để trống thì server tính = TotalAmount × (1 - DiscountPercentage/100).</summary>
    decimal? NetAmount,

    /// <summary>Kênh bán. Tối đa 50 ký tự.</summary>
    string? SaleChannel,

    /// <summary>Trạng thái thanh toán. Mặc định Pending.</summary>
    PaymentStatus PaymentStatus = PaymentStatus.Pending,

    /// <summary>Ngày thanh toán. Bắt buộc nếu PaymentStatus = Paid.</summary>
    DateTimeOffset? PaymentDate = null,

    /// <summary>Số hóa đơn. Tối đa 100 ký tự.</summary>
    string? InvoiceNumber = null,

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    string? Notes = null
);

/// <summary>
/// Request cập nhật đơn bán. Field null = không đổi.
/// </summary>
public record UpdateSaleRequest(
    /// <summary>ID đơn bán. Bắt buộc.</summary>
    string Id,

    /// <summary>ID sản phẩm.</summary>
    string? ProductId,

    /// <summary>Ngày bán.</summary>
    DateTimeOffset? SaleDate,

    /// <summary>Tên người mua. Tối đa 200 ký tự.</summary>
    string? BuyerName,

    /// <summary>Số lượng bán. > 0.</summary>
    decimal? QuantitySold,

    /// <summary>Đơn giá. ≥ 0.</summary>
    decimal? UnitPrice,

    /// <summary>Thành tiền. Để trống thì server tính lại nếu số lượng hoặc đơn giá đổi.</summary>
    decimal? TotalAmount,

    /// <summary>Chiết khấu (%). 0–100.</summary>
    decimal? DiscountPercentage,

    /// <summary>Thực nhận. Để trống thì server tính lại.</summary>
    decimal? NetAmount,

    /// <summary>Kênh bán. Tối đa 50 ký tự.</summary>
    string? SaleChannel,

    /// <summary>Trạng thái thanh toán.</summary>
    PaymentStatus? PaymentStatus,

    /// <summary>Ngày thanh toán.</summary>
    DateTimeOffset? PaymentDate,

    /// <summary>Số hóa đơn. Tối đa 100 ký tự.</summary>
    string? InvoiceNumber,

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    string? Notes
);
public record SearchSalesRequest(string? Term, string? ProductId, PaymentStatus? PaymentStatus, int PageNumber, int PageSize);