using InfoManager.Enum;
using InfoManager.Shared.Dtos.TokenBlacklists;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Common.Interfaces;

public interface ITokenBlacklistService
{
    /// <summary>
    /// Thêm token vào blacklist
    /// </summary>
    Task<Result<int>> CreateAsync(CreateTokenBlacklistDto dto, CancellationToken ct = default);

    /// <summary>
    /// Kiểm tra token có bị blacklist không
    /// </summary>
    Task<Result<bool>> IsBlacklistedAsync(string jti, string? userId = null, CancellationToken ct = default);

    /// <summary>
    /// Cập nhật trạng thái token (Blacklisted, Unlocked, Permanent)
    /// </summary>
    Task<Result<bool>> SetTokenStatusAsync(TokenStatus status, string jti, string? userId = null, string? note = null, CancellationToken ct = default);

    /// <summary>
    /// Revoke tất cả token của một User
    /// </summary>
    Task<Result<int>> RevokeAllAsync(string userId, TokenStatus status = TokenStatus.Permanent,
                       ReasonRevoke reason = ReasonRevoke.LogoutAll,
                       string? note = null, CancellationToken ct = default);

    /// <summary>
    /// Tìm kiếm (dùng cho Admin)
    /// </summary>
    Task<Result<PaginatedList<SummaryTokenBlacklistDto>>> SearchAsync(SearchTokenBlacklistDto dto, CancellationToken ct = default);

    /// <summary>
    /// Lấy chi tiết theo Id
    /// </summary>
    Task<Result<TokenBlacklistDto?>> GetByIdAsync(string id, CancellationToken ct = default);

    Task<Result<TokenBlacklistDto?>> GetByJtiAsync(string jti, CancellationToken ct = default);
    Task<Result<List<TokenBlacklistDto>>> GetByUserIdOfTokenAsync(string userIdOfToken, CancellationToken ct = default);


    /// <summary>
    /// Dọn dẹp token hết hạn
    /// </summary>
    Task<Result> CleanupExpiredAsync(CancellationToken ct = default);
}