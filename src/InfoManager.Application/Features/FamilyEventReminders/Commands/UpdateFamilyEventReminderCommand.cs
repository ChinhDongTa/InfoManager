namespace InfoManager.Application.Features.FamilyEventReminders.Commands;

public record UpdateFamilyEventReminderCommand : IRequest<Result>
{
    public string Id { get; init; } = default!;
    public int? DaysBefore { get; init; }
    public TimeOnly? RemindTime { get; init; }
    public ReminderChannel? Channel { get; init; }
    public bool IsEnabled { get; init; }
    public string? Note { get; init; }
}

public class UpdateFamilyEventReminderCommandHandler : BaseUpdateCommandHandler<UpdateFamilyEventReminderCommand, FamilyEventReminder>
{
    public UpdateFamilyEventReminderCommandHandler(IApplicationDbContext context,
                                                    IValidator<UpdateFamilyEventReminderCommand> validator,
                                                    ILogger<UpdateFamilyEventReminderCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task<FamilyEventReminder?> GetEntityAsync(UpdateFamilyEventReminderCommand request, CancellationToken ct)
    {
        return await Context.FamilyEventReminders.FindAsync(new object[] { request.Id }, ct);
    }

    protected override async Task UpdateEntityProperties(FamilyEventReminder entity, UpdateFamilyEventReminderCommand request)
    {
        if (request.DaysBefore.HasValueAndIsDifferentFrom(entity.DaysBefore))
            entity.DaysBefore = request.DaysBefore!.Value;
        if (request.RemindTime.HasValueAndIsDifferentFrom(entity.RemindTime))
            entity.RemindTime = request.RemindTime;
        if (request.Channel.HasValueAndIsDifferentFrom(entity.Channel))
            entity.Channel = request.Channel!.Value;
        entity.IsEnabled = request.IsEnabled;
        if (request.Note.IsDifferentFrom(entity.Note))
            entity.Note = request.Note;
    }
}

public class UpdateFamilyEventReminderCommandValidator : AbstractValidator<UpdateFamilyEventReminderCommand>
{
    public UpdateFamilyEventReminderCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));
        RuleFor(x => x.DaysBefore)
            .GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorOutOfRange("DaysBefore", 0, 100))
            .When(x => x.DaysBefore.HasValue);
        RuleFor(x => x.Note)
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("Note", 500))
            .When(x => !string.IsNullOrEmpty(x.Note));
    }
}