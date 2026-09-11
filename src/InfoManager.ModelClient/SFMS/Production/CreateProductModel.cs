using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ModelClient.SFMS.Production;

public class CreateProductModel
{
    /// <summary>
    /// ID đợt thu hoạch
    /// </summary>
    [Required]
    public string HarvestId { get; set; } = string.Empty;

    /// <summary>
    /// Tên sản phẩm
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Mô tả
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// Hình thức chế biến
    /// </summary>
    [MaxLength(50)]
    public string? ProcessingType { get; set; }

    /// <summary>
    /// Số lượng
    /// </summary>
    [Required]
    [Range(typeof(decimal), "0.0000001", "79228162514264337593543950335")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Đơn vị
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string Unit { get; set; } = string.Empty;

    /// <summary>
    /// Vị trí lưu kho
    /// </summary>
    [MaxLength(200)]
    public string? StorageLocation { get; set; }

    /// <summary>
    /// Hạn sử dụng
    /// </summary>
    public DateTimeOffset? ExpiryDate { get; set; }

    /// <summary>
    /// Giá vốn / đơn vị
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? CostPerUnit { get; set; }

    /// <summary>
    /// Giá bán / đơn vị
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal? SellingPrice { get; set; }

    /// <summary>
    /// Thành tiền
    /// </summary>
    public decimal? TotalValue { get; set; }

    /// <summary>
    /// Trạng thái
    /// </summary>
    public ProductStatus Status { get; set; } = ProductStatus.Available;

    /// <summary>
    /// Chứng nhận
    /// </summary>
    [MaxLength(200)]
    public string? Certification { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public CreateProductRequest CreateRequest()
    {
        return new CreateProductRequest
        (
            HarvestId: this.HarvestId,
            ProductName: this.ProductName,
            Description: this.Description,
            ProcessingType: this.ProcessingType,
            Quantity: this.Quantity,
            Unit: this.Unit,
            StorageLocation: this.StorageLocation,
            ExpiryDate: this.ExpiryDate,
            CostPerUnit: this.CostPerUnit,
            SellingPrice: this.SellingPrice,
            TotalValue: this.TotalValue,
            Status: this.Status,
            Certification: this.Certification,
            Notes: this.Notes
        );
    }
}