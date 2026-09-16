using InfoManager.Shared.Dtos.Categories;

namespace InfoManager.ModelClient.Categories;

public class CreateCategoryModel
{
    [MaxLength(200)]
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Nhóm phân loại, ví dụ: "Kinh nghiệm", "Ý định", "Giao dịch"
    /// </summary>
    [MaxLength(50)]
    public string? Group { get; set; }

    /// <summary>
    /// Tên khóa phân loại group, ví dụ: "Kinh-Nghiem", "Y-Dinh", "Giao-Dich"
    /// </summary>
    [MaxLength(50)]
    public string? KeyName { get; set; }

    /// <summary>
    /// Tạo một đối tượng CreateCategoryRequest từ CreateCategoryModel để gửi đến API
    /// </summary>
    /// <returns></returns>
    public CreateCategoryRequest CreateRequest()
    {
        return new CreateCategoryRequest
        {
            Name = this.Name,
            Group = this.Group,
            KeyName = this.KeyName
        };
    }
}