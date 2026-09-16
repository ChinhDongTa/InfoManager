namespace InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

public record GetPestDiseaseLinksQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<PestDiseaseLinkSummaryDto>>>;

public class GetPestDiseaseLinksQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPestDiseaseLinksQuery, Result<PaginatedList<PestDiseaseLinkSummaryDto>>>
{
    public async Task<Result<PaginatedList<PestDiseaseLinkSummaryDto>>> Handle(GetPestDiseaseLinksQuery request, CancellationToken ct)
    {
        var result = await context.PestDiseaseLinks
            .ApplySorting()
            .ToPestDiseaseLinkSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<PestDiseaseLinkSummaryDto>>.Success(result);
    }
}