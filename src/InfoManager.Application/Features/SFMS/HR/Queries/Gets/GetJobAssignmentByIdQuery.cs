namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetJobAssignmentByIdQuery(string Id) : IRequest<Result<JobAssignmentDto?>>;
public class GetJobAssignmentByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetJobAssignmentByIdQuery, Result<JobAssignmentDto?>>
{
    public async Task<Result<JobAssignmentDto?>> Handle(GetJobAssignmentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.JobAssignments
            .Where(x => x.Id == request.Id)
            .ToJobAssignmentDto()
            .SingleOrNotFoundAsync(nameof(JobAssignment), request.Id, cancellationToken);
        return result;
    }
}
