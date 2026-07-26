
using Microsoft.AspNetCore.Identity;

namespace InfoManager.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public long? TelegramId { get; set; }
}