namespace InfoManager.Application.Features.FamilyEvents.Commands;

public record UpdateFamilyEventCommand() : IRequest<Result>
{
    public required string Id { get; init; }
    public string? FamilyMemberId { get; init; }
    public DateOnly? EventDate { get; init; }
    public string? Title { get; init; }
    public FamilyEventType? EventType { get; init; }
    public string? Location { get; init; }
}

public class UpdateFamilyEventCommandHandler : BaseUpdateCommandHandler<UpdateFamilyEventCommand, FamilyEvent>
{
    public UpdateFamilyEventCommandHandler(IApplicationDbContext context,
                                           IValidator<UpdateFamilyEventCommand> validator,
                                           ILogger<UpdateFamilyEventCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task<FamilyEvent?> GetEntityAsync(UpdateFamilyEventCommand request, CancellationToken ct)
    {
        return await Context.FamilyEvents.FindAsync([request.Id], ct);
    }

    protected override async Task UpdateEntityProperties(FamilyEvent entity, UpdateFamilyEventCommand request)
    {
        if (request.FamilyMemberId.IsDifferentFrom(entity.FamilyMemberId))
            entity.FamilyMemberId = request.FamilyMemberId!;

        if (request.EventDate.HasValueAndIsDifferentFrom(entity.EventDate))
            entity.EventDate = request.EventDate!.Value;

        if (request.Title.HasValueAndIsDifferentFrom(entity.Title))
            entity.Title = request.Title!;

        if (request.EventType.HasValueAndIsDifferentFrom(entity.EventType))
            entity.EventType = request.EventType!.Value;

        if (request.Location.IsDifferentFrom(entity.Location))
            entity.Location = request.Location;
    }
}

public class UpdateFamilyEventCommandValidator : AbstractValidator<UpdateFamilyEventCommand>
{
    public UpdateFamilyEventCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));

        RuleFor(x => x.Title)
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Title", 200))
            .When(x => !string.IsNullOrEmpty(x.Title));
        RuleFor(x => x.Location)
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Location", 100))
            .When(x => !string.IsNullOrEmpty(x.Location));
    }
}