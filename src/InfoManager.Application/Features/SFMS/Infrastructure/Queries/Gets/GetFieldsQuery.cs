namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetFieldsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FieldSummaryDto>>>;
public class GetFieldsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFieldsQuery, Result<PaginatedList<FieldSummaryDto>>>
{
    public async Task<Result<PaginatedList<FieldSummaryDto>>> Handle(GetFieldsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Fields
            .ApplySorting()
            .ToFieldSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<FieldSummaryDto>>.Success(result);
    }
}
