namespace InfoManager.Enum.SFMS;

/// <summary>
/// Các loại chi phí trong hệ thống quản lý nông nghiệp thông minh (Smart Farm Management System - SFMS).
/// </summary>
public enum ExpenseType
{
    [Display(Name = "Hạt giống và gieo trồng")]
    SeedAndSeeding = 1,
    [Display(Name = "Phân bón")]
    Fertilizer = 2,
    [Display(Name = "Thuốc trừ sâu")]
    Pesticide = 3,
    [Display(Name = "Nước")]
    Water = 4,
    [Display(Name = "Lao động")]    
    Labor = 5,
    [Display(Name = "Thiết bị")]
    Equipment = 6,
    [Display(Name = "Nhiên liệu")]
    Fuel = 7,
    [Display(Name = "Thuê mặt bằng")]
    Rent = 8,
    [Display(Name = "Bảo trì")]
    Maintenance = 9,
    [Display(Name = "Vận chuyển")]
    Transportation = 10,
    [Display(Name = "Kho bãi")]
    Storage = 11,
    [Display(Name = "Tiện ích")]
    Utilities = 12,
    [Display(Name = "Bảo hiểm")]
    Insurance = 13,
    [Display(Name = "Khoản vay")]
    Loan = 14,
    [Display(Name = "Thuế")]
    Tax = 15,
    [Display(Name = "Khác")]
    Other = 16
}
