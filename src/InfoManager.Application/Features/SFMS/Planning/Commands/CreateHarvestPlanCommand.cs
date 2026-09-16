namespace InfoManager.Application.Features.SFMS.Planning.Commands;

/// <summary>
/// Command tạo mới kế hoạch thu hoạch.
/// </summary>
public record CreateHarvestPlanCommand : IRequest<Result<string>>
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
    /// Ngày bắt đầu thu dự kiến. Bắt buộc.
    /// </summary>
    public required DateTimeOffset ExpectedStartDate { get; init; }

    /// <summary>
    /// Ngày kết thúc thu dự kiến. Tùy chọn. Phải ≥ ngày bắt đầu nếu có.
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
    /// Trạng thái kế hoạch. Mặc định Draft.
    /// </summary>
    public PlanStatus Status { get; init; } = PlanStatus.Draft;

    /// <summary>
    /// Đánh giá rủi ro. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? RiskAssessment { get; init; }

    /// <summary>
    /// Ghi chú. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? Notes { get; init; }
}

public class CreateHarvestPlanCommandHandler : BaseCreateCommandHandler<CreateHarvestPlanCommand, HarvestPlan>
{
    public CreateHarvestPlanCommandHandler(IApplicationDbContext context,
                                           IValidator<CreateHarvestPlanCommand> validator,
                                           ILogger<CreateHarvestPlanCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(HarvestPlan entity, CancellationToken ct)
    {
        await Context.HarvestPlans.AddAsync(entity, ct);
    }

    protected override async Task<HarvestPlan> CreateEntity(CreateHarvestPlanCommand request)
    {
        return new HarvestPlan
        {
            CropCycleId = request.CropCycleId,
            PlanName = request.PlanName,
            ExpectedStartDate = request.ExpectedStartDate,
            ExpectedEndDate = request.ExpectedEndDate,
            HarvestMethod = request.HarvestMethod,
            ExpectedYield = request.ExpectedYield,
            YieldUnit = request.YieldUnit,
            LaborRequirement = request.LaborRequirement,
            EquipmentRequired = request.EquipmentRequired,
            PostHarvestProcessing = request.PostHarvestProcessing,
            StorageRequirement = request.StorageRequirement,
            StorageDuration = request.StorageDuration,
            TransportationPlan = request.TransportationPlan,
            ExpectedSaleDate = request.ExpectedSaleDate,
            TargetBuyer = request.TargetBuyer,
            ExpectedSellingPrice = request.ExpectedSellingPrice,
            Status = request.Status,
            RiskAssessment = request.RiskAssessment,
            Notes = request.Notes
        };
    }
}

public class CreateHarvestPlanCommandValidator : AbstractValidator<CreateHarvestPlanCommand>
{
    public CreateHarvestPlanCommandValidator()
    {
        RuleFor(x => x.CropCycleId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID chu kỳ trồng"));

        RuleFor(x => x.PlanName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên kế hoạch"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên kế hoạch", 200));

        RuleFor(x => x.ExpectedEndDate)
            .GreaterThanOrEqualTo(x => x.ExpectedStartDate)
            .When(x => x.ExpectedEndDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày kết thúc thu dự kiến phải lớn hơn hoặc bằng ngày bắt đầu"));

        RuleFor(x => x.HarvestMethod)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.HarvestMethod))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phương pháp thu hoạch", 100));

        RuleFor(x => x.ExpectedYield)
            .GreaterThanOrEqualTo(0).When(x => x.ExpectedYield.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Sản lượng kỳ vọng", 0));

        RuleFor(x => x.YieldUnit)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.YieldUnit))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị sản lượng", 50));

        RuleFor(x => x.LaborRequirement)
            .GreaterThanOrEqualTo(0).When(x => x.LaborRequirement.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Nhu cầu nhân công", 0));

        RuleFor(x => x.EquipmentRequired)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.EquipmentRequired))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Thiết bị cần dùng", 500));

        RuleFor(x => x.PostHarvestProcessing)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.PostHarvestProcessing))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Kế hoạch sơ chế", 1000));

        RuleFor(x => x.StorageRequirement)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.StorageRequirement))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nhu cầu kho chứa", 500));

        RuleFor(x => x.StorageDuration)
            .GreaterThanOrEqualTo(0).When(x => x.StorageDuration.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Thời gian lưu kho", 0));

        RuleFor(x => x.TransportationPlan)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.TransportationPlan))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Kế hoạch vận chuyển", 500));

        RuleFor(x => x.TargetBuyer)
            .MaximumLength(300).When(x => !string.IsNullOrEmpty(x.TargetBuyer))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Khách hàng mục tiêu", 300));

        RuleFor(x => x.ExpectedSellingPrice)
            .GreaterThanOrEqualTo(0).When(x => x.ExpectedSellingPrice.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Giá bán dự kiến", 0));

        RuleFor(x => x.RiskAssessment)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.RiskAssessment))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đánh giá rủi ro", 1000));

        RuleFor(x => x.Notes)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
    }
}