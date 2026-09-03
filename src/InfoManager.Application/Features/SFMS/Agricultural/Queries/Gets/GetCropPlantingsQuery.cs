namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record GetCropPlantingsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<CropPlantingSummaryDto>>>;
public class GetCropPlantingsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCropPlantingsQuery, Result<PaginatedList<CropPlantingSummaryDto>>>
{
    public async Task<Result<PaginatedList<CropPlantingSummaryDto>>> Handle(GetCropPlantingsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.CropPlantings
            .ApplySorting()
            .ToCropPlantingSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<CropPlantingSummaryDto>>.Success(result);
    }
}