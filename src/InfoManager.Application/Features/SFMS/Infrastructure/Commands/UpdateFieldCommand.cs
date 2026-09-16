namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

public record UpdateFieldCommand : IRequest<Result>
{
    /// <summary>ID thửa ruộng. Bắt buộc.</summary>
    public required string Id { get; init; }

    public string? Name { get; init; }
    public string? Description { get; init; }
    public decimal? Area { get; init; }
    public string? FarmId { get; init; }
    public string? SoilType { get; init; }
    public SoilCondition? SoilCondition { get; init; }
    public decimal? Elevation { get; init; }
    public decimal? Latitude { get; init; }
    public decimal? Longitude { get; init; }
    public FieldStatus? Status { get; init; }
    public DateTimeOffset? LastPreparationDate { get; init; }
    public string? DrainageCondition { get; init; }
    public bool? HasIrrigation { get; init; }
}

public class UpdateFieldCommandHandler : BaseUpdateCommandHandler<UpdateFieldCommand, Field>
{
    public UpdateFieldCommandHandler(IApplicationDbContext context,
                                      IValidator<UpdateFieldCommand> validator,
                                      ILogger<UpdateFieldCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task<Field?> GetEntityAsync(UpdateFieldCommand request, CancellationToken cancellationToken)
    {
        return await Context.Fields.FindAsync([request.Id], cancellationToken);
    }

    protected override async Task UpdateEntityProperties(Field entity, UpdateFieldCommand request)
    {
        if (request.Name.HasValueAndIsDifferentFrom(entity.Name))
            entity.Name = request.Name!;
        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description;
        if (request.Area.HasValueAndIsDifferentFrom(entity.Area))
            entity.Area = request.Area!.Value;
        if (request.FarmId.HasValueAndIsDifferentFrom(entity.FarmId))
            entity.FarmId = request.FarmId!;
        if (request.SoilType.IsDifferentFrom(entity.SoilType))
            entity.SoilType = request.SoilType;
        if (request.SoilCondition.IsDifferentFrom(entity.SoilCondition))
            entity.SoilCondition = request.SoilCondition;
        if (request.Elevation.IsDifferentFrom(entity.Elevation))
            entity.Elevation = request.Elevation;
        if (request.Latitude.IsDifferentFrom(entity.Latitude))
            entity.Latitude = request.Latitude;
        if (request.Longitude.IsDifferentFrom(entity.Longitude))
            entity.Longitude = request.Longitude;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
        if (request.LastPreparationDate.IsDifferentFrom(entity.LastPreparationDate))
            entity.LastPreparationDate = request.LastPreparationDate;
        if (request.DrainageCondition.IsDifferentFrom(entity.DrainageCondition))
            entity.DrainageCondition = request.DrainageCondition;
        if (request.HasIrrigation.HasValueAndIsDifferentFrom(entity.HasIrrigation))
            entity.HasIrrigation = request.HasIrrigation!.Value;
    }
}

public class UpdateFieldCommandValidator : AbstractValidator<UpdateFieldCommand>
{
    public UpdateFieldCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).MaximumLength(100).When(x => x.Name is not null);
        RuleFor(x => x.Description).MaximumLength(500);
        RuleFor(x => x.Area).GreaterThan(0).When(x => x.Area.HasValue);
        RuleFor(x => x.SoilType).MaximumLength(50);
        RuleFor(x => x.SoilCondition).IsInEnum().When(x => x.SoilCondition.HasValue);
        RuleFor(x => x.Status).IsInEnum().When(x => x.Status.HasValue);
        RuleFor(x => x.DrainageCondition).MaximumLength(50);
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90).When(x => x.Latitude.HasValue);
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180).When(x => x.Longitude.HasValue);
    }
}