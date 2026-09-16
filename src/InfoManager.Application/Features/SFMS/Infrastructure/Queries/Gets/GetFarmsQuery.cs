namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetFarmsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FarmDto>>>;

public class GetFarmsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFarmsQuery, Result<PaginatedList<FarmDto>>>
{
    public async Task<Result<PaginatedList<FarmDto>>> Handle(GetFarmsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Farms
            .ApplySorting()
            .ToFarmDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<FarmDto>>.Success(result);
    }
}