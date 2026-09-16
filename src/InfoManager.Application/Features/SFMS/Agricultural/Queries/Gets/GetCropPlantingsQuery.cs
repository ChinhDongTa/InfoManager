namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record GetCropPlantingsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<CropPlantingSummaryDto>>>;

public class GetCropPlantingsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCropPlantingsQuery, Result<PaginatedList<CropPlantingSummaryDto>>>
{
    public async Task<Result<PaginatedList<CropPlantingSummaryDto>>> Handle(GetCropPlantingsQuery request, CancellationToken ct)
    {
        var result = await context.CropPlantings
            .ApplySorting()
            .ToCropPlantingSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<CropPlantingSummaryDto>>.Success(result);
    }
}