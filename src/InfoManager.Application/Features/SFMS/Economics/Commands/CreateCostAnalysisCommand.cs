namespace InfoManager.Application.Features.SFMS.Economics.Commands;

/// <summary>
/// Command tạo mới phân tích chi phí.
/// </summary>
public record CreateCostAnalysisCommand : IRequest<Result<string>>
{
    /// <summary>
    /// ID nông trại. Bắt buộc.
    /// </summary>
    public required string FarmId { get; init; }

    /// <summary>
    /// ID lần trồng liên quan. Tùy chọn.
    /// </summary>
    public string? CropPlantingId { get; init; }

    /// <summary>
    /// Ngày phân tích. Bắt buộc.
    /// </summary>
    public required DateTimeOffset AnalysisDate { get; init; }

    /// <summary>
    /// Thời gian phân tích từ ngày. Bắt buộc.
    /// </summary>
    public required DateTimeOffset FromDate { get; init; }

    /// <summary>
    /// Thời gian phân tích đến ngày. Bắt buộc. Phải ≥ FromDate.
    /// </summary>
    public required DateTimeOffset ToDate { get; init; }

    /// <summary>
    /// Tổng chi phí trong kỳ. Bắt buộc. ≥ 0.
    /// </summary>
    public required decimal TotalCost { get; init; }

    /// <summary>
    /// Phân bổ chi phí theo danh mục (JSON). Tùy chọn. MaxLength: 2000.
    /// </summary>
    public string? CostBreakdown { get; init; }

    /// <summary>
    /// Chi phí trên mỗi hecta. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? CostPerHectare { get; init; }

    /// <summary>
    /// Chi phí trên mỗi đơn vị sản phẩm. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? CostPerUnit { get; init; }

    /// <summary>
    /// Tổng doanh thu trong kỳ. Bắt buộc. ≥ 0.
    /// </summary>
    public required decimal TotalRevenue { get; init; }

    /// <summary>
    /// Lợi nhuận gộp. Bắt buộc.
    /// </summary>
    public required decimal GrossProfit { get; init; }

    /// <summary>
    /// Lợi nhuận ròng. Bắt buộc.
    /// </summary>
    public required decimal NetProfit { get; init; }

    /// <summary>
    /// Tỷ suất lợi nhuận (%). Bắt buộc.
    /// </summary>
    public required decimal ProfitMargin { get; init; }

    /// <summary>
    /// Tỷ suất hoàn vốn đầu tư - ROI (%). Bắt buộc.
    /// </summary>
    public required decimal ROI { get; init; }

    /// <summary>
    /// Phân tích điểm hòa vốn. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? BreakEvenAnalysis { get; init; }

    /// <summary>
    /// Điểm đánh giá hiệu quả chi phí. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? EfficiencyRating { get; init; }

    /// <summary>
    /// Khuyến nghị từ phân tích. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? Recommendations { get; init; }

    /// <summary>
    /// Người thực hiện phân tích. Tùy chọn. MaxLength: 200.
    /// </summary>
    public string? PreparedBy { get; init; }
}

public class CreateCostAnalysisCommandHandler : BaseCreateCommandHandler<CreateCostAnalysisCommand, CostAnalysis>
{
    public CreateCostAnalysisCommandHandler(IApplicationDbContext context,
                                            IValidator<CreateCostAnalysisCommand> validator,
                                            ILogger<CreateCostAnalysisCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(CostAnalysis entity, CancellationToken ct)
    {
        await Context.CostAnalyses.AddAsync(entity, ct);
    }

    protected override async Task<CostAnalysis> CreateEntity(CreateCostAnalysisCommand request)
    {
        return new CostAnalysis
        {
            FarmId = request.FarmId,
            CropPlantingId = request.CropPlantingId,
            AnalysisDate = request.AnalysisDate,
            FromDate = request.FromDate,
            ToDate = request.ToDate,
            TotalCost = request.TotalCost,
            CostBreakdown = request.CostBreakdown,
            CostPerHectare = request.CostPerHectare,
            CostPerUnit = request.CostPerUnit,
            TotalRevenue = request.TotalRevenue,
            GrossProfit = request.GrossProfit,
            NetProfit = request.NetProfit,
            ProfitMargin = request.ProfitMargin,
            ROI = request.ROI,
            BreakEvenAnalysis = request.BreakEvenAnalysis,
            EfficiencyRating = request.EfficiencyRating,
            Recommendations = request.Recommendations,
            PreparedBy = request.PreparedBy
        };
    }
}

public class CreateCostAnalysisCommandValidator : AbstractValidator<CreateCostAnalysisCommand>
{
    public CreateCostAnalysisCommandValidator()
    {
        RuleFor(x => x.FarmId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));

        RuleFor(x => x.ToDate)
            .GreaterThanOrEqualTo(x => x.FromDate)
            .WithMessage(ErrorHelpers.GetErrorCustom("Đến ngày phải lớn hơn hoặc bằng Từ ngày"));

        RuleFor(x => x.TotalCost)
            .GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Tổng chi phí", 0));

        RuleFor(x => x.CostBreakdown)
            .MaximumLength(2000).When(x => !string.IsNullOrEmpty(x.CostBreakdown))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phân bổ chi phí", 2000));

        RuleFor(x => x.CostPerHectare)
            .GreaterThanOrEqualTo(0).When(x => x.CostPerHectare.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí trên mỗi hecta", 0));

        RuleFor(x => x.CostPerUnit)
            .GreaterThanOrEqualTo(0).When(x => x.CostPerUnit.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí trên mỗi đơn vị", 0));

        RuleFor(x => x.TotalRevenue)
            .GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Tổng doanh thu", 0));

        RuleFor(x => x.EfficiencyRating)
            .GreaterThanOrEqualTo(0).When(x => x.EfficiencyRating.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Điểm hiệu quả", 0));

        RuleFor(x => x.BreakEvenAnalysis)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.BreakEvenAnalysis))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phân tích điểm hòa vốn", 500));

        RuleFor(x => x.Recommendations)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Recommendations))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Khuyến nghị", 1000));

        RuleFor(x => x.PreparedBy)
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.PreparedBy))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người thực hiện", 200));
    }
}