using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Production;

namespace InfoManager.ModelClient.SFMS.Production;

public class UpdateProductModel
{
    /// <summary>ID sản phẩm. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>ID đợt thu hoạch.</summary>
    public string? HarvestId { get; set; }

    /// <summary>Tên sản phẩm. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? ProductName { get; set; }

    /// <summary>Mô tả. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>Hình thức chế biến. Tối đa 50 ký tự.</summary>
    [MaxLength(50)]
    public string? ProcessingType { get; set; }

    /// <summary>Số lượng. > 0.</summary>
    [Range(typeof(decimal), "0.0000001", "79228162514264337593543950335")]
    public decimal? Quantity { get; set; }

    /// <summary>Đơn vị. Tối đa 50 ký tự.</summary>
    [MaxLength(50)]
    public string? Unit { get; set; }

    /// <summary>Vị trí lưu kho. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? StorageLocation { get; set; }

    /// <summary>Hạn sử dụng.</summary>
    public DateTimeOffset? ExpiryDate { get; set; }

    /// <summary>Giá vốn / đơn vị. Không âm.</summary>
    [Range(0, double.MaxValue)]
    public decimal? CostPerUnit { get; set; }

    /// <summary>Giá bán / đơn vị. Không âm.</summary>
    [Range(0, double.MaxValue)]
    public decimal? SellingPrice { get; set; }

    /// <summary>Thành tiền.</summary>
    public decimal? TotalValue { get; set; }

    /// <summary>Trạng thái.</summary>
    public ProductStatus? Status { get; set; }

    /// <summary>Chứng nhận. Tối đa 200 ký tự.</summary>
    [MaxLength(200)]
    public string? Certification { get; set; }

    /// <summary>Ghi chú. Tối đa 500 ký tự.</summary>
    [MaxLength(500)]
    public string? Notes { get; set; }

    public UpdateProductModel(string id, ProductDto dto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(dto);

        Id = id;
        HarvestId = dto.HarvestId;
        ProductName = dto.ProductName;
        Description = dto.Description;
        ProcessingType = dto.ProcessingType;
        Quantity = dto.Quantity;
        Unit = dto.Unit;
        StorageLocation = dto.StorageLocation;
        ExpiryDate = dto.ExpiryDate;
        CostPerUnit = dto.CostPerUnit;
        SellingPrice = dto.SellingPrice;
        TotalValue = dto.TotalValue;
        Status = dto.Status;
        Certification = dto.Certification;
        Notes = dto.Notes;
    }

    public UpdateProductRequest CreateRequest()
    {
        return new UpdateProductRequest
        (
            Id: this.Id,
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

    public bool HasChanges(UpdateProductModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}
