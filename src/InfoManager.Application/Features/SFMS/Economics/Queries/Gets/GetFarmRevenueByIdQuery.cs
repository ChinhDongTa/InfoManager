namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record GetFarmRevenueByIdQuery(string Id) : IRequest<Result<FarmRevenueDto?>>;

public class GetFarmRevenueByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFarmRevenueByIdQuery, Result<FarmRevenueDto?>>
{
    public async Task<Result<FarmRevenueDto?>> Handle(GetFarmRevenueByIdQuery request, CancellationToken ct)
    {
        var result = await context.FarmRevenues
            .Where(x => x.Id == request.Id)
            .ToFarmRevenueDto()
            .SingleOrNotFoundAsync(nameof(FarmRevenue), request.Id, ct);
        return result;
    }
}