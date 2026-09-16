namespace InfoManager.Application.Features.SFMS.Planning.Commands;

/// <summary>
/// Command cập nhật kế hoạch trồng.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdatePlantingPlanCommand : IRequest<Result>
{
    /// <summary>
    /// ID kế hoạch. Bắt buộc. Truyền từ client (route/header).
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// ID chu kỳ trồng. Tùy chọn.
    /// </summary>
    public string? CropCycleId { get; init; }

    /// <summary>
    /// Tên kế hoạch. Tùy chọn. MaxLength: 200.
    /// </summary>
    public string? PlanName { get; init; }

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
    /// Trạng thái kế hoạch. Tùy chọn.
    /// </summary>
    public PlanStatus? Status { get; init; }

    /// <summary>
    /// Ghi chú. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? Notes { get; init; }
}

public class UpdatePlantingPlanCommandHandler : BaseUpdateCommandHandler<UpdatePlantingPlanCommand, PlantingPlan>
{
    public UpdatePlantingPlanCommandHandler(IApplicationDbContext context,
                                            IValidator<UpdatePlantingPlanCommand> validator,
                                            ILogger<UpdatePlantingPlanCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task<PlantingPlan?> GetEntityAsync(UpdatePlantingPlanCommand request, CancellationToken ct)
        => await Context.PlantingPlans.FindAsync([request.Id], ct);

    protected override async Task UpdateEntityProperties(PlantingPlan entity, UpdatePlantingPlanCommand request)
    {
        if (request.CropCycleId.HasValueAndIsDifferentFrom(entity.CropCycleId))
            entity.CropCycleId = request.CropCycleId!;

        if (request.PlanName.HasValueAndIsDifferentFrom(entity.PlanName))
            entity.PlanName = request.PlanName!;

        if (request.FieldAllocation.IsDifferentFrom(entity.FieldAllocation))
            entity.FieldAllocation = request.FieldAllocation;

        if (request.PlantingMethod.IsDifferentFrom(entity.PlantingMethod))
            entity.PlantingMethod = request.PlantingMethod;

        if (request.SeedQuantityRequired.IsDifferentFrom(entity.SeedQuantityRequired))
            entity.SeedQuantityRequired = request.SeedQuantityRequired;

        if (request.SeedSource.IsDifferentFrom(entity.SeedSource))
            entity.SeedSource = request.SeedSource;

        if (request.SeedbedPreparation.IsDifferentFrom(entity.SeedbedPreparation))
            entity.SeedbedPreparation = request.SeedbedPreparation;

        if (request.ExpectedGerminationRate.IsDifferentFrom(entity.ExpectedGerminationRate))
            entity.ExpectedGerminationRate = request.ExpectedGerminationRate;

        if (request.IrrigationPlan.IsDifferentFrom(entity.IrrigationPlan))
            entity.IrrigationPlan = request.IrrigationPlan;

        if (request.FertilizationPlan.IsDifferentFrom(entity.FertilizationPlan))
            entity.FertilizationPlan = request.FertilizationPlan;

        if (request.LaborRequirement.IsDifferentFrom(entity.LaborRequirement))
            entity.LaborRequirement = request.LaborRequirement;

        if (request.EquipmentRequired.IsDifferentFrom(entity.EquipmentRequired))
            entity.EquipmentRequired = request.EquipmentRequired;

        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;

        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
    }
}

public class UpdatePlantingPlanCommandValidator : AbstractValidator<UpdatePlantingPlanCommand>
{
    public UpdatePlantingPlanCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID kế hoạch"));

        RuleFor(x => x.CropCycleId)
            .NotEmpty().When(x => x.CropCycleId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID chu kỳ trồng"));

        RuleFor(x => x.PlanName)
            .NotEmpty().When(x => x.PlanName != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Tên kế hoạch"))
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.PlanName))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên kế hoạch", 200));

        RuleFor(x => x.FieldAllocation)
            .MaximumLength(1000).When(x => x.FieldAllocation != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phân bổ thửa ruộng", 1000));

        RuleFor(x => x.PlantingMethod)
            .MaximumLength(100).When(x => x.PlantingMethod != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phương pháp trồng", 100));

        RuleFor(x => x.SeedQuantityRequired)
            .GreaterThanOrEqualTo(0).When(x => x.SeedQuantityRequired.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Lượng giống cần", 0));

        RuleFor(x => x.SeedSource)
            .MaximumLength(200).When(x => x.SeedSource != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nguồn giống", 200));

        RuleFor(x => x.SeedbedPreparation)
            .MaximumLength(500).When(x => x.SeedbedPreparation != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Chuẩn bị luống / đất gieo", 500));

        RuleFor(x => x.ExpectedGerminationRate)
            .InclusiveBetween(0, 100).When(x => x.ExpectedGerminationRate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Tỷ lệ nảy mầm kỳ vọng", 0, 100));

        RuleFor(x => x.IrrigationPlan)
            .MaximumLength(500).When(x => x.IrrigationPlan != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Kế hoạch tưới", 500));

        RuleFor(x => x.FertilizationPlan)
            .MaximumLength(500).When(x => x.FertilizationPlan != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Kế hoạch bón phân", 500));

        RuleFor(x => x.LaborRequirement)
            .GreaterThanOrEqualTo(0).When(x => x.LaborRequirement.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Nhu cầu nhân công", 0));

        RuleFor(x => x.EquipmentRequired)
            .MaximumLength(500).When(x => x.EquipmentRequired != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Thiết bị cần dùng", 500));

        RuleFor(x => x.Notes)
            .MaximumLength(1000).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
    }
}