namespace InfoManager.Domain.Entities.Authentication;

public class LoginHistory : BaseAuditableEntity
{
    public string UserId { get; set; }               // FK → ApplicationUser (1-1)
    public ApplicationUser? User { get; set; }
    public DateTimeOffset LoginTime { get; set; } = DateTimeOffset.Now;
    public string? IPAddress { get; set; }
    public string? DeviceInfo { get; set; }
}