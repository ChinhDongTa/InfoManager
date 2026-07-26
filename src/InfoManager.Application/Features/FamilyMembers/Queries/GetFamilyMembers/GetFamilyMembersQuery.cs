using InfoManager.Shared.Dtos.FamilyMembers;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Features.FamilyMembers.Queries.GetFamilyMembers;

public record GetFamilyMembersQuery(string? FullName = null, FamilyEventType? EventType = null, int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<FamilyMemberSummaryDto>>>;
public class GetFamilyMembersQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFamilyMembersQuery, Result<PaginatedList<FamilyMemberSummaryDto>>>
{
    public async Task<Result<PaginatedList<FamilyMemberSummaryDto>>> Handle(GetFamilyMembersQuery request, CancellationToken cancellationToken)
    {
        var query = context.FamilyMembers.AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.FullName))
        {
            query = query.Where(fm => EF.Functions.ILike(fm.FullName, $"%{request.FullName}%"));
        }
        if (request.EventType.HasValue)
        {
            query = query.Where(fm => fm.FamilyEvents.Any(fe => fe.EventType == request.EventType.Value));
        }
        var paginated = await query
            .ApplySorting()
            .ToFamilyMemberSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<FamilyMemberSummaryDto>>.Success(paginated);
    }
}