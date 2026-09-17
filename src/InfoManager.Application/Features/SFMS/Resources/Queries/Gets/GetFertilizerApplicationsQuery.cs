namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record GetFertilizerApplicationsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FertilizerApplicationSummaryDto>>>;

public class GetFertilizerApplicationsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFertilizerApplicationsQuery, Result<PaginatedList<FertilizerApplicationSummaryDto>>>
{
    public async Task<Result<PaginatedList<FertilizerApplicationSummaryDto>>> Handle(GetFertilizerApplicationsQuery request, CancellationToken ct)
    {
        var result = await context.FertilizerApplications
            .ApplySorting()
            .ToFertilizerApplicationSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FertilizerApplicationSummaryDto>>.Success(result);
    }
}