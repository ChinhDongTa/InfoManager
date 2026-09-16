namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetFarmersQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FarmerSummaryDto>>>;

public class GetFarmersQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFarmersQuery, Result<PaginatedList<FarmerSummaryDto>>>
{
    public async Task<Result<PaginatedList<FarmerSummaryDto>>> Handle(GetFarmersQuery request, CancellationToken ct)
    {
        var query = context.Farmers.AsQueryable();
        var paginatedResult = await query.ApplySorting()
            .ToFarmerSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FarmerSummaryDto>>.Success(paginatedResult);
    }
}