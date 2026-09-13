namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetHREmployeesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<HREmployeeSummaryDto>>>;
public class GetHREmployeesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHREmployeesQuery, Result<PaginatedList<HREmployeeSummaryDto>>>
{
    public async Task<Result<PaginatedList<HREmployeeSummaryDto>>> Handle(GetHREmployeesQuery request, CancellationToken cancellationToken)
    {
        var result = await context.HREmployees
            .ApplySorting()
            .ToHREmployeeSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<HREmployeeSummaryDto>>.Success(result);
    }
}