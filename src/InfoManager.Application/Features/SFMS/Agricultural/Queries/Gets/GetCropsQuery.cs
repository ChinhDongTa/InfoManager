namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record GetCropsQuery(int PageNumber, int PageSize) : IRequest<Result<PaginatedList<CropSummaryDto>>>;

public class GetCropsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCropsQuery, Result<PaginatedList<CropSummaryDto>>>
{
    public async Task<Result<PaginatedList<CropSummaryDto>>> Handle(GetCropsQuery request, CancellationToken ct)
    {
        var result = await context.Crops
            .ApplySorting()
            .ToCropSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<CropSummaryDto>>.Success(result);
    }
}