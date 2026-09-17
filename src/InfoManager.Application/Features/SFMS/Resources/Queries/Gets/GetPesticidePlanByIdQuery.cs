namespace InfoManager.Application.Features.SFMS.Resources.Queries.Gets;

public record GetPesticidePlanByIdQuery(string Id) : IRequest<Result<PesticidePlanDto?>>;

public class GetPesticidePlanByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPesticidePlanByIdQuery, Result<PesticidePlanDto?>>
{
    public async Task<Result<PesticidePlanDto?>> Handle(GetPesticidePlanByIdQuery request, CancellationToken ct)
    {
        var result = await context.PesticidePlans
            .Where(x => x.Id == request.Id)
            .ToPesticidePlanDto()
            .SingleOrNotFoundAsync(nameof(PesticidePlan), request.Id, ct);
        return result;
    }
}