using InfoManager.Shared.Dtos.TokenBlacklists;

namespace InfoManager.Application.Common.Services;

public class TokenBlacklistService(IApplicationDbContext context,
                                   IValidator<CreateTokenBlacklistDto> createValidator,
                                   ILogger<TokenBlacklistService> logger) : ITokenBlacklistService
{
    public async Task<Result> CleanupExpiredAsync(CancellationToken ct = default)
    {
        try
        {
            var count = await context.TokenBlacklists
                .Where(tb => tb.ExpiresAt < DateTime.UtcNow && tb.Status != TokenStatus.Permanent)
                .ExecuteDeleteAsync(ct);
            return Result.Success(ResultStatus.NoContent);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while cleaning up expired token blacklist entries.");
            return Result.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Delete, "expired token blacklist entries"));
        }
    }

    public async Task<Result<int>> CreateAsync(CreateTokenBlacklistDto dto, CancellationToken ct = default)
    {
        try
        {
            var validResult = await createValidator.ValidateAsync(dto, ct);
            if (!validResult.IsValid)
                return Result<int>.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Create, "token blacklist entry"));
            var entity = new TokenBlacklist
            {
                Jti = dto.Jti,
                UserIdOfToken = dto.UserIdOfToken,
                TokenType = dto.TokenType,
                Reason = dto.Reason,
                ExpiresAt = dto.ExpiresAt,
                Status = TokenStatus.Blacklisted,
                Note = dto.Note
            };
            context.TokenBlacklists.Add(entity);
            var rowAdd = await context.SaveChangesAsync(ct);
            return Result<int>.Success(rowAdd);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while creating a token blacklist entry.");
            return Result<int>.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Create, "token blacklist entry"));
        }
    }

    public async Task<Result<TokenBlacklistDto?>> GetByIdAsync(string id, CancellationToken ct = default)
    {
        if (string.IsNullOrEmpty(id))
            return Result<TokenBlacklistDto?>.Error(ErrorHelpers.GetErrorNotEmpty("ID"));
        try
        {
            var dto = await context.TokenBlacklists
                .Where(x => x.Id == id)
                .ToTokenBlacklistDtos()
                .FirstOrDefaultAsync(ct);
            return dto is not null
                ? Result<TokenBlacklistDto?>.Success(dto)
                : Result<TokenBlacklistDto?>.Error(ErrorHelpers.GetErrorNotFoundWithId("token blacklist entry", id));
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while retrieving a token blacklist entry by ID.");
            return Result<TokenBlacklistDto?>.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Read, "token blacklist entry"));
        }
    }

    public async Task<Result<TokenBlacklistDto?>> GetByJtiAsync(string jti, CancellationToken ct = default)
    {
        try
        {
            var dto = await context.TokenBlacklists
                .Where(x => x.Jti == jti)
                .ToTokenBlacklistDtos()
                .FirstOrDefaultAsync(ct);

            return dto == null
                ? Result<TokenBlacklistDto?>.Error(ErrorHelpers.GetErrorNotFoundWithId("token blacklist entry", jti))
                : Result<TokenBlacklistDto?>.Success(dto);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while retrieving a token blacklist entry by JTI.");
            return Result<TokenBlacklistDto?>.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Read, "token blacklist entry"));
        }
    }

    public async Task<Result<List<TokenBlacklistDto>>> GetByUserIdOfTokenAsync(string userIdOfToken, CancellationToken ct = default)
    {
        try
        {
            var dtos = await context.TokenBlacklists
                .Where(x => x.UserIdOfToken == userIdOfToken)
                .ToTokenBlacklistDtos()
                .ToListAsync(ct);
            return Result<List<TokenBlacklistDto>>.Success(dtos);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while retrieving token blacklist entries by UserId.");
            return Result<List<TokenBlacklistDto>>.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Read, "token blacklist entries"));
        }
    }

    public async Task<Result<bool>> IsBlacklistedAsync(string jti, string? userId = null, CancellationToken ct = default)
    {
        try
        {
            bool isBlacklisted;

            if (string.IsNullOrEmpty(userId))
            {
                isBlacklisted = await context.TokenBlacklists.AnyAsync(t =>
                    t.Jti == jti &&
                    t.Status == TokenStatus.Blacklisted &&
                    t.ExpiresAt > DateTime.UtcNow, ct);
            }
            else
            {
                isBlacklisted = await context.TokenBlacklists.AnyAsync(t =>
                    t.Jti == jti &&
                    t.UserIdOfToken == userId &&
                    t.Status == TokenStatus.Blacklisted &&
                    t.ExpiresAt > DateTime.UtcNow, ct);
            }

            return Result<bool>.Success(isBlacklisted);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while checking if a token is blacklisted.");
            return Result<bool>.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Read, "token blacklist entry"));
        }
    }

    public async Task<Result<int>> RevokeAllAsync(string userId, TokenStatus status = TokenStatus.Permanent, ReasonRevoke reason = ReasonRevoke.LogoutAll, string? note = null, CancellationToken ct = default)
    {
        try
        {
            var query = context.TokenBlacklists
                .Where(t => t.UserIdOfToken == userId && t.Status == status);

            var tokens = await query.ToListAsync(ct);

            foreach (var token in tokens)
            {
                token.Status = TokenStatus.Permanent;
                token.Reason = reason;
            }

            var result = await context.SaveChangesAsync(ct);
            return Result<int>.Success(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while revoking all tokens for a user.");
            return Result<int>.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Update, "token blacklist entries"));
        }
    }

    public async Task<Result<PaginatedList<SummaryTokenBlacklistDto>>> SearchAsync(SearchTokenBlacklistDto dto, CancellationToken ct = default)
    {
        try
        {
            var query = context.TokenBlacklists.AsQueryable();

            if (dto.ReasonRevoke.HasValue)
                query = query.Where(x => x.Reason == dto.ReasonRevoke.Value);

            if (dto.Status.HasValue)
                query = query.Where(x => x.Status == dto.Status.Value);

            if (dto.TokenType.HasValue)
                query = query.Where(x => x.TokenType == dto.TokenType.Value);

            if (dto.FromExpiresAt.HasValue)
                query = query.Where(x => x.ExpiresAt >= dto.FromExpiresAt.Value);

            if (dto.ToExpiresAt.HasValue)
                query = query.Where(x => x.ExpiresAt <= dto.ToExpiresAt.Value);

            var projected = query
                .OrderByDescending(x => x.ExpiresAt)
                .Select(x => new SummaryTokenBlacklistDto(
                    Id: x.Id,
                    Reason: x.Reason.ToDisplayName(),
                    Status: x.Status.ToDisplayName(),
                    ExpiresAt: x.ExpiresAt,
                    Note: x.Note
                ));
            var result = await PaginatedListExtensions.CreateAsync(projected, dto.PageNumber, dto.PageSize, ct);
            return Result<PaginatedList<SummaryTokenBlacklistDto>>.Success(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while searching token blacklist entries.");
            return Result<PaginatedList<SummaryTokenBlacklistDto>>.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Read, "token blacklist entries"));
        }
    }

    public async Task<Result<bool>> SetTokenStatusAsync(TokenStatus status, string jti, string? userId = null, string? note = null, CancellationToken ct = default)
    {
        try
        {
            var item = await FindByJti(jti, userId);

            if (item == null)
                return Result<bool>.Error(ErrorHelpers.GetErrorNotFoundWithId("TokenBlacklist", jti));

            item.Status = status;
            if (!string.IsNullOrEmpty(note))
                item.Note = note;

            var success = await context.SaveChangesAsync(ct) > 0;

            return success
                ? Result<bool>.Success(true)
                : Result<bool>.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Update, "TokenBlacklist"));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while updating token blacklist entry.");
            return Result<bool>.Error(ErrorHelpers.GetErrorCannotAction(ActionType.Update, "TokenBlacklist"));
        }
    }

    private async Task<TokenBlacklist?> FindByJti(string jti, string? userId = null)
    {
        if (string.IsNullOrEmpty(userId))
            return await context.TokenBlacklists.Where(x => x.Jti == jti).FirstOrDefaultAsync();
        return await context.TokenBlacklists.Where(x => x.Jti == jti && x.UserIdOfToken == userId).FirstOrDefaultAsync();
    }
}

internal static class TokenBlacklistQueryExtension
{
    public static IQueryable<TokenBlacklistDto> ToTokenBlacklistDtos(this IQueryable<TokenBlacklist> query)
    {
        return query
            .OrderByDescending(x => x.ExpiresAt)
            .Select(x => new TokenBlacklistDto
            {
                UserIdOfToken = x.UserIdOfToken,
                Id = x.Id,
                ExpiresAt = x.ExpiresAt,
                Jti = x.Jti,
                Note = x.Note,
                Reason = x.Reason.ToDisplayName(),
                Status = x.Status.ToDisplayName(),
                TokenType = x.TokenType.ToDisplayName()
            });
    }
}