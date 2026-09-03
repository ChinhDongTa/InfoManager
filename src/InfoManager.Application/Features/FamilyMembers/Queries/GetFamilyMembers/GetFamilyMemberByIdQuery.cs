using InfoManager.Domain.Entities.Personal;
using InfoManager.Shared.Dtos.FamilyMembers;

namespace InfoManager.Application.Features.FamilyMembers.Queries.GetFamilyMembers;

public record GetFamilyMemberByIdQuery(string Id) : IRequest<Result<FamilyMemberDto?>>;
public class GetFamilyMemberByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFamilyMemberByIdQuery, Result<FamilyMemberDto?>>
{
    public async Task<Result<FamilyMemberDto?>> Handle(GetFamilyMemberByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.FamilyMembers
            .Where(fm => fm.Id == request.Id)
            .ToFamilyMemberDto() // Assuming you have an extension method to map to FamilyMemberDto
            .SingleOrNotFoundAsync(nameof(FamilyMember), request.Id, cancellationToken);

        return result;
    }
}
