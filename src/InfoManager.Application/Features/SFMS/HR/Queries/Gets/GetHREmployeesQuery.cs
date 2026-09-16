namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetHREmployeesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<HREmployeeSummaryDto>>>;

public class GetHREmployeesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHREmployeesQuery, Result<PaginatedList<HREmployeeSummaryDto>>>
{
    public async Task<Result<PaginatedList<HREmployeeSummaryDto>>> Handle(GetHREmployeesQuery request, CancellationToken ct)
    {
        var result = await context.HREmployees
            .ApplySorting()
            .ToHREmployeeSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<HREmployeeSummaryDto>>.Success(result);
    }
}