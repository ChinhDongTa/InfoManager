namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;
public record GetEmployeeContractsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<EmployeeContractSummaryDto>>>;
public class GetEmployeeContractsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetEmployeeContractsQuery, Result<PaginatedList<EmployeeContractSummaryDto>>>
{
    public async Task<Result<PaginatedList<EmployeeContractSummaryDto>>> Handle(GetEmployeeContractsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.EmployeeContracts
            .ApplySorting()
            .ToEmployeeContractSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<EmployeeContractSummaryDto>>.Success(result);
    }
}