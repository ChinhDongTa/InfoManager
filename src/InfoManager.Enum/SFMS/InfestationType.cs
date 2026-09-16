namespace InfoManager.Enum.SFMS;

/// <summary>
/// Các loại sâu bệnh, bệnh tật, cỏ dại hoặc các vấn đề môi trường có thể ảnh hưởng đến cây trồng trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum InfestationType
{
    [Display(Name = "Sâu bệnh")]
    Pest = 1,

    [Display(Name = "Bệnh tật")]
    Disease = 2,

    [Display(Name = "Cỏ dại")]
    Weed = 3,

    [Display(Name = "Môi trường")]
    Environmental = 4
}