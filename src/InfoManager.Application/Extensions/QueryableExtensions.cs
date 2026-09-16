namespace InfoManager.Application.Extensions;

public static class QueryableExtensions
{
    //extension<T>(IQueryable<T> query) where T : BaseAuditableEntity
    //{
    //    /// <summary>
    //    /// Áp dụng filter theo User.
    //    /// - Nếu userId = null hoặc user là Admin → trả về tất cả
    //    /// - Ngược lại lọc theo CreatedBy
    //    /// </summary>
    //    public IQueryable<T> ApplyUserFilter(IUser? user)
    //    {
    //        if (user == null)
    //            return query;
    //        return string.IsNullOrEmpty(user.Id) ? query : query.Where(x => x.CreatedBy == user.Id);
    //    }

    //    // Overload nếu muốn truyền userId thủ công
    //    public IQueryable<T> ApplyUserFilter(string? userId)
    //        => string.IsNullOrEmpty(userId) ? query : query.Where(x => x.CreatedBy == userId);
    //}

    public static async Task<Result<TDto?>> SingleOrNotFoundAsync<TDto>(this IQueryable<TDto> query, string entityName, string entityId, CancellationToken ct)
        where TDto : class
    {
        var result = await query.FirstOrDefaultAsync(ct);
        return result == null
            ? Result<TDto?>.NotFound(ErrorHelpers.GetErrorNotFoundWithId(entityName, entityId))
            : Result<TDto?>.Success(result);
    }

    public static async Task<Result<List<TDto>>> ToListResultAsync<TDto>(this IQueryable<TDto> query, CancellationToken ct)
        where TDto : class
    {
        var items = await query.ToListAsync(ct);
        return Result<List<TDto>>.Success(items);
    }
}