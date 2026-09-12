namespace InfoManager.Application.Features.SFMS.Planning.Commands;

/// <summary>
/// Command tạo mới chu kỳ trồng.
/// </summary>
public record CreateCropCycleCommand : IRequest<Result<string>>
{
    /// <summary>
    /// ID nông trại. Bắt buộc.
    /// </summary>
    public required string FarmId { get; init; }

    /// <summary>
    /// Tên / mã chu kỳ. Bắt buộc. MaxLength: 200.
    /// </summary>
    public required string CycleName { get; init; }

    /// <summary>
    /// ID cây trồng. Bắt buộc.
    /// </summary>
    public required string CropId { get; init; }

    /// <summary>
    /// ID giống cây. Tùy chọn.
    /// </summary>
    public string? CropVarietyId { get; init; }

    /// <summary>
    /// ID lịch trồng. Tùy chọn.
    /// </summary>
    public string? CropScheduleId { get; init; }

    /// <summary>
    /// Năm bắt đầu chu kỳ. Bắt buộc.
    /// </summary>
    public required int StartYear { get; init; }

    /// <summary>
    /// Mùa vụ. Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? Season { get; init; }

    /// <summary>
    /// Ngày trồng dự kiến. Tùy chọn.
    /// </summary>
    public DateTimeOffset? PlannedPlantingDate { get; init; }

    /// <summary>
    /// Ngày thu hoạch dự kiến. Tùy chọn. Phải ≥ ngày trồng nếu cả hai có giá trị.
    /// </summary>
    public DateTimeOffset? PlannedHarvestDate { get; init; }

    /// <summary>
    /// Diện tích kế hoạch (hecta). Bắt buộc. ≥ 0.
    /// </summary>
    public required decimal PlannedArea { get; init; }

    /// <summary>
    /// Trạng thái chu kỳ. Mặc định Planned.
    /// </summary>
    public CropCycleStatus Status { get; init; } = CropCycleStatus.Planned;

    /// <summary>
    /// Chi phí dự kiến. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? EstimatedCost { get; init; }

    /// <summary>
    /// Doanh thu dự kiến. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? EstimatedRevenue { get; init; }

    /// <summary>
    /// Lợi nhuận dự kiến. Tùy chọn. Nếu trống thì tính = Revenue - Cost.
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

public class CreateCropCycleCommandHandler : BaseCreateCommandHandler<CreateCropCycleCommand, CropCycle>
{
    public CreateCropCycleCommandHandler(IApplicationDbContext context,
                                         IValidator<CreateCropCycleCommand> validator,
                                         ILogger<CreateCropCycleCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(CropCycle entity, CancellationToken cancellationToken)
    {
        await Context.CropCycles.AddAsync(entity, cancellationToken);
    }

    protected override async Task<CropCycle> CreateEntity(CreateCropCycleCommand request)
    {
        return new CropCycle
        {
            FarmId = request.FarmId,
            CycleName = request.CycleName,
            CropId = request.CropId,
            CropVarietyId = request.CropVarietyId,
            CropScheduleId = request.CropScheduleId,
            StartYear = request.StartYear,
            Season = request.Season,
            PlannedPlantingDate = request.PlannedPlantingDate,
            PlannedHarvestDate = request.PlannedHarvestDate,
            PlannedArea = request.PlannedArea,
            Status = request.Status,
            EstimatedCost = request.EstimatedCost,
            EstimatedRevenue = request.EstimatedRevenue,
            EstimatedProfit = request.EstimatedProfit
                ?? (request.EstimatedRevenue.HasValue || request.EstimatedCost.HasValue
                    ? (request.EstimatedRevenue ?? 0) - (request.EstimatedCost ?? 0)
                    : null),
            ExpectedYield = request.ExpectedYield,
            TargetMarket = request.TargetMarket,
            TargetSellingPrice = request.TargetSellingPrice,
            Notes = request.Notes
        };
    }
}

public class CreateCropCycleCommandValidator : AbstractValidator<CreateCropCycleCommand>
{
    public CreateCropCycleCommandValidator()
    {
        RuleFor(x => x.FarmId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));

        RuleFor(x => x.CycleName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên chu kỳ"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên chu kỳ", 200));

        RuleFor(x => x.CropId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID cây trồng"));

        RuleFor(x => x.StartYear)
            .GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Năm bắt đầu", 1));

        RuleFor(x => x.Season)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.Season))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mùa vụ", 50));

        RuleFor(x => x.PlannedHarvestDate)
            .GreaterThanOrEqualTo(x => x.PlannedPlantingDate)
            .When(x => x.PlannedPlantingDate.HasValue && x.PlannedHarvestDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày thu hoạch dự kiến phải lớn hơn hoặc bằng ngày trồng dự kiến"));

        RuleFor(x => x.PlannedArea)
            .GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Diện tích kế hoạch", 0));

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
            .MaximumLength(300).When(x => !string.IsNullOrEmpty(x.TargetMarket))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Thị trường mục tiêu", 300));

        RuleFor(x => x.TargetSellingPrice)
            .GreaterThanOrEqualTo(0).When(x => x.TargetSellingPrice.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Giá bán mục tiêu", 0));

        RuleFor(x => x.Notes)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
    }
}