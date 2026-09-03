using InfoManager.Shared.Dtos.Families;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Features.Families.Queries.GetFamilies;

public record GetFamiliesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<FamilySummaryDto>>>;
public class GetFamiliesQueryHandler : IRequestHandler<GetFamiliesQuery, Result<PaginatedList<FamilySummaryDto>>>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<GetFamiliesQueryHandler> _logger;
    public GetFamiliesQueryHandler(IApplicationDbContext context, ILogger<GetFamiliesQueryHandler> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<Result<PaginatedList<FamilySummaryDto>>> Handle(GetFamiliesQuery request, CancellationToken cancellationToken)
    {
        var families = await _context.Families
            .ApplySorting()
            .ToFamilySummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<FamilySummaryDto>>.Success(families);
    }
}
