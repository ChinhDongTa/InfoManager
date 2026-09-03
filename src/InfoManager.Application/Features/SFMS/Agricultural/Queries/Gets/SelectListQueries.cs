namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

//====================================Select List Queries=======================================
public record SelectListCropVarietiesQuery(string? CropId) : IRequest<Result<IEnumerable<SelectListItemDto>>>;
public class GetSelectListCropVarietiesQueryHandler(IApplicationDbContext context) : IRequestHandler<SelectListCropVarietiesQuery, Result<IEnumerable<SelectListItemDto>>>
{
    public async Task<Result<IEnumerable<SelectListItemDto>>> Handle(SelectListCropVarietiesQuery request, CancellationToken cancellationToken)
    {
        var query = context.CropVarieties.AsQueryable();
        if (!string.IsNullOrEmpty(request.CropId))
        {
            query = query.Where(cv => cv.CropId == request.CropId);
        }
        var result = await query
            .OrderBy(cv => cv.VarietyName)
            .Select(cv => new SelectListItemDto(cv.Id, cv.VarietyName))
            .ToListAsync(cancellationToken);
        return Result<IEnumerable<SelectListItemDto>>.Success(result);
    }
}

public record GetSelectListCropsQuery : IRequest<Result<IEnumerable<SelectListItemDto>>>;
public class GetSelectListCropsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSelectListCropsQuery, Result<IEnumerable<SelectListItemDto>>>
{
    public async Task<Result<IEnumerable<SelectListItemDto>>> Handle(GetSelectListCropsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Crops
            .OrderBy(c => c.CommonName)
            .Select(c => new SelectListItemDto(c.Id, c.CommonName))
            .ToListAsync(cancellationToken);
        return Result<IEnumerable<SelectListItemDto>>.Success(result);
    }
}

public record GetSelectListCropSchedulesQuery(string? CropId) : IRequest<Result<IEnumerable<SelectListItemDto>>>;
public class GetSelectListCropSchedulesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSelectListCropSchedulesQuery, Result<IEnumerable<SelectListItemDto>>>
{
    public async Task<Result<IEnumerable<SelectListItemDto>>> Handle(GetSelectListCropSchedulesQuery request, CancellationToken cancellationToken)
    {
        var query = context.CropSchedules.AsQueryable();
        if (!string.IsNullOrEmpty(request.CropId))
        {
            query = query.Where(cs => cs.CropId == request.CropId);
        }
        var result = await query
            .OrderBy(cs => cs.ScheduleName)
            .Select(cs => new SelectListItemDto(cs.Id, cs.ScheduleName))
            .ToListAsync(cancellationToken);
        return Result<IEnumerable<SelectListItemDto>>.Success(result);
    }
}

public record GetSelectListGrowthStageAlertsQuery(string ? CropPlantingId) : IRequest<Result<IEnumerable<SelectListItemDto>>>;
public class GetSelectListGrowthStageAlertsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSelectListGrowthStageAlertsQuery, Result<IEnumerable<SelectListItemDto>>>
{
    public async Task<Result<IEnumerable<SelectListItemDto>>> Handle(GetSelectListGrowthStageAlertsQuery request, CancellationToken cancellationToken)
    {
        var query = context.GrowthStageAlerts.AsQueryable();
        if (!string.IsNullOrEmpty(request.CropPlantingId))
        {
            query = query.Where(gsa => gsa.CropPlantingId == request.CropPlantingId);
        }
        var result = await query
            .OrderByDescending(gsa => gsa.ExpectedAchievementDate)
            .Select(gsa => new SelectListItemDto(gsa.Id, gsa.AlertType.ToDisplayName()))
            .ToListAsync(cancellationToken);
        return Result<IEnumerable<SelectListItemDto>>.Success(result);
    }
}

public record GetSelectListCropPlantingsQuery(string? FieldId) : IRequest<Result<IEnumerable<SelectListItemDto>>>;
public class GetSelectListCropPlantingsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetSelectListCropPlantingsQuery, Result<IEnumerable<SelectListItemDto>>>
{
    public async Task<Result<IEnumerable<SelectListItemDto>>> Handle(GetSelectListCropPlantingsQuery request, CancellationToken cancellationToken)
    {
        var query = context.CropPlantings.AsQueryable();
        if(!string.IsNullOrEmpty(request.FieldId))
        {
            query = query.Where(x => x.FieldId == request.FieldId);
        }    
        var result=await query.OrderByDescending(x => x.PlantingDate)
                              .Select(x => new SelectListItemDto(x.Id, x.PlantingCode))
                              .ToListAsync(cancellationToken);
        return Result<IEnumerable<SelectListItemDto>>.Success(result);
    }
}