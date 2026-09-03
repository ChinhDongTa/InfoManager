namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record SearchCropVarietiesQuery(string? Term,
    string? CropId,
    int? DaysToMaturity,
    decimal? MinExpectedYield,
    decimal? MaxExpectedYield,
    bool? IsActive,
    int PageNumber,
    int PageSize) : IRequest<Result<PaginatedList<CropVarietySummaryDto>>>;
public class SearchCropVarietiesQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchCropVarietiesQuery, Result<PaginatedList<CropVarietySummaryDto>>>
{
    public async Task<Result<PaginatedList<CropVarietySummaryDto>>> Handle(SearchCropVarietiesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CropVariety> query = ApplyFilter(request);
        var result = await query
            .ApplySorting()
            .ToCropVarietySummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<CropVarietySummaryDto>>.Success(result);
    }

    private IQueryable<CropVariety> ApplyFilter(SearchCropVarietiesQuery request)
    {
        var query = context.CropVarieties.AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.Term))
        {
            var term = $"%{request.Term.Trim()}%";
            query = query.Where(x => EF.Functions.ILike(x.VarietyName, term) 
            || (x.BreederName!=null&&EF.Functions.ILike(x.BreederName, term))
            || (x.DiseaseResistance != null && EF.Functions.ILike(x.DiseaseResistance, term))
            || (x.PestResistance != null && EF.Functions.ILike(x.PestResistance, term))
            || (x.ClimateSuitability != null && EF.Functions.ILike(x.ClimateSuitability, term))
            );
        }
        if (!string.IsNullOrWhiteSpace(request.CropId))
        {
            query = query.Where(x => x.CropId == request.CropId);
        }
        if (request.DaysToMaturity.HasValue)
        {
            query = query.Where(x => x.DaysToMaturity == request.DaysToMaturity.Value);
        }
        if (request.MinExpectedYield.HasValue)
        {
            query = query.Where(x => x.ExpectedYield >= request.MinExpectedYield.Value);
        }
        if (request.MaxExpectedYield.HasValue)
        {
            query = query.Where(x => x.ExpectedYield <= request.MaxExpectedYield.Value);
        }
        if (request.IsActive.HasValue)
        {
            query = query.Where(x => x.IsActive == request.IsActive.Value);
        }

        return query;
    }
}