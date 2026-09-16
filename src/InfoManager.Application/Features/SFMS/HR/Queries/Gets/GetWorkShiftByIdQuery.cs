namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetWorkShiftByIdQuery(string Id) : IRequest<Result<WorkShiftDto?>>;

public class GetWorkShiftByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetWorkShiftByIdQuery, Result<WorkShiftDto?>>
{
    public async Task<Result<WorkShiftDto?>> Handle(GetWorkShiftByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.WorkShifts
            .Where(x => x.Id == request.Id)
            .ToWorkShiftDto()
            .SingleOrNotFoundAsync(nameof(WorkShift), request.Id, cancellationToken);
        return result;
    }
}