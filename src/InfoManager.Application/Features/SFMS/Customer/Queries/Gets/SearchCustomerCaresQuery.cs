namespace InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

public record SearchCustomerCaresQuery(string? Term,
                                       DateTimeOffset? StartCareDate,
                                       DateTimeOffset? EndCareDate,
                                       DateTimeOffset? StartNextFollowUpDate,
                                       DateTimeOffset? EndNextFollowUpDate,
                                       int PageNumber,
                                       int PageSize) : IRequest<Result<PaginatedList<CustomerCareSummaryDto>>>;

public class SearchCustomersCareQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchCustomerCaresQuery, Result<PaginatedList<CustomerCareSummaryDto>>>
{
    public async Task<Result<PaginatedList<CustomerCareSummaryDto>>> Handle(SearchCustomerCaresQuery request, CancellationToken ct)
    {
        var query = BuildSearchQuery(context.CustomerCares.AsQueryable(), request);
        var paged = await query.ApplySorting()
            .ToCustomerCareSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<CustomerCareSummaryDto>>.Success(paged);
    }

    private static IQueryable<CustomerCare> BuildSearchQuery(IQueryable<CustomerCare> query, SearchCustomerCaresQuery request)
    {
        if (!string.IsNullOrEmpty(request.Term))
        {
            var key = $"%{request.Term.Trim()}%";
            query = query.Where(c => (EF.Functions.ILike(c.Subject, key))
                                                  || (c.Content != null && EF.Functions.ILike(c.Content, key))
                                                  || (c.HandledBy != null && EF.Functions.ILike(c.HandledBy, key))
                                                  || (c.Result != null && EF.Functions.ILike(c.Result, key))
            );
        }

        if (request.StartCareDate.HasValue)
        {
            query = query.Where(c => c.CareDate >= request.StartCareDate);
        }
        if (request.EndCareDate.HasValue)
        {
            query = query.Where(c => c.CareDate <= request.EndCareDate);
        }

        if (request.StartNextFollowUpDate.HasValue)
        {
            query = query.Where(c => c.NextFollowUpDate >= request.StartNextFollowUpDate);
        }
        if (request.EndNextFollowUpDate.HasValue)
        {
            query = query.Where(c => c.NextFollowUpDate <= request.StartNextFollowUpDate);
        }
        return query;
    }
}