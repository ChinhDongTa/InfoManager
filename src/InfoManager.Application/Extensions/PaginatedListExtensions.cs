namespace InfoManager.Application.Extensions;

public static class PaginatedListExtensions
{
    public static async Task<PaginatedList<T>> CreateAsync<T>(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken ct = default)
    {
        var count = await source.CountAsync(ct);
        var items = await source.Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync(ct);

        return new PaginatedList<T>(items, count, pageNumber, pageSize);
    }

    extension<TDestination>(IQueryable<TDestination> queryable) where TDestination : class
    {
        public Task<PaginatedList<TDestination>> PaginatedListAsync(int pageNumber, int pageSize, CancellationToken ct = default)
            => CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize, ct);
    }
}