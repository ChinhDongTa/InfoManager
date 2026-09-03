namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetEquipmentByIdQuery(string Id) : IRequest<Result<EquipmentDto?>>;
public class GetEquipmentByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetEquipmentByIdQuery, Result<EquipmentDto?>>
{
    public async Task<Result<EquipmentDto?>> Handle(GetEquipmentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Equipments
            .Where(x => x.Id == request.Id)
            .ToEquipmentDto()
            .SingleOrNotFoundAsync(nameof(Equipment), request.Id, cancellationToken);
        return result;
    }
}