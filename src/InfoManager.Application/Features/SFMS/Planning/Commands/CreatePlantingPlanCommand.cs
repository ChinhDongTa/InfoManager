namespace InfoManager.Application.Features.SFMS.Planning.Commands;

/// <summary>
/// Command tạo mới kế hoạch trồng.
/// </summary>
public record CreatePlantingPlanCommand : IRequest<Result<string>>
{
    /// <summary>
    /// ID chu kỳ trồng. Bắt buộc.
    /// </summary>
    public required string CropCycleId { get; init; }

    /// <summary>
    /// Tên kế hoạch. Bắt buộc. MaxLength: 200.
    /// </summary>
    public required string PlanName { get; init; }

    /// <summary>
    /// Phân bổ thửa ruộng. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? FieldAllocation { get; init; }

    /// <summary>
    /// Phương pháp trồng. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? PlantingMethod { get; init; }

    /// <summary>
    /// Lượng giống cần. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? SeedQuantityRequired { get; init; }

    /// <summary>
    /// Nguồn giống. Tùy chọn. MaxLength: 200.
    /// </summary>
    public string? SeedSource { get; init; }

    /// <summary>
    /// Chuẩn bị luống / đất gieo. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? SeedbedPreparation { get; init; }

    /// <summary>
    /// Tỷ lệ nảy mầm kỳ vọng (%). Tùy chọn. Range: 0-100.
    /// </summary>
    public decimal? ExpectedGerminationRate { get; init; }

    /// <summary>
    /// Kế hoạch tưới. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? IrrigationPlan { get; init; }

    /// <summary>
    /// Kế hoạch bón phân. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? FertilizationPlan { get; init; }

    /// <summary>
    /// Nhu cầu nhân công. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? LaborRequirement { get; init; }

    /// <summary>
    /// Thiết bị cần dùng. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? EquipmentRequired { get; init; }

    /// <summary>
    /// Trạng thái kế hoạch. Mặc định Draft.
    /// </summary>
    public PlanStatus Status { get; init; } = PlanStatus.Draft;

    /// <summary>
    /// Ghi chú. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? Notes { get; init; }
}

public class CreatePlantingPlanCommandHandler : BaseCreateCommandHandler<CreatePlantingPlanCommand, PlantingPlan>
{
    public CreatePlantingPlanCommandHandler(IApplicationDbContext context,
                                            IValidator<CreatePlantingPlanCommand> validator,
                                            ILogger<CreatePlantingPlanCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(PlantingPlan entity, CancellationToken ct)
    {
        await Context.PlantingPlans.AddAsync(entity, ct);
    }

    protected override async Task<PlantingPlan> CreateEntity(CreatePlantingPlanCommand request)
    {
        return new PlantingPlan
        {
            CropCycleId = request.CropCycleId,
            PlanName = request.PlanName,
            FieldAllocation = request.FieldAllocation,
            PlantingMethod = request.PlantingMethod,
            SeedQuantityRequired = request.SeedQuantityRequired,
            SeedSource = request.SeedSource,
            SeedbedPreparation = request.SeedbedPreparation,
            ExpectedGerminationRate = request.ExpectedGerminationRate,
            IrrigationPlan = request.IrrigationPlan,
            FertilizationPlan = request.FertilizationPlan,
            LaborRequirement = request.LaborRequirement,
            EquipmentRequired = request.EquipmentRequired,
            Status = request.Status,
            Notes = request.Notes
        };
    }
}

public class CreatePlantingPlanCommandValidator : AbstractValidator<CreatePlantingPlanCommand>
{
    public CreatePlantingPlanCommandValidator()
    {
        RuleFor(x => x.CropCycleId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID chu kỳ trồng"));

        RuleFor(x => x.PlanName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên kế hoạch"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên kế hoạch", 200));

        RuleFor(x => x.FieldAllocation)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.FieldAllocation))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phân bổ thửa ruộng", 1000));

        RuleFor(x => x.PlantingMethod)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.PlantingMethod))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phương pháp trồng", 100));

        RuleFor(x => x.SeedQuantityRequired)
            .GreaterThanOrEqualTo(0).When(x => x.SeedQuantityRequired.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Lượng giống cần", 0));

        RuleFor(x => x.SeedSource)
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.SeedSource))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nguồn giống", 200));

        RuleFor(x => x.SeedbedPreparation)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.SeedbedPreparation))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Chuẩn bị luống / đất gieo", 500));

        RuleFor(x => x.ExpectedGerminationRate)
            .InclusiveBetween(0, 100).When(x => x.ExpectedGerminationRate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Tỷ lệ nảy mầm kỳ vọng", 0, 100));

        RuleFor(x => x.IrrigationPlan)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.IrrigationPlan))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Kế hoạch tưới", 500));

        RuleFor(x => x.FertilizationPlan)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.FertilizationPlan))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Kế hoạch bón phân", 500));

        RuleFor(x => x.LaborRequirement)
            .GreaterThanOrEqualTo(0).When(x => x.LaborRequirement.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Nhu cầu nhân công", 0));

        RuleFor(x => x.EquipmentRequired)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.EquipmentRequired))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Thiết bị cần dùng", 500));

        RuleFor(x => x.Notes)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
    }
}