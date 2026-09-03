using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Application.Features.FamilyEventOccurrences.Commands;

public record UpdateFamilyEventOccurrenceCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public DateOnly? OccurrenceDate { get; init; }
    public string? Notes { get; init; }
    public string? Location { get; init; }
    public decimal? Cost { get; init; }
}
public class UpdateFamilyEventOccurrenceCommandHandler : BaseUpdateCommandHandler<UpdateFamilyEventOccurrenceCommand, FamilyEventOccurrence>
{
    public UpdateFamilyEventOccurrenceCommandHandler(IApplicationDbContext context,
                                                     IValidator<UpdateFamilyEventOccurrenceCommand> validator,
                                                     ILogger<UpdateFamilyEventOccurrenceCommandHandler> logger)
        : base(context, validator, logger)
    {
    }
    protected override async Task<FamilyEventOccurrence?> GetEntityAsync(UpdateFamilyEventOccurrenceCommand request, CancellationToken cancellationToken)
    {
        return await Context.FamilyEventOccurrences.FindAsync([request.Id], cancellationToken);
    }
    protected override async Task UpdateEntityProperties(FamilyEventOccurrence entity, UpdateFamilyEventOccurrenceCommand request)
    {
        if (request.OccurrenceDate.HasValueAndIsDifferentFrom(entity.OccurrenceDate))
            entity.OccurrenceDate = request.OccurrenceDate;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes?.Trim();
        if (request.Location.IsDifferentFrom(entity.Location))
            entity.Location = request.Location?.Trim();
        if (request.Cost.IsDifferentFrom(entity.Cost))
            entity.Cost = request.Cost;
    }
}
public class UpdateFamilyEventOccurrenceCommandValidator : AbstractValidator<UpdateFamilyEventOccurrenceCommand>
{
    public UpdateFamilyEventOccurrenceCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));
        RuleFor(x => x.Location).MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Location", 200))
             .When(x => !string.IsNullOrEmpty(x.Location));
        RuleFor(x => x.Notes).MaximumLength(2000).WithMessage(ErrorHelpers.GetErrorMaxLength("Notes", 2000))
            .When(x => !string.IsNullOrEmpty(x.Notes));
    }
    
}
