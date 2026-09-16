using InfoManager.Shared.Dtos.Categories;

namespace InfoManager.ModelClient.Categories;

public class UpdateCategoryModel
{
    public string Id { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Name { get; set; }

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
    /// Chỉ 1 constructor để tạo UpdateCategoryModel từ CategoryDto
    /// </summary>
    /// <param name="dto"></param>
    public UpdateCategoryModel(CategoryDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Group = dto.Group;
        KeyName = dto.KeyName;
    }

    public UpdateCategoryRequest CreateRequest()
    {
        return new UpdateCategoryRequest
        {
            Id = this.Id,
            Name = this.Name,
            Group = this.Group,
            KeyName = this.KeyName
        };
    }

    public bool HasChanges(UpdateCategoryModel originalModel)
    {
        return ClientUpdateHelper.HasChanges(this, originalModel);
    }
}