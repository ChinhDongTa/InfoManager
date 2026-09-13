namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetDepartmentsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<DepartmentSummaryDto>>>;
public class GetDepartmentsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetDepartmentsQuery, Result<PaginatedList<DepartmentSummaryDto>>>
{
    public async Task<Result<PaginatedList<DepartmentSummaryDto>>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Departments
            .ApplySorting()
            .ToDepartmentSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<DepartmentSummaryDto>>.Success(result);
    }
}