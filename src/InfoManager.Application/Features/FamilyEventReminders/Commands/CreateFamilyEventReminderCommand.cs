namespace InfoManager.Application.Features.FamilyEventReminders.Commands;

public record CreateFamilyEventReminderCommand : IRequest<Result<string>>
{
    public string FamilyEventId { get; init; } = default!;
    public int DaysBefore { get; init; } = 7;
    public TimeOnly? RemindTime { get; init; } = null;          // null = 08:00 mặc định
    public ReminderChannel Channel { get; init; } = ReminderChannel.Push;
    public bool IsEnabled { get; init; } = true;
    public string? Note { get; init; } = null;
}

public class CreateFamilyEventReminderCommandHandler : BaseCreateCommandHandler<CreateFamilyEventReminderCommand, FamilyEventReminder>
{
    public CreateFamilyEventReminderCommandHandler(IApplicationDbContext context,
                                                   IValidator<CreateFamilyEventReminderCommand> validator,
                                                   ILogger<CreateFamilyEventReminderCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task AddEntityAsync(FamilyEventReminder entity, CancellationToken ct)
    {
        await Context.FamilyEventReminders.AddAsync(entity, ct);
    }

    protected override async Task<FamilyEventReminder> CreateEntity(CreateFamilyEventReminderCommand request)
    {
        return new FamilyEventReminder
        {
            FamilyEventId = request.FamilyEventId,
            DaysBefore = request.DaysBefore,
            RemindTime = request.RemindTime ?? new TimeOnly(8, 0),
            Channel = request.Channel,
            IsEnabled = request.IsEnabled,
            Note = request.Note
        };
    }
}

public class CreateFamilyEventReminderCommandValidator : AbstractValidator<CreateFamilyEventReminderCommand>
{
    public CreateFamilyEventReminderCommandValidator()
    {
        RuleFor(x => x.FamilyEventId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("FamilyEventId"));
        RuleFor(x => x.DaysBefore)
            .GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorOutOfRange("DaysBefore", 0, 100));
        RuleFor(x => x.Note)
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("Note", 500))
            .When(x => !string.IsNullOrEmpty(x.Note));
    }
}