using System.Security.Claims;
using InfoManager.Application.Common.Interfaces;

namespace InfoManager.WebBlazorV5.Components.Account;

/// <summary>
/// Host adapter so Infrastructure's DbContext can read the cookie principal.
/// Same contract as the API CurrentUser, without referencing the API project.
/// </summary>
public class BlazorCurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public string? Id => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    public List<string>? Roles => httpContextAccessor.HttpContext?.User?.FindAll(ClaimTypes.Role).Select(x => x.Value).ToList();
}
