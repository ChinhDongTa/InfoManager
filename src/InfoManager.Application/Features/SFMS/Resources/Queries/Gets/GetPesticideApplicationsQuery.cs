namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record GetPesticideApplicationsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<PesticideApplicationSummaryDto>>>;

public class GetPesticideApplicationsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPesticideApplicationsQuery, Result<PaginatedList<PesticideApplicationSummaryDto>>>
{
    public async Task<Result<PaginatedList<PesticideApplicationSummaryDto>>> Handle(GetPesticideApplicationsQuery request, CancellationToken ct)
    {
        var result = await context.PesticideApplications
            .ApplySorting()
            .ToPesticideApplicationSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PesticideApplicationSummaryDto>>.Success(result);
    }
}