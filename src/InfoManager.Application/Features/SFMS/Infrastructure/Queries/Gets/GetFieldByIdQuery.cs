namespace InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

public record GetFieldByIdQuery(string Id) : IRequest<Result<FieldSummaryDto?>>;
public class GetFieldByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFieldByIdQuery, Result<FieldSummaryDto?>>
{
    public async Task<Result<FieldSummaryDto?>> Handle(GetFieldByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Fields
            .Where(x => x.Id == request.Id)
            .ToFieldSummaryDto()
            .SingleOrNotFoundAsync(nameof(Field), request.Id, cancellationToken);
        return result;
    }
}