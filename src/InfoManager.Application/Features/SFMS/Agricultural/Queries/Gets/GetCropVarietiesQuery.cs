namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;
public record GetCropVarietiesQuery(int PageIndex, int PageSize) : IRequest<Result<PaginatedList<CropVarietySummaryDto>>>;
public class GetCropVarietiesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCropVarietiesQuery, Result<PaginatedList<CropVarietySummaryDto>>>
{
    public async Task<Result<PaginatedList<CropVarietySummaryDto>>> Handle(GetCropVarietiesQuery request, CancellationToken cancellationToken)
    {
        var result = await context.CropVarieties
            .ApplySorting()
            .ToCropVarietySummaryDto()
            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);
        return Result<PaginatedList<CropVarietySummaryDto>>.Success(result);
    }
}
