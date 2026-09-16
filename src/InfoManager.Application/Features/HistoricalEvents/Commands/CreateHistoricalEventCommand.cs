namespace InfoManager.Application.Features.HistoricalEvents.Commands;

public record CreateHistoricalEventCommand : IRequest<Result<string>>
{
    public DateOnly? EventDate { get; init; }
    public required string Title { get; init; }
    public HistoricalEventType EventType { get; init; }
    public string? Location { get; init; }
    public required string Summary { get; init; }
    public string? ReferenceSource { get; init; }
}

public class CreateHistoricalEventCommandHandler : BaseCreateCommandHandler<CreateHistoricalEventCommand, HistoricalEvent>
{
    public CreateHistoricalEventCommandHandler(IApplicationDbContext context,
                                            IValidator<CreateHistoricalEventCommand> validator,
                                            ILogger<CreateHistoricalEventCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task<HistoricalEvent> CreateEntity(CreateHistoricalEventCommand request)
    {
        return new HistoricalEvent
        {
            EventDate = request.EventDate,
            Title = request.Title.Trim(),
            EventType = request.EventType,
            Location = request.Location?.Trim(),
            Summary = request.Summary.Trim(),
            ReferenceSource = request.ReferenceSource?.Trim()
        };
    }

    protected override async Task AddEntityAsync(HistoricalEvent entity, CancellationToken ct)
    {
        await Context.HistoricalEvents.AddAsync(entity, ct);
    }
}

public class CreateHistoricalEventCommandValidator : AbstractValidator<CreateHistoricalEventCommand>
{
    public CreateHistoricalEventCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Tên sự kiện"))
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên sự kiện", 500));
        RuleFor(x => x.Summary)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Tóm tắt sự kiện"));
    }
}