namespace InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

public record GetInfestationsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<InfestationSummaryDto>>>;

public class GetInfestationsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetInfestationsQuery, Result<PaginatedList<InfestationSummaryDto>>>
{
    public async Task<Result<PaginatedList<InfestationSummaryDto>>> Handle(GetInfestationsQuery request, CancellationToken ct)
    {
        var result = await context.Infestations
            .ApplySorting()
            .ToInfestationSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<InfestationSummaryDto>>.Success(result);
    }
}