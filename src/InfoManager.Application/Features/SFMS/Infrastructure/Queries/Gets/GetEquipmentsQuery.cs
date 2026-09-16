namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetEquipmentsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<EquipmentDto>>>;

public class GetEquipmentsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetEquipmentsQuery, Result<PaginatedList<EquipmentDto>>>
{
    public async Task<Result<PaginatedList<EquipmentDto>>> Handle(GetEquipmentsQuery request, CancellationToken ct)
    {
        var result = await context.Equipments
            .ApplySorting()
            .ToEquipmentDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<EquipmentDto>>.Success(result);
    }
}