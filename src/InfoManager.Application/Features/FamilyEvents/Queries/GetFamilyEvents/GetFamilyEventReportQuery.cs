using InfoManager.Shared.Dtos.FamilyEvents;

namespace InfoManager.Application.Features.FamilyEvents.Queries.GetFamilyEvents;

public record GetFamilyEventReportQuery(int NumMonth) : IRequest<Result<List<FamilyEventReportDto>>>;
public class GetFamilyEventReportQueryHandler(IApplicationDbContext Context) : IRequestHandler<GetFamilyEventReportQuery, Result<List<FamilyEventReportDto>>>
{
    public async Task<Result<List<FamilyEventReportDto>>> Handle(GetFamilyEventReportQuery request, CancellationToken ct)
    {
        var currentMonth = DateTime.Now.Month;
        var months = NumberExtension.GetMonthsRange(currentMonth, request.NumMonth);

        var events = Context.FamilyEvents
            .AsNoTracking()
            .Where(e => months.Contains(e.EventDate.Month))
            .OrderBy(x => x.EventDate.Month)
            .ThenBy(x => x.EventDate.Day)
            .Select(x => new FamilyEventReportDto(x.Id,
                                                  x.FamilyMember!.FullName,
                                                  x.EventDate,
                                                  x.EventType.ToDisplayName()));

        return Result<List<FamilyEventReportDto>>.Success(await events.ToListAsync(ct));
    }
}