namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record SearchEmployeeContractsQuery(string? Term, string? HREmployeeId, string? ContractType, bool? IsActive, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<EmployeeContractSummaryDto>>>;
public class SearchEmployeeContractsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchEmployeeContractsQuery, Result<PaginatedList<EmployeeContractSummaryDto>>>
{
    public async Task<Result<PaginatedList<EmployeeContractSummaryDto>>> Handle(SearchEmployeeContractsQuery request, CancellationToken cancellationToken)
    {
        var paged = await context.EmployeeContracts.BuildSearchQuery(request)
            .ApplySorting()
            .ToEmployeeContractSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<EmployeeContractSummaryDto>>.Success(paged);
    }
}