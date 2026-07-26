namespace InfoManager.Enum;

public enum FamilyEventType
{
    [Display(Name = "Sinh nhật")]
    Birthday,
    [Display(Name = "Kỷ niệm")]
    Anniversary, //kỷ niệm ngày cưới, ngày tốt nghiệp, thành lập công ty, v.v.
    [Display(Name="Ngày mất")]
    DeathDay,
    [Display(Name = "Khác")]
    Other
}