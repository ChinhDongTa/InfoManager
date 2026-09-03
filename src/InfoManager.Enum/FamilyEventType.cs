namespace InfoManager.Enum;

public enum FamilyEventType
{
    [Display(Name = "Sinh nhật")]
    Birthday,
    
    [Display(Name = "Kỷ niệm")]
    Anniversary, //kỷ niệm ngày cưới, ngày tốt nghiệp, thành lập công ty, v.v.
    
    [Display(Name= "Giỗ / Ngày mất")]
    DeathAnniversary,
    [Display(Name = "Tưởng niệm khác")]
    Memorial
}
