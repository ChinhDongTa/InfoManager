namespace InfoManager.Application.Features.SFMS.Issues.Queries.Gets;

public record SearchInfestationsQuery(string? Term, string? CropPlantingId, InfestationType? InfestationType, InfestationStatus? Status, SeverityLevel? SeverityLevel, int PageNumber, int PageSize)
    : IRequest<Result<PaginatedList<InfestationSummaryDto>>>;

public class SearchInfestationsQueryHandler(IApplicationDbContext Context)
    : IRequestHandler<SearchInfestationsQuery, Result<PaginatedList<InfestationSummaryDto>>>
{
    public async Task<Result<PaginatedList<InfestationSummaryDto>>> Handle(
        SearchInfestationsQuery request, CancellationToken ct)
    {
        var query = Context.Infestations.AsQueryable().BuildSearchQuery(request);
        var paged = await query.ApplySorting()
            .ToInfestationSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<InfestationSummaryDto>>.Success(paged);
    }
}