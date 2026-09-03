namespace InfoManager.Domain.Entities.Personal;

/// <summary>
/// Theo dõi giá sản phẩm 
/// </summary>
public class PriceTracking : BaseAuditableEntity
{
    /// <summary>
    /// Tên sản phẩm
    /// </summary>
    [MaxLength(200)] 
    public string ProductName { get; set; } = string.Empty;
    /// <summary>
    /// Mô tả sản phẩm
    /// </summary>
    public string? Description { get; set; }               // sách, phân bón, điện thoại...

    /// <summary>
    /// Giá hiện tại của sản phẩm
    /// </summary>
    public decimal CurrentPrice { get; set; }
    /// <summary>
    /// Giá mong muốn của sản phẩm
    /// </summary>
    public decimal? DesiredPrice { get; set; }             // giá mong muốn
    /// <summary>
    /// Giá thấp nhất đã thấy của sản phẩm
    /// </summary>
    public decimal? LowestPriceSeen { get; set; }

    /// <summary>
    /// Tên cửa hàng bán sản phẩm
    /// </summary>
    [MaxLength(200)]
    public string? StoreName { get; set; }                 // Shopee, Tiki, Lazada, Cửa hàng...
    /// <summary>
    /// URL sản phẩm
    /// </summary>
    [MaxLength (300)]
    public string? ProductUrl { get; set; }                // link sản phẩm
    /// <summary>
    /// Trạng thái mua sản phẩm
    /// </summary>
    public bool IsPurchased { get; set; } = false;
    /// <summary>
    /// Ngày kiểm tra giá sản phẩm lần cuối
    /// </summary>
    public DateTimeOffset? LastCheckedDate { get; set; }
}