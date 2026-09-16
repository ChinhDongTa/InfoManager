using InfoManager.Shared.Dtos.PriceTrackings;

namespace InfoManager.ModelClient.PriceTrackings;

public class CreatePriceTrackingModel
{
    /// <summary>
    /// Tên sản phẩm
    /// </summary>
    [MaxLength(200)]
    [Required]
    public string ProductName { get; set; } = string.Empty;                // tên sản phẩm

    /// <summary>
    /// Mô tả sản phẩm
    /// </summary>
    public string? Description { get; set; }               // sách, phân bón, điện thoại...

    /// <summary>
    /// Giá hiện tại của sản phẩm
    /// </summary>
    public decimal? CurrentPrice { get; set; }

    /// <summary>
    /// Giá mong muốn của sản phẩm
    /// </summary>
    [Required]
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
    [MaxLength(300)]
    public string? ProductUrl { get; set; }                // link sản phẩm

    /// <summary>
    /// Trạng thái mua sản phẩm
    /// </summary>
    public bool IsPurchased { get; set; } = false;

    /// <summary>
    /// Ngày kiểm tra giá sản phẩm lần cuối
    /// </summary>
    public DateTimeOffset? LastCheckedDate { get; set; }

    public CreatePriceTrackingRequest CreateRequest()
    {
        return new CreatePriceTrackingRequest
        {
            ProductName = this.ProductName,
            Description = this.Description,
            CurrentPrice = this.CurrentPrice!.Value,
            DesiredPrice = this.DesiredPrice,
            LowestPriceSeen = this.LowestPriceSeen,
            StoreName = this.StoreName,
            ProductUrl = this.ProductUrl,
            IsPurchased = this.IsPurchased,
            LastCheckedDate = this.LastCheckedDate
        };
    }
}