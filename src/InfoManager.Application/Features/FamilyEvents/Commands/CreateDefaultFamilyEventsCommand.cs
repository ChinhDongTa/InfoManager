using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Application.Features.FamilyEvents.Commands;

public record CreateDefaultFamilyEventsCommand (string MemberId) : IRequest<Result>;
public class CreateDefaultFamilyEventsCommandHandler (IApplicationDbContext _context, ILogger<CreateDefaultFamilyEventsCommandHandler> _logger) : IRequestHandler<CreateDefaultFamilyEventsCommand, Result>
{
    public async Task<Result> Handle(CreateDefaultFamilyEventsCommand request, CancellationToken cancellationToken)
    {
        var member = await _context.FamilyMembers.FindAsync(request.MemberId,cancellationToken);
        if (member is null)
        {
            return Result.NotFound("FamilyMember", request.MemberId);
        }
        await CreateDefaultEventsAsync(member, cancellationToken);
        return Result.Success(resultStatus: ResultStatus.NoContent);
    }

    public async Task CreateDefaultEventsAsync(FamilyMember member, CancellationToken ct = default)
    {
        // Lấy các EventType đã tồn tại của member này
        var existingTypes = await _context.FamilyEvents
            .Where(e => e.FamilyMemberId == member.Id)
            .Select(e => e.EventType)
            .ToListAsync(ct);

        var eventsToAdd = new List<FamilyEvent>();

        // 1. Sinh nhật
        if (member.DeathDate is null && !existingTypes.Contains(FamilyEventType.Birthday))
        {
            var birthday = new FamilyEvent
            {
                FamilyMemberId = member.Id,
                EventType = FamilyEventType.Birthday,
                Title = $"Sinh nhật {member.FullName}",
                EventDate = member.BirthDate,
                IsActive = true
            };

            // Thêm nhắc nhở mặc định
            birthday.Reminders.Add(new FamilyEventReminder
            {
                FamilyEventId = birthday.Id,
                DaysBefore = 7,
                RemindTime = new TimeOnly(8, 0),
                Channel = ReminderChannel.Push
            });


            eventsToAdd.Add(birthday);
        }

        // 2. Giỗ
        if (member.DeathDate.HasValue && !existingTypes.Contains(FamilyEventType.DeathAnniversary))
        {
            var death = new FamilyEvent
            {
                FamilyMemberId = member.Id,
                EventType = FamilyEventType.DeathAnniversary,
                Title = $"Giỗ {member.FullName}",
                EventDate = member.DeathDate.Value,
                IsActive = true
            };

            death.Reminders.Add(new FamilyEventReminder
            {
                FamilyEventId = death.Id,
                DaysBefore = 7,
                Channel = ReminderChannel.Push
            });

            eventsToAdd.Add(death);
        }

        if (eventsToAdd.Count > 0)
        {
            try
            {
                await _context.FamilyEvents.AddRangeAsync(eventsToAdd, ct);
                await _context.SaveChangesAsync(ct);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error creating default family events for memberId: {MemberId}", member.Id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error creating default family events for memberId: {MemberId}", member.Id);
            }
        }
    }
}