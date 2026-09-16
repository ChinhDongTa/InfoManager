global using System.ComponentModel.DataAnnotations;

namespace InfoManager.Enum;

/// <summary>
/// Phân loại sự kiện lịch sử (Chính trị, Quân sự, Văn hóa, Khoa học, Kinh tế, Khác)
/// </summary>
public enum HistoricalEventType
{
    [Display(Name = "Chính trị")]
    Political,

    [Display(Name = "Quân sự")]
    Military,

    [Display(Name = "Văn hóa")]
    Cultural,

    [Display(Name = "Khoa học")]
    Scientific,

    [Display(Name = "Kinh tế")]
    Economic,

    [Display(Name = "Khác")]
    Other
}