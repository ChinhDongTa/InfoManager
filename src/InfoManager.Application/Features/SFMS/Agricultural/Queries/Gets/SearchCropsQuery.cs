namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record SearchCropsQuery(string? Term,
                               int? MinDaysToMaturity,
                               int? MaxDaysToMaturity,
                               decimal? Temperature,
                               decimal? Humidity,
                               decimal? SoilPh,
                               bool? IsActive,
                               int PageNumber,
                               int PageSize) : IRequest<Result<PaginatedList<CropSummaryDto>>>;

public class SearchCropsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchCropsQuery, Result<PaginatedList<CropSummaryDto>>>
{
    public async Task<Result<PaginatedList<CropSummaryDto>>> Handle(SearchCropsQuery request, CancellationToken ct)
    {
        var query = BuildSearchQuery(context.Crops.AsQueryable(), request);

        var result = await query
            .ApplySorting()
            .ToCropSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<CropSummaryDto>>.Success(result);
    }

    private static IQueryable<Crop> BuildSearchQuery(IQueryable<Crop> query, SearchCropsQuery request)
    {
        if (!string.IsNullOrWhiteSpace(request.Term))
        {
            var keyword = $"%{request.Term.Trim()}%";
            query = query.Where(x => EF.Functions.ILike(x.CommonName, keyword)
                               || EF.Functions.ILike(x.ScientificName, keyword)
                               || (x.Family != null && EF.Functions.ILike(x.Family, keyword)));
        }
        if (request.MinDaysToMaturity.HasValue)
        {
            query = query.Where(x => x.DaysToMaturity >= request.MinDaysToMaturity.Value);
        }
        if (request.MaxDaysToMaturity.HasValue)
        {
            query = query.Where(x => x.DaysToMaturity <= request.MaxDaysToMaturity.Value);
        }
        if (request.Temperature.HasValue)
        {
            query = query.Where(x => x.MinTemperature <= request.Temperature.Value && x.MaxTemperature >= request.Temperature.Value);
        }
        if (request.Humidity.HasValue)
        {
            query = query.Where(x => x.MinHumidity <= request.Humidity.Value && x.MaxHumidity >= request.Humidity.Value);
        }
        if (request.SoilPh.HasValue)
        {
            query = query.Where(x => x.MinSoilPh <= request.SoilPh.Value && x.MaxSoilPh >= request.SoilPh.Value);
        }
        if (request.IsActive.HasValue)
        {
            query = query.Where(x => x.IsActive == request.IsActive.Value);
        }

        return query;
    }
}