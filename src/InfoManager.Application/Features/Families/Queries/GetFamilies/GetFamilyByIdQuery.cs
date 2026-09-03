using InfoManager.Shared.Dtos.Families;

namespace InfoManager.Application.Features.Families.Queries.GetFamilies;

public record GetFamilyByIdQuery(string Id) : IRequest<Result<FamilyDto?>>;
public class GetFamilyByIdQueryHandler : IRequestHandler<GetFamilyByIdQuery, Result<FamilyDto?>>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<GetFamilyByIdQueryHandler> _logger;
    public GetFamilyByIdQueryHandler(IApplicationDbContext context, ILogger<GetFamilyByIdQueryHandler> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<Result<FamilyDto?>> Handle(GetFamilyByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Families
            .Where(f => f.Id == request.Id)
            .ToFamilyDto()
            .SingleOrNotFoundAsync("Family ", request.Id, cancellationToken);
    }
}
