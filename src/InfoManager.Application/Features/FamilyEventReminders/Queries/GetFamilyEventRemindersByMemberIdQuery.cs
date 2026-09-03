using InfoManager.Shared.Dtos.FamilyEventReminders;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Features.FamilyEventReminders.Queries;

public record GetFamilyEventRemindersByMemberIdQuery(string FamilyMemberId, int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<FamilyEventReminderSummaryDto>>>;
public class GetFamilyEventRemindersByMemberIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFamilyEventRemindersByMemberIdQuery, Result<PaginatedList<FamilyEventReminderSummaryDto>>>
{
    public async Task<Result<PaginatedList<FamilyEventReminderSummaryDto>>> Handle(GetFamilyEventRemindersByMemberIdQuery request, CancellationToken cancellationToken)
    {
        var query = context.FamilyEventReminders
            .Where(r => r.FamilyEvent != null && r.FamilyEvent.FamilyMemberId == request.FamilyMemberId)
            .AsQueryable();
        var paginated = await query
            .ApplySorting()
            .ToFamilyEventReminderSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<FamilyEventReminderSummaryDto>>.Success(paginated);
    }
}
