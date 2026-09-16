namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetFarmerByIdQuery(string Id) : IRequest<Result<FarmerDto?>>;

public class GetFarmerByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFarmerByIdQuery, Result<FarmerDto?>>
{
    public async Task<Result<FarmerDto?>> Handle(GetFarmerByIdQuery request, CancellationToken ct)
    {
        var result = await context.Farmers.Where(x => x.Id == request.Id)
            .ToFarmerDto()
            .SingleOrNotFoundAsync(nameof(Farmer), request.Id, ct);
        return result;
    }
}