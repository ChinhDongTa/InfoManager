namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetPayrollByIdQuery(string Id) : IRequest<Result<PayrollDto?>>;
public class GetPayrollByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPayrollByIdQuery, Result<PayrollDto?>>
{
    public async Task<Result<PayrollDto?>> Handle(GetPayrollByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Payrolls
            .Where(x => x.Id == request.Id)
            .ToPayrollDto()
            .SingleOrNotFoundAsync(nameof(Payroll), request.Id, cancellationToken);
        return result;
    }
}