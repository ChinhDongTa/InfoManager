namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetFieldsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FieldSummaryDto>>>;

public class GetFieldsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFieldsQuery, Result<PaginatedList<FieldSummaryDto>>>
{
    public async Task<Result<PaginatedList<FieldSummaryDto>>> Handle(GetFieldsQuery request, CancellationToken ct)
    {
        var result = await context.Fields
            .ApplySorting()
            .ToFieldSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FieldSummaryDto>>.Success(result);
    }
}