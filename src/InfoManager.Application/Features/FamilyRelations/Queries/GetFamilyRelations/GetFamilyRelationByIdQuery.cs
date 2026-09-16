using InfoManager.Shared.Dtos.FamilyRelations;

namespace InfoManager.Application.Features.FamilyRelations.Queries.GetFamilyRelations;

public record GetFamilyRelationByIdQuery(string Id) : IRequest<Result<FamilyRelationDto?>>;

public class GetFamilyRelationByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFamilyRelationByIdQuery, Result<FamilyRelationDto?>>
{
    public async Task<Result<FamilyRelationDto?>> Handle(GetFamilyRelationByIdQuery request, CancellationToken ct)
    {
        var result = await context.FamilyRelations
             .Where(fr => fr.Id == request.Id)
             .ToFamilyRelationDto()
             .SingleOrNotFoundAsync("FamilyRelation", request.Id, ct);
        return result;
    }
}