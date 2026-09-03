namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

public record CreateFieldCommand : IRequest<Result<string>>
{
    /// <summary>Tên thửa ruộng. Bắt buộc, tối đa 100 ký tự.</summary>
    public required string Name { get; init; }

    /// <summary>Mô tả. Tối đa 500 ký tự.</summary>
    public string? Description { get; init; }

    /// <summary>Diện tích (hecta). > 0.</summary>
    public decimal Area { get; init; }

    /// <summary>ID nông trại. Bắt buộc.</summary>
    public required string FarmId { get; init; }

    /// <summary>Loại đất. Tối đa 50 ký tự.</summary>
    public string? SoilType { get; init; }

    public SoilCondition? SoilCondition { get; init; }
    public decimal? Elevation { get; init; }
    public decimal? Latitude { get; init; }
    public decimal? Longitude { get; init; }
    public FieldStatus Status { get; init; } = FieldStatus.Vacant;
    public DateTimeOffset? LastPreparationDate { get; init; }

    /// <summary>Tình trạng thoát nước. Tối đa 50 ký tự.</summary>
    public string? DrainageCondition { get; init; }

    public bool HasIrrigation { get; init; }
}

public class CreateFieldCommandHandler : BaseCreateCommandHandler<CreateFieldCommand, Field>
{
    public CreateFieldCommandHandler(IApplicationDbContext context,
                                     IValidator<CreateFieldCommand> validator,
                                     ILogger<CreateFieldCommandHandler> logger) : base(context, validator, logger)
    { }
    protected override async Task AddEntityAsync(Field entity, CancellationToken cancellationToken)
    {
        await Context.Fields.AddAsync(entity, cancellationToken);
    }
    protected override async Task<Field> CreateEntity(CreateFieldCommand request)
    {
        return new Field
        {
            Name = request.Name,
            Description = request.Description,
            Area = request.Area,
            FarmId = request.FarmId,
            SoilType = request.SoilType,
            SoilCondition = request.SoilCondition,
            Elevation = request.Elevation,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Status = request.Status,
            LastPreparationDate = request.LastPreparationDate,
            DrainageCondition = request.DrainageCondition,
            HasIrrigation = request.HasIrrigation
        };
    }
}


public class CreateFieldCommandValidator : AbstractValidator<CreateFieldCommand>
{
    public CreateFieldCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(500);
        RuleFor(x => x.Area).GreaterThan(0);
        RuleFor(x => x.FarmId).NotEmpty();
        RuleFor(x => x.SoilType).MaximumLength(50);
        RuleFor(x => x.SoilCondition).IsInEnum().When(x => x.SoilCondition.HasValue);
        RuleFor(x => x.Status).IsInEnum();
        RuleFor(x => x.DrainageCondition).MaximumLength(50);
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90).When(x => x.Latitude.HasValue);
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180).When(x => x.Longitude.HasValue);
    }
}