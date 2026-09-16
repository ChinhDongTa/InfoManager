using InfoManager.Shared.Dtos.FamilyEventReminders;

namespace InfoManager.Application.Features.FamilyEventReminders.Queries;

public record SearchFamilyEventRemindersQuery : IRequest<Result<PaginatedList<FamilyEventReminderSummaryDto>>>
{
    public int? MinDaysBefore { get; init; }
    public int? MaxDaysBefore { get; init; }
    public ReminderChannel? Channel { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 20;
}

public class SearchFamilyEventRemindersQueryHandler(IApplicationDbContext context) : IRequestHandler<SearchFamilyEventRemindersQuery, Result<PaginatedList<FamilyEventReminderSummaryDto>>>
{
    public async Task<Result<PaginatedList<FamilyEventReminderSummaryDto>>> Handle(SearchFamilyEventRemindersQuery request, CancellationToken ct)
    {
        var query = context.FamilyEventReminders.AsQueryable();

        if (request.MinDaysBefore.HasValue)
        {
            query = query.Where(r => r.DaysBefore >= request.MinDaysBefore.Value);
        }
        if (request.MaxDaysBefore.HasValue)
        {
            query = query.Where(r => r.DaysBefore <= request.MaxDaysBefore.Value);
        }
        if (request.Channel.HasValue)
        {
            query = query.Where(r => r.Channel == request.Channel.Value);
        }

        var paginated = await query
            .ApplySorting()
            .ToFamilyEventReminderSummaryDto()
            .PaginatedListAsync(request.PageNumber, request.PageSize, ct);
        return Result<PaginatedList<FamilyEventReminderSummaryDto>>.Success(paginated);
    }
}