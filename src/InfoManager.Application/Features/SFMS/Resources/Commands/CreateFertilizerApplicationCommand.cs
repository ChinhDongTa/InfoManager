namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record CreateFertilizerApplicationCommand : IRequest<Result<string>>
{
    public required string FarmId { get; init; }
    public required string FertilizerId { get; init; }
    public required DateTimeOffset AppliedDate { get; init; }
    public required decimal AppliedQuantity { get; init; }
    public string? FieldId { get; init; }
    public string? CropPlantingId { get; init; }
    public string? FertilizationPlanId { get; init; }
    public required string Unit { get; init; }
    public string? ApplicationMethod { get; init; }
    public string? AppliedBy { get; init; }
    public decimal? Cost { get; init; }
    public string? Notes { get; init; }
}

public class CreateFertilizerApplicationCommandHandler : BaseCreateCommandHandler<CreateFertilizerApplicationCommand, FertilizerApplication>
{
    public CreateFertilizerApplicationCommandHandler(IApplicationDbContext context,
                                                     IValidator<CreateFertilizerApplicationCommand> validator,
                                                     ILogger<CreateFertilizerApplicationCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(FertilizerApplication entity, CancellationToken cancellationToken)
        => await Context.FertilizerApplications.AddAsync(entity, cancellationToken);

    protected override Task<FertilizerApplication> CreateEntity(CreateFertilizerApplicationCommand request)
        => Task.FromResult(new FertilizerApplication
        {
            FarmId = request.FarmId,
            FertilizerId = request.FertilizerId,
            AppliedDate = request.AppliedDate,
            AppliedQuantity = request.AppliedQuantity,
            FieldId = request.FieldId,
            CropPlantingId = request.CropPlantingId,
            FertilizationPlanId = request.FertilizationPlanId,
            Unit = request.Unit,
            ApplicationMethod = request.ApplicationMethod,
            AppliedBy = request.AppliedBy,
            Cost = request.Cost,
            Notes = request.Notes
        });
}

public class CreateFertilizerApplicationCommandValidator : AbstractValidator<CreateFertilizerApplicationCommand>
{
    public CreateFertilizerApplicationCommandValidator()
    {
        RuleFor(x => x.FarmId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));
        RuleFor(x => x.FertilizerId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID phân bón"));
        RuleFor(x => x.AppliedQuantity).GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Số lượng đã bón", 0));
        RuleFor(x => x.Unit).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(20).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 20));
        RuleFor(x => x.ApplicationMethod).MaximumLength(100).When(x => !string.IsNullOrEmpty(x.ApplicationMethod))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Cách bón", 100));
        RuleFor(x => x.AppliedBy).MaximumLength(200).When(x => !string.IsNullOrEmpty(x.AppliedBy))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người thực hiện", 200));
        RuleFor(x => x.Cost).GreaterThanOrEqualTo(0).When(x => x.Cost.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí", 0));
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}

