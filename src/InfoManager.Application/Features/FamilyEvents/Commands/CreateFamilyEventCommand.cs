namespace InfoManager.Application.Features.FamilyEvents.Commands;

public record CreateFamilyEventCommand : IRequest<Result<string>>
{
    public required string FamilyMemberId { get; init; }
    public DateOnly EventDate { get; init; }
    public string Title { get; init; } = string.Empty;
    public FamilyEventType EventType { get; init; }
    public string? Location { get; init; } = string.Empty;
}

public class CreateFamilyEventCommandHandler : BaseCreateCommandHandler<CreateFamilyEventCommand, FamilyEvent>
{
    public CreateFamilyEventCommandHandler(IApplicationDbContext context,
                                           IValidator<CreateFamilyEventCommand> validator,
                                           ILogger<CreateFamilyEventCommandHandler> logger)
        : base(context, validator, logger)
    {
    }

    protected override async Task AddEntityAsync(FamilyEvent entity, CancellationToken ct)
    {
        // Thêm nhắc nhở mặc định
        entity.Reminders.Add(new FamilyEventReminder
        {
            FamilyEventId = entity.Id,
            DaysBefore = 7,
            RemindTime = new TimeOnly(8, 0),
            Channel = ReminderChannel.Push,
            Note = "Được tạo mặc định khi tạo sự kiện"
        });

        await Context.FamilyEvents.AddAsync(entity, ct);
    }

    protected override async Task<FamilyEvent> CreateEntity(CreateFamilyEventCommand request)
    {
        return new FamilyEvent
        {
            FamilyMemberId = request.FamilyMemberId,
            EventDate = request.EventDate,
            Title = request.Title.Trim(),
            EventType = request.EventType,
            Location = request.Location?.Trim()
        };
    }
}

public class CreateFamilyEventCommandValidator : AbstractValidator<CreateFamilyEventCommand>
{
    public CreateFamilyEventCommandValidator()
    {
        RuleFor(x => x.FamilyMemberId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("FamilyMemberId"));
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Title"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Title", 200));
        RuleFor(x => x.Location)
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Location", 100))
            .When(x => !string.IsNullOrEmpty(x.Location));
    }
}