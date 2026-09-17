namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record GetPesticidesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<PesticideSummaryDto>>>;

public class GetPesticidesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPesticidesQuery, Result<PaginatedList<PesticideSummaryDto>>>
{
    public async Task<Result<PaginatedList<PesticideSummaryDto>>> Handle(GetPesticidesQuery request, CancellationToken ct)
    {
        var result = await context.Pesticides
            .ApplySorting()
            .ToPesticideSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PesticideSummaryDto>>.Success(result);
    }
}