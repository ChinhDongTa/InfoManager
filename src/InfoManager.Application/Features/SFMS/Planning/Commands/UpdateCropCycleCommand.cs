namespace InfoManager.Application.Features.SFMS.Planning.Commands;

/// <summary>
/// Command cập nhật chu kỳ trồng.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateCropCycleCommand : IRequest<Result>
{
    /// <summary>
    /// ID chu kỳ. Bắt buộc. Truyền từ client (route/header).
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// ID nông trại. Tùy chọn.
    /// </summary>
    public string? FarmId { get; init; }

    /// <summary>
    /// Tên / mã chu kỳ. Tùy chọn. MaxLength: 200.
    /// </summary>
    public string? CycleName { get; init; }

    /// <summary>
    /// ID cây trồng. Tùy chọn.
    /// </summary>
    public string? CropId { get; init; }

    /// <summary>
    /// ID giống cây. Tùy chọn.
    /// </summary>
    public string? CropVarietyId { get; init; }

    /// <summary>
    /// ID lịch trồng. Tùy chọn.
    /// </summary>
    public string? CropScheduleId { get; init; }

    /// <summary>
    /// Năm bắt đầu chu kỳ. Tùy chọn.
    /// </summary>
    public int? StartYear { get; init; }

    /// <summary>
    /// Mùa vụ. Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? Season { get; init; }

    /// <summary>
    /// Ngày trồng dự kiến. Tùy chọn.
    /// </summary>
    public DateTimeOffset? PlannedPlantingDate { get; init; }

    /// <summary>
    /// Ngày thu hoạch dự kiến. Tùy chọn.
    /// </summary>
    public DateTimeOffset? PlannedHarvestDate { get; init; }

    /// <summary>
    /// Diện tích kế hoạch (hecta). Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? PlannedArea { get; init; }

    /// <summary>
    /// Trạng thái chu kỳ. Tùy chọn.
    /// </summary>
    public CropCycleStatus? Status { get; init; }

    /// <summary>
    /// Chi phí dự kiến. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? EstimatedCost { get; init; }

    /// <summary>
    /// Doanh thu dự kiến. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? EstimatedRevenue { get; init; }

    /// <summary>
    /// Lợi nhuận dự kiến. Tùy chọn.
    /// </summary>
    public decimal? EstimatedProfit { get; init; }

    /// <summary>
    /// Sản lượng kỳ vọng. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? ExpectedYield { get; init; }

    /// <summary>
    /// Thị trường mục tiêu. Tùy chọn. MaxLength: 300.
    /// </summary>
    public string? TargetMarket { get; init; }

    /// <summary>
    /// Giá bán mục tiêu. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? TargetSellingPrice { get; init; }

    /// <summary>
    /// Ghi chú chu kỳ. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? Notes { get; init; }
}

public class UpdateCropCycleCommandHandler : BaseUpdateCommandHandler<UpdateCropCycleCommand, CropCycle>
{
    public UpdateCropCycleCommandHandler(IApplicationDbContext context,
                                         IValidator<UpdateCropCycleCommand> validator,
                                         ILogger<UpdateCropCycleCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task<CropCycle?> GetEntityAsync(UpdateCropCycleCommand request, CancellationToken cancellationToken)
        => await Context.CropCycles.FindAsync([request.Id], cancellationToken);

    protected override async Task UpdateEntityProperties(CropCycle entity, UpdateCropCycleCommand request)
    {
        if (request.FarmId.HasValueAndIsDifferentFrom(entity.FarmId))
            entity.FarmId = request.FarmId!;

        if (request.CycleName.HasValueAndIsDifferentFrom(entity.CycleName))
            entity.CycleName = request.CycleName!;

        if (request.CropId.HasValueAndIsDifferentFrom(entity.CropId))
            entity.CropId = request.CropId!;

        if (request.CropVarietyId.IsDifferentFrom(entity.CropVarietyId))
            entity.CropVarietyId = request.CropVarietyId;

        if (request.CropScheduleId.IsDifferentFrom(entity.CropScheduleId))
            entity.CropScheduleId = request.CropScheduleId;

        if (request.StartYear.HasValueAndIsDifferentFrom(entity.StartYear))
            entity.StartYear = request.StartYear!.Value;

        if (request.Season.IsDifferentFrom(entity.Season))
            entity.Season = request.Season;

        if (request.PlannedPlantingDate.IsDifferentFrom(entity.PlannedPlantingDate))
            entity.PlannedPlantingDate = request.PlannedPlantingDate;

        if (request.PlannedHarvestDate.IsDifferentFrom(entity.PlannedHarvestDate))
            entity.PlannedHarvestDate = request.PlannedHarvestDate;

        if (request.PlannedArea.HasValueAndIsDifferentFrom(entity.PlannedArea))
            entity.PlannedArea = request.PlannedArea!.Value;

        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;

        if (request.EstimatedCost.IsDifferentFrom(entity.EstimatedCost))
            entity.EstimatedCost = request.EstimatedCost;

        if (request.EstimatedRevenue.IsDifferentFrom(entity.EstimatedRevenue))
            entity.EstimatedRevenue = request.EstimatedRevenue;

        if (request.EstimatedProfit.IsDifferentFrom(entity.EstimatedProfit))
            entity.EstimatedProfit = request.EstimatedProfit;

        if (request.ExpectedYield.IsDifferentFrom(entity.ExpectedYield))
            entity.ExpectedYield = request.ExpectedYield;

        if (request.TargetMarket.IsDifferentFrom(entity.TargetMarket))
            entity.TargetMarket = request.TargetMarket;

        if (request.TargetSellingPrice.IsDifferentFrom(entity.TargetSellingPrice))
            entity.TargetSellingPrice = request.TargetSellingPrice;

        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
    }
}

public class UpdateCropCycleCommandValidator : AbstractValidator<UpdateCropCycleCommand>
{
    public UpdateCropCycleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID chu kỳ"));

        RuleFor(x => x.FarmId)
            .NotEmpty().When(x => x.FarmId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));

        RuleFor(x => x.CycleName)
            .NotEmpty().When(x => x.CycleName != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Tên chu kỳ"))
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.CycleName))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên chu kỳ", 200));

        RuleFor(x => x.CropId)
            .NotEmpty().When(x => x.CropId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID cây trồng"));

        RuleFor(x => x.StartYear)
            .GreaterThan(0).When(x => x.StartYear.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Năm bắt đầu", 1));

        RuleFor(x => x.Season)
            .MaximumLength(50).When(x => x.Season != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mùa vụ", 50));

        RuleFor(x => x.PlannedHarvestDate)
            .GreaterThanOrEqualTo(x => x.PlannedPlantingDate)
            .When(x => x.PlannedPlantingDate.HasValue && x.PlannedHarvestDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày thu hoạch dự kiến phải lớn hơn hoặc bằng ngày trồng dự kiến"));

        RuleFor(x => x.PlannedArea)
            .GreaterThanOrEqualTo(0).When(x => x.PlannedArea.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Diện tích kế hoạch", 0));

        RuleFor(x => x.EstimatedCost)
            .GreaterThanOrEqualTo(0).When(x => x.EstimatedCost.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí dự kiến", 0));

        RuleFor(x => x.EstimatedRevenue)
            .GreaterThanOrEqualTo(0).When(x => x.EstimatedRevenue.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Doanh thu dự kiến", 0));

        RuleFor(x => x.ExpectedYield)
            .GreaterThanOrEqualTo(0).When(x => x.ExpectedYield.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Sản lượng kỳ vọng", 0));

        RuleFor(x => x.TargetMarket)
            .MaximumLength(300).When(x => x.TargetMarket != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Thị trường mục tiêu", 300));

        RuleFor(x => x.TargetSellingPrice)
            .GreaterThanOrEqualTo(0).When(x => x.TargetSellingPrice.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Giá bán mục tiêu", 0));

        RuleFor(x => x.Notes)
            .MaximumLength(1000).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
    }
}