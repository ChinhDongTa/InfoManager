namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record GetPesticidePlansQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<PesticidePlanSummaryDto>>>;

public class GetPesticidePlansQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPesticidePlansQuery, Result<PaginatedList<PesticidePlanSummaryDto>>>
{
    public async Task<Result<PaginatedList<PesticidePlanSummaryDto>>> Handle(GetPesticidePlansQuery request, CancellationToken ct)
    {
        var result = await context.PesticidePlans
            .ApplySorting()
            .ToPesticidePlanSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PesticidePlanSummaryDto>>.Success(result);
    }
}