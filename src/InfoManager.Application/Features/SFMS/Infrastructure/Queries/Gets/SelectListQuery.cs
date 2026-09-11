namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetSelectListDevicesQuery: IRequest<Result<IEnumerable<SelectListItemDto>>>;
public class GetSelectListDevicesQueryHandler(IApplicationDbContext context): IRequestHandler<GetSelectListDevicesQuery, Result<IEnumerable<SelectListItemDto>>>
{
    public async Task<Result<IEnumerable<SelectListItemDto>>> Handle(GetSelectListDevicesQuery request, CancellationToken cancellationToken)
    {
        var list = await context.Devices.ApplySorting()
            .Select(x=>new SelectListItemDto(x.Id, x.Name)).ToListAsync(cancellationToken);
        return Result<IEnumerable<SelectListItemDto>>.Success(list);
    }
}

public record GetSelectListFarmsQuery : IRequest<Result<IEnumerable<SelectListItemDto>>>;
public class GetSelectListFarmsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSelectListFarmsQuery, Result<IEnumerable<SelectListItemDto>>>
{
    public async Task<Result<IEnumerable<SelectListItemDto>>> Handle(GetSelectListFarmsQuery request, CancellationToken cancellationToken)
    {
        var list = await context.Farms.ApplySorting()
            .Select(x => new SelectListItemDto(x.Id, x.Name)).ToListAsync(cancellationToken);
        return Result<IEnumerable<SelectListItemDto>>.Success(list);
    }
}
public record GetSelectListFarmersQuery : IRequest<Result<IEnumerable<SelectListItemDto>>>;
public class GetSelectListFarmersQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSelectListFarmersQuery, Result<IEnumerable<SelectListItemDto>>>
{
    public async Task<Result<IEnumerable<SelectListItemDto>>> Handle(GetSelectListFarmersQuery request, CancellationToken cancellationToken)
    {
        var list = await context.Farmers.ApplySorting()
            .Select(x => new SelectListItemDto(x.Id, x.FullName)).ToListAsync(cancellationToken);
        return Result<IEnumerable<SelectListItemDto>>.Success(list);
    }
}


public record GetSelectListFieldsQuery : IRequest<Result<IEnumerable<SelectListItemDto>>>;
public class GetSelectListFieldsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSelectListFieldsQuery, Result<IEnumerable<SelectListItemDto>>>
{
    public async Task<Result<IEnumerable<SelectListItemDto>>> Handle(GetSelectListFieldsQuery request, CancellationToken cancellationToken)
    {
        var list = await context.Fields.ApplySorting()
            .Select(x => new SelectListItemDto(x.Id, x.Name)).ToListAsync(cancellationToken);
        return Result<IEnumerable<SelectListItemDto>>.Success(list);
    }
}