namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record SearchCropSchedulesQuery(
    string? Term,
    int? MinDaysToHarvest,
    int? MaxDaysToHarvest,
    decimal? MinExpectedYield,
    decimal? MaxExpectedYield,
    bool? IsActive,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<CropScheduleSummaryDto>>>;
public class SearchCropSchedulesQueryHandler : IRequestHandler<SearchCropSchedulesQuery, Result<PaginatedList<CropScheduleSummaryDto>>>
{
    public Task<Result<PaginatedList<CropScheduleSummaryDto>>> Handle(SearchCropSchedulesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}