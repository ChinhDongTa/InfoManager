namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record GetFertilizersQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FertilizerSummaryDto>>>;

public class GetFertilizersQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFertilizersQuery, Result<PaginatedList<FertilizerSummaryDto>>>
{
    public async Task<Result<PaginatedList<FertilizerSummaryDto>>> Handle(GetFertilizersQuery request, CancellationToken ct)
    {
        var result = await context.Fertilizers
            .ApplySorting()
            .ToFertilizerSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FertilizerSummaryDto>>.Success(result);
    }
}