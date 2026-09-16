namespace InfoManager.Application.Features.SFMS.Planning.Queries.Gets;

public record GetCropCyclesQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<CropCycleSummaryDto>>>;

public class GetCropCyclesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCropCyclesQuery, Result<PaginatedList<CropCycleSummaryDto>>>
{
    public async Task<Result<PaginatedList<CropCycleSummaryDto>>> Handle(GetCropCyclesQuery request, CancellationToken cancellationToken)
    {
        var result = await context.CropCycles
            .ApplySorting()
            .ToCropCycleSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<CropCycleSummaryDto>>.Success(result);
    }
}