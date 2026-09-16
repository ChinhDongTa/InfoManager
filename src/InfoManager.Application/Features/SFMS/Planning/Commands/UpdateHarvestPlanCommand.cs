namespace InfoManager.Application.Features.SFMS.Planning.Commands;

/// <summary>
/// Command cập nhật kế hoạch thu hoạch.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateHarvestPlanCommand : IRequest<Result>
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
    /// Ngày bắt đầu thu dự kiến. Tùy chọn.
    /// </summary>
    public DateTimeOffset? ExpectedStartDate { get; init; }

    /// <summary>
    /// Ngày kết thúc thu dự kiến. Tùy chọn.
    /// </summary>
    public DateTimeOffset? ExpectedEndDate { get; init; }

    /// <summary>
    /// Phương pháp thu hoạch. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? HarvestMethod { get; init; }

    /// <summary>
    /// Sản lượng kỳ vọng. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? ExpectedYield { get; init; }

    /// <summary>
    /// Đơn vị sản lượng. Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? YieldUnit { get; init; }

    /// <summary>
    /// Nhu cầu nhân công. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? LaborRequirement { get; init; }

    /// <summary>
    /// Thiết bị cần dùng. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? EquipmentRequired { get; init; }

    /// <summary>
    /// Kế hoạch sơ chế. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? PostHarvestProcessing { get; init; }

    /// <summary>
    /// Nhu cầu kho chứa. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? StorageRequirement { get; init; }

    /// <summary>
    /// Thời gian lưu kho (ngày). Tùy chọn. ≥ 0.
    /// </summary>
    public int? StorageDuration { get; init; }

    /// <summary>
    /// Kế hoạch vận chuyển. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? TransportationPlan { get; init; }

    /// <summary>
    /// Ngày bán dự kiến. Tùy chọn.
    /// </summary>
    public DateTimeOffset? ExpectedSaleDate { get; init; }

    /// <summary>
    /// Khách hàng mục tiêu. Tùy chọn. MaxLength: 300.
    /// </summary>
    public string? TargetBuyer { get; init; }

    /// <summary>
    /// Giá bán dự kiến. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? ExpectedSellingPrice { get; init; }

    /// <summary>
    /// Trạng thái kế hoạch. Tùy chọn.
    /// </summary>
    public PlanStatus? Status { get; init; }

    /// <summary>
    /// Đánh giá rủi ro. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? RiskAssessment { get; init; }

    /// <summary>
    /// Ghi chú. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? Notes { get; init; }
}

public class UpdateHarvestPlanCommandHandler : BaseUpdateCommandHandler<UpdateHarvestPlanCommand, HarvestPlan>
{
    public UpdateHarvestPlanCommandHandler(IApplicationDbContext context,
                                           IValidator<UpdateHarvestPlanCommand> validator,
                                           ILogger<UpdateHarvestPlanCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task<HarvestPlan?> GetEntityAsync(UpdateHarvestPlanCommand request, CancellationToken ct)
        => await Context.HarvestPlans.FindAsync([request.Id], ct);

    protected override async Task UpdateEntityProperties(HarvestPlan entity, UpdateHarvestPlanCommand request)
    {
        if (request.CropCycleId.HasValueAndIsDifferentFrom(entity.CropCycleId))
            entity.CropCycleId = request.CropCycleId!;

        if (request.PlanName.HasValueAndIsDifferentFrom(entity.PlanName))
            entity.PlanName = request.PlanName!;

        if (request.ExpectedStartDate.HasValueAndIsDifferentFrom(entity.ExpectedStartDate))
            entity.ExpectedStartDate = request.ExpectedStartDate!.Value;

        if (request.ExpectedEndDate.IsDifferentFrom(entity.ExpectedEndDate))
            entity.ExpectedEndDate = request.ExpectedEndDate;

        if (request.HarvestMethod.IsDifferentFrom(entity.HarvestMethod))
            entity.HarvestMethod = request.HarvestMethod;

        if (request.ExpectedYield.IsDifferentFrom(entity.ExpectedYield))
            entity.ExpectedYield = request.ExpectedYield;

        if (request.YieldUnit.IsDifferentFrom(entity.YieldUnit))
            entity.YieldUnit = request.YieldUnit;

        if (request.LaborRequirement.IsDifferentFrom(entity.LaborRequirement))
            entity.LaborRequirement = request.LaborRequirement;

        if (request.EquipmentRequired.IsDifferentFrom(entity.EquipmentRequired))
            entity.EquipmentRequired = request.EquipmentRequired;

        if (request.PostHarvestProcessing.IsDifferentFrom(entity.PostHarvestProcessing))
            entity.PostHarvestProcessing = request.PostHarvestProcessing;

        if (request.StorageRequirement.IsDifferentFrom(entity.StorageRequirement))
            entity.StorageRequirement = request.StorageRequirement;

        if (request.StorageDuration.IsDifferentFrom(entity.StorageDuration))
            entity.StorageDuration = request.StorageDuration;

        if (request.TransportationPlan.IsDifferentFrom(entity.TransportationPlan))
            entity.TransportationPlan = request.TransportationPlan;

        if (request.ExpectedSaleDate.IsDifferentFrom(entity.ExpectedSaleDate))
            entity.ExpectedSaleDate = request.ExpectedSaleDate;

        if (request.TargetBuyer.IsDifferentFrom(entity.TargetBuyer))
            entity.TargetBuyer = request.TargetBuyer;

        if (request.ExpectedSellingPrice.IsDifferentFrom(entity.ExpectedSellingPrice))
            entity.ExpectedSellingPrice = request.ExpectedSellingPrice;

        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;

        if (request.RiskAssessment.IsDifferentFrom(entity.RiskAssessment))
            entity.RiskAssessment = request.RiskAssessment;

        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
    }
}

public class UpdateHarvestPlanCommandValidator : AbstractValidator<UpdateHarvestPlanCommand>
{
    public UpdateHarvestPlanCommandValidator()
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

        RuleFor(x => x.ExpectedEndDate)
            .GreaterThanOrEqualTo(x => x.ExpectedStartDate)
            .When(x => x.ExpectedStartDate.HasValue && x.ExpectedEndDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày kết thúc thu dự kiến phải lớn hơn hoặc bằng ngày bắt đầu"));

        RuleFor(x => x.HarvestMethod)
            .MaximumLength(100).When(x => x.HarvestMethod != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phương pháp thu hoạch", 100));

        RuleFor(x => x.ExpectedYield)
            .GreaterThanOrEqualTo(0).When(x => x.ExpectedYield.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Sản lượng kỳ vọng", 0));

        RuleFor(x => x.YieldUnit)
            .MaximumLength(50).When(x => x.YieldUnit != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị sản lượng", 50));

        RuleFor(x => x.LaborRequirement)
            .GreaterThanOrEqualTo(0).When(x => x.LaborRequirement.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Nhu cầu nhân công", 0));

        RuleFor(x => x.EquipmentRequired)
            .MaximumLength(500).When(x => x.EquipmentRequired != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Thiết bị cần dùng", 500));

        RuleFor(x => x.PostHarvestProcessing)
            .MaximumLength(1000).When(x => x.PostHarvestProcessing != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Kế hoạch sơ chế", 1000));

        RuleFor(x => x.StorageRequirement)
            .MaximumLength(500).When(x => x.StorageRequirement != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nhu cầu kho chứa", 500));

        RuleFor(x => x.StorageDuration)
            .GreaterThanOrEqualTo(0).When(x => x.StorageDuration.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Thời gian lưu kho", 0));

        RuleFor(x => x.TransportationPlan)
            .MaximumLength(500).When(x => x.TransportationPlan != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Kế hoạch vận chuyển", 500));

        RuleFor(x => x.TargetBuyer)
            .MaximumLength(300).When(x => x.TargetBuyer != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Khách hàng mục tiêu", 300));

        RuleFor(x => x.ExpectedSellingPrice)
            .GreaterThanOrEqualTo(0).When(x => x.ExpectedSellingPrice.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Giá bán dự kiến", 0));

        RuleFor(x => x.RiskAssessment)
            .MaximumLength(1000).When(x => x.RiskAssessment != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đánh giá rủi ro", 1000));

        RuleFor(x => x.Notes)
            .MaximumLength(1000).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
    }
}