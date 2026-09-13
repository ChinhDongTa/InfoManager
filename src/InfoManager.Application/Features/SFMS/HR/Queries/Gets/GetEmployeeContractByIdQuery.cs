namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetEmployeeContractByIdQuery(string Id) : IRequest<Result<EmployeeContractDto?>>;
public class GetEmployeeContractByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetEmployeeContractByIdQuery, Result<EmployeeContractDto?>>
{
    public async Task<Result<EmployeeContractDto?>> Handle(GetEmployeeContractByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.EmployeeContracts
            .Where(x => x.Id == request.Id)
            .ToEmployeeContractDto()
            .SingleOrNotFoundAsync(nameof(EmployeeContract), request.Id, cancellationToken);
        return result;
    }
}
