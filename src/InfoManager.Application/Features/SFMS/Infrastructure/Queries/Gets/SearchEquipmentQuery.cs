namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record SearchEquipmentsQuery(
    /// <summary>Từ khóa tìm kiếm (tên thiết bị, nhà sản xuất, model, serial)</summary>
    string? Term,
    /// <summary>Loại thiết bị</summary>
    EquipmentType? EquipmentType,
    /// <summary>ID nông trại liên kết</summary>
    string? FarmId,
    /// <summary>Trạng thái thiết bị</summary>
    EquipmentStatus? Status,
    /// <summary>Ngày bảo trì gần nhất từ</summary>
    DateTimeOffset? LastMaintenanceDateFrom,
    /// <summary>Ngày bảo trì gần nhất đến</summary>
    DateTimeOffset? LastMaintenanceDateTo,
    /// <summary>Ngày bảo trì kế tiếp từ</summary>
    DateTimeOffset? NextMaintenanceDateFrom,
    /// <summary>Ngày bảo trì kế tiếp đến</summary>
    DateTimeOffset? NextMaintenanceDateTo,
    int PageNumeber,
    int PageSize
    ) : IRequest<Result<PaginatedList<EquipmentSummaryDto>>>;
public class SearchEquipmentQueryHandler(IApplicationDbContext Context) : IRequestHandler<SearchEquipmentsQuery, Result<PaginatedList<EquipmentSummaryDto>>>
{
    public async Task<Result<PaginatedList<EquipmentSummaryDto>>> Handle(SearchEquipmentsQuery request, CancellationToken cancellationToken)
    {
        var query = Context.Equipments.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToEquipmentSummaryDto()
            .PaginatedListAsync(request.PageNumeber, request.PageSize, cancellationToken);
        return Result<PaginatedList<EquipmentSummaryDto>>.Success(paged);
    }
}