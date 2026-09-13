namespace InfoManager.Application.Features.SFMS.HR.Queries.Gets;

public record GetDepartmentByIdQuery(string Id) : IRequest<Result<DepartmentDto?>>;
public class GetDepartmentByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetDepartmentByIdQuery, Result<DepartmentDto?>>
{
    public async Task<Result<DepartmentDto?>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Departments
            .Where(x => x.Id == request.Id)
            .ToDepartmentDto()
            .SingleOrNotFoundAsync(nameof(Department), request.Id, cancellationToken);
        return result;
    }
}