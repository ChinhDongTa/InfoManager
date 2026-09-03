namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record SearchCropPlantingsQuery(string? Term,
                                        DateTimeOffset? StartPlantingDate,
                                        DateTimeOffset? EndPlantingDate,
                                        decimal? MinPlantedArea,
                                        decimal? MaxPlantedArea,
                                        PlantingStatus? Status,
                                        int PageNumber,
                                        int PageSize) : IRequest<Result<PaginatedList<CropPlantingSummaryDto>>>;
public class SearchCropPlantingsQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchCropPlantingsQuery, Result<PaginatedList<CropPlantingSummaryDto>>>
{
    public async Task<Result<PaginatedList<CropPlantingSummaryDto>>> Handle(SearchCropPlantingsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CropPlanting> query = ApplyFilter(request);
        var result = await query
            .ApplySorting()
            .ToCropPlantingSummaryDto()
            .PaginatedListAsync(1, 10, cancellationToken); // Default pagination values
        return Result<PaginatedList<CropPlantingSummaryDto>>.Success(result);
    }

    private IQueryable<CropPlanting> ApplyFilter(SearchCropPlantingsQuery request)
    {
        var query = context.CropPlantings.AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.Term))
        {
            var key=$"%{request.Term.Trim()}%";
            query = query.Where(x => EF.Functions.ILike(x.PlantingCode, key) 
            || (x.PlantedUnit != null && EF.Functions.ILike(x.PlantedUnit, key)) 
            ||(x.Notes!=null &&EF.Functions.ILike(x.Notes, key)));
        }
        if (request.StartPlantingDate.HasValue)
        {
            query = query.Where(x => x.PlantingDate >= request.StartPlantingDate.Value);
        }
        if (request.EndPlantingDate.HasValue)
        {
            query = query.Where(x => x.PlantingDate <= request.EndPlantingDate.Value);
        }
        if (request.MinPlantedArea.HasValue)
        {
            query = query.Where(x => x.PlantedArea >= request.MinPlantedArea.Value);
        }
        if (request.MaxPlantedArea.HasValue)
        {
            query = query.Where(x => x.PlantedArea <= request.MaxPlantedArea.Value);
        }
        if (request.Status.HasValue)
        {
            query = query.Where(x => x.Status == request.Status.Value);
        }

        return query;
    }
}