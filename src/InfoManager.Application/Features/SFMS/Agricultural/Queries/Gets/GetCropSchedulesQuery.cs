namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record GetCropSchedulesQuery(int PageIndex, int PageSize) : IRequest<Result<PaginatedList<CropScheduleSummaryDto>>>;
public class GetCropSchedulesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCropSchedulesQuery, Result<PaginatedList<CropScheduleSummaryDto>>>
{
    public async Task<Result<PaginatedList<CropScheduleSummaryDto>>> Handle(GetCropSchedulesQuery request, CancellationToken cancellationToken)
    {
        var result = await context.CropSchedules
            .ApplySorting()
            .ToCropScheduleSummaryDto()
            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);
        return Result<PaginatedList<CropScheduleSummaryDto>>.Success(result);
    }
}