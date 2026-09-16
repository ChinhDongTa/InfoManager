namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetHREmployeeByIdQuery(string Id) : IRequest<Result<HREmployeeDto?>>;

public class GetHREmployeeByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHREmployeeByIdQuery, Result<HREmployeeDto?>>
{
    public async Task<Result<HREmployeeDto?>> Handle(GetHREmployeeByIdQuery request, CancellationToken ct)
    {
        var result = await context.HREmployees
            .Where(x => x.Id == request.Id)
            .ToHREmployeeDto()
            .SingleOrNotFoundAsync(nameof(HREmployee), request.Id, ct);
        return result;
    }
}