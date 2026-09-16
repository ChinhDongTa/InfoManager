namespace InfoManager.Application.Features.SFMS.Economics.Queries.Gets;

public record GetFarmExpenseByIdQuery(string Id) : IRequest<Result<FarmExpenseDto?>>;

public class GetFarmExpenseByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFarmExpenseByIdQuery, Result<FarmExpenseDto?>>
{
    public async Task<Result<FarmExpenseDto?>> Handle(GetFarmExpenseByIdQuery request, CancellationToken ct)
    {
        var result = await context.FarmExpenses
            .Where(x => x.Id == request.Id)
            .ToFarmExpenseDto()
            .SingleOrNotFoundAsync(nameof(FarmExpense), request.Id, ct);
        return result;
    }
}