namespace InfoManager.Application.Features.FamilyEventOccurrences.Commands;

public record CreateFamilyEventOccurrenceCommand : IRequest<Result<string>>
{
    public DateOnly? OccurrenceDate { get; init; }
    public string? Notes { get; init; }
    public string? Location { get; init; }
    public required string FamilyEventId { get; init; }
    public decimal? Cost { get; init; }
}

public class CreateFamilyEventOccurrenceCommandHandler : BaseCreateCommandHandler<CreateFamilyEventOccurrenceCommand, FamilyEventOccurrence>
{
    public CreateFamilyEventOccurrenceCommandHandler(IApplicationDbContext context,
                                                     IValidator<CreateFamilyEventOccurrenceCommand> validator,
                                                     ILogger<CreateFamilyEventOccurrenceCommandHandler> logger)
        : base(context, validator, logger)
    {
    }

    protected override async Task AddEntityAsync(FamilyEventOccurrence entity, CancellationToken ct)
    {
        await Context.FamilyEventOccurrences.AddAsync(entity, ct);
    }

    protected override async Task<FamilyEventOccurrence> CreateEntity(CreateFamilyEventOccurrenceCommand request)
    {
        return new FamilyEventOccurrence
        {
            OccurrenceDate = request.OccurrenceDate,
            Notes = request.Notes?.Trim(),
            Location = request.Location?.Trim(),
            FamilyEventId = request.FamilyEventId,
            Cost = request.Cost
        };
    }
}

public class CreateFamilyEventOccurrenceCommandValidator : AbstractValidator<CreateFamilyEventOccurrenceCommand>
{
    public CreateFamilyEventOccurrenceCommandValidator()
    {
        RuleFor(x => x.FamilyEventId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("FamilyEventId"));
        RuleFor(x => x.Location).MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Location", 200))
            .When(x => !string.IsNullOrEmpty(x.Location));
        RuleFor(x => x.Notes).MaximumLength(2000).WithMessage(ErrorHelpers.GetErrorMaxLength("Notes", 2000))
            .When(x => !string.IsNullOrEmpty(x.Notes));
    }
}