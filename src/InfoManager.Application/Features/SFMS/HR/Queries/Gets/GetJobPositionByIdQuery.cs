namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetJobPositionByIdQuery(string Id) : IRequest<Result<JobPositionDto?>>;

public class GetJobPositionByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetJobPositionByIdQuery, Result<JobPositionDto?>>
{
    public async Task<Result<JobPositionDto?>> Handle(GetJobPositionByIdQuery request, CancellationToken ct)
    {
        var result = await context.JobPositions
            .Where(x => x.Id == request.Id)
            .ToJobPositionDto()
            .SingleOrNotFoundAsync(nameof(JobPosition), request.Id, ct);
        return result;
    }
}