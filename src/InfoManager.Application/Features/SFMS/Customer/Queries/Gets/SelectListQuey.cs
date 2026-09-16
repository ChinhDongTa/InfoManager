namespace InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

public record GetSelectListCustomersQuery : IRequest<Result<IEnumerable<SelectListItemDto>>>;

public class GetSelectListCustomersQueryHanderl(IApplicationDbContext context) : IRequestHandler<GetSelectListCustomersQuery, Result<IEnumerable<SelectListItemDto>>>
{
    public async Task<Result<IEnumerable<SelectListItemDto>>> Handle(GetSelectListCustomersQuery request, CancellationToken ct)
    {
        var list = await context.Customers.ApplySorting().Select(x => new SelectListItemDto(x.Id, x.Name)).ToListAsync();
        return Result<IEnumerable<SelectListItemDto>>.Success(list);
    }
}