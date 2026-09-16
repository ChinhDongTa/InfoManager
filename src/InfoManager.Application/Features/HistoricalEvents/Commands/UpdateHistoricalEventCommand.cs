namespace InfoManager.Application.Features.HistoricalEvents.Commands;

public record UpdateHistoricalEventCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public DateOnly? EventDate { get; init; }
    public string? Title { get; init; }
    public HistoricalEventType? EventType { get; init; }
    public string? Location { get; init; }
    public string? Summary { get; init; }
    public string? ReferenceSource { get; init; }
}

public class UpdateHistoricalEventCommandHandler : BaseUpdateCommandHandler<UpdateHistoricalEventCommand, HistoricalEvent>
{
    public UpdateHistoricalEventCommandHandler(IApplicationDbContext context, IValidator<UpdateHistoricalEventCommand> validator,
                                             ILogger<UpdateHistoricalEventCommandHandler> logger)
        : base(context, validator, logger)
    {
    }

    protected override async Task<HistoricalEvent?> GetEntityAsync(UpdateHistoricalEventCommand request, CancellationToken ct)
    {
        return await Context.HistoricalEvents.FindAsync([request.Id], ct);
    }

    protected override async Task UpdateEntityProperties(HistoricalEvent entity, UpdateHistoricalEventCommand request)
    {
        if (request.EventDate.IsDifferentFrom(entity.EventDate))
            entity.EventDate = request.EventDate!.Value;

        if (request.Title.HasValueAndIsDifferentFrom(entity.Title))
            entity.Title = request.Title!;

        if (request.EventType.HasValueAndIsDifferentFrom(entity.EventType))
            entity.EventType = request.EventType!.Value;

        if (request.Location.IsDifferentFrom(entity.Location))
            entity.Location = request.Location;

        if (request.Summary.HasValueAndIsDifferentFrom(entity.Summary))
            entity.Summary = request.Summary!;

        if (request.ReferenceSource.IsDifferentFrom(entity.ReferenceSource))
            entity.ReferenceSource = request.ReferenceSource;
    }
}

public class UpdateHistoricalEventCommandValidator : AbstractValidator<UpdateHistoricalEventCommand>
{
    public UpdateHistoricalEventCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));

        RuleFor(x => x.Title)
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("Title", 500))
            .When(x => !string.IsNullOrEmpty(x.Title));
    }
}