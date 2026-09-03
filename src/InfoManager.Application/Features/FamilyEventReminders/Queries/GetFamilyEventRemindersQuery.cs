using InfoManager.Shared.Dtos.FamilyEventReminders;
using InfoManager.Shared.Models;

namespace InfoManager.Application.Features.FamilyEventReminders.Queries;

public record GetFamilyEventRemindersQuery( int PageNumber = 1, int PageSize = 20) : IRequest<Result<PaginatedList<FamilyEventReminderSummaryDto>>>;
public class GetFamilyEventRemindersQueryHandler(IApplicationDbContext context) : IRequestHandler<GetFamilyEventRemindersQuery, Result<PaginatedList<FamilyEventReminderSummaryDto>>>
{
    public async Task<Result<PaginatedList<FamilyEventReminderSummaryDto>>> Handle(GetFamilyEventRemindersQuery request, CancellationToken cancellationToken)
    {
        var query = context.FamilyEventReminders.AsQueryable();
        var paginated = await query.AsNoTracking()
            .ApplySorting()
            .ToFamilyEventReminderSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return Result<PaginatedList<FamilyEventReminderSummaryDto>>.Success(paginated);
    }
}