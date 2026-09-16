namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record SearchGrowthStageQuery(string? Term,
                                       int? MinStageSequence,
                                       int? MaxStageSequence,
                                       int? MinDaysAfterPlanting,
                                       int? MaxDaysAfterPlanting,
                                       decimal? Temperature,
                                       decimal? Humidity,
                                       int PageNumber,
                                       int PageSize) : IRequest<Result<PaginatedList<GrowthStageSummaryDto>>>;

public class SearchGrowthStageQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchGrowthStageQuery, Result<PaginatedList<GrowthStageSummaryDto>>>
{
    public async Task<Result<PaginatedList<GrowthStageSummaryDto>>> Handle(SearchGrowthStageQuery request, CancellationToken ct)
    {
        var query = BuildSearchQuery(request);

        var result = await query
            .ApplySorting()
            .ToGrowthStageSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<GrowthStageSummaryDto>>.Success(result);
    }

    private IQueryable<GrowthStage> BuildSearchQuery(SearchGrowthStageQuery request)
    {
        var query = context.GrowthStages.AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.Term))
        {
            var keyword = $"%{request.Term.Trim()}%";
            query = query.Where(x => EF.Functions.ILike(x.StageName, keyword)
                               || (x.Description != null && EF.Functions.ILike(x.Description, keyword))
                               || (x.CommonPests != null && EF.Functions.ILike(x.CommonPests, keyword))
                               || (x.CommonDiseases != null && EF.Functions.ILike(x.CommonDiseases, keyword))
                               || (x.ManagementActivities != null && EF.Functions.ILike(x.ManagementActivities, keyword)));
        }
        if (request.MinStageSequence.HasValue)
        {
            query = query.Where(x => x.StageSequence >= request.MinStageSequence.Value);
        }
        if (request.MaxStageSequence.HasValue)
        {
            query = query.Where(x => x.StageSequence <= request.MaxStageSequence.Value);
        }
        if (request.MinDaysAfterPlanting.HasValue)
        {
            query = query.Where(x => x.DaysAfterPlanting >= request.MinDaysAfterPlanting.Value);
        }
        if (request.MaxDaysAfterPlanting.HasValue)
        {
            query = query.Where(x => x.DaysAfterPlanting <= request.MaxDaysAfterPlanting.Value);
        }
        if (request.Temperature.HasValue)
        {
            query = query.Where(x => x.MinTemperature <= request.Temperature.Value && x.MaxTemperature >= request.Temperature.Value);
        }
        if (request.Humidity.HasValue)
        {
            query = query.Where(x => x.MinHumidity <= request.Humidity.Value && x.MaxHumidity >= request.Humidity.Value);
        }
        return query;
    }
}