namespace InfoManager.Application.Features.SFMS.Agricultural.Queries.Gets;

public record GetCropScheduleByIdQuery(string Id) : IRequest<Result<CropScheduleDto?>>;

public class GetCropScheduleByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCropScheduleByIdQuery, Result<CropScheduleDto?>>
{
    public async Task<Result<CropScheduleDto?>> Handle(GetCropScheduleByIdQuery request, CancellationToken ct)
    {
        return await context.CropSchedules.Where(x => x.Id == request.Id)
            .ToCropScheduleDto()
            .SingleOrNotFoundAsync(nameof(CropSchedule), request.Id, ct);
    }
}