namespace InfoManager.Application.Features.SFMS.Economics.Commands;

/// <summary>
/// Command cập nhật phân tích chi phí.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateCostAnalysisCommand : IRequest<Result>
{
    /// <summary>
    /// ID phân tích. Bắt buộc. Truyền từ client (route/header).
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// ID nông trại. Tùy chọn.
    /// </summary>
    public string? FarmId { get; init; }

    /// <summary>
    /// ID lần trồng liên quan. Tùy chọn.
    /// </summary>
    public string? CropPlantingId { get; init; }

    /// <summary>
    /// Ngày phân tích. Tùy chọn.
    /// </summary>
    public DateTimeOffset? AnalysisDate { get; init; }

    /// <summary>
    /// Thời gian phân tích từ ngày. Tùy chọn.
    /// </summary>
    public DateTimeOffset? FromDate { get; init; }

    /// <summary>
    /// Thời gian phân tích đến ngày. Tùy chọn.
    /// </summary>
    public DateTimeOffset? ToDate { get; init; }

    /// <summary>
    /// Tổng chi phí trong kỳ. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? TotalCost { get; init; }

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
    /// Tổng doanh thu trong kỳ. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? TotalRevenue { get; init; }

    /// <summary>
    /// Lợi nhuận gộp. Tùy chọn.
    /// </summary>
    public decimal? GrossProfit { get; init; }

    /// <summary>
    /// Lợi nhuận ròng. Tùy chọn.
    /// </summary>
    public decimal? NetProfit { get; init; }

    /// <summary>
    /// Tỷ suất lợi nhuận (%). Tùy chọn.
    /// </summary>
    public decimal? ProfitMargin { get; init; }

    /// <summary>
    /// Tỷ suất hoàn vốn đầu tư - ROI (%). Tùy chọn.
    /// </summary>
    public decimal? ROI { get; init; }

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

public class UpdateCostAnalysisCommandHandler : BaseUpdateCommandHandler<UpdateCostAnalysisCommand, CostAnalysis>
{
    public UpdateCostAnalysisCommandHandler(IApplicationDbContext context,
                                            IValidator<UpdateCostAnalysisCommand> validator,
                                            ILogger<UpdateCostAnalysisCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task<CostAnalysis?> GetEntityAsync(UpdateCostAnalysisCommand request, CancellationToken cancellationToken)
        => await Context.CostAnalyses.FindAsync([request.Id], cancellationToken);

    protected override async Task UpdateEntityProperties(CostAnalysis entity, UpdateCostAnalysisCommand request)
    {
        if (request.FarmId.HasValueAndIsDifferentFrom(entity.FarmId))
            entity.FarmId = request.FarmId!;

        if (request.CropPlantingId.IsDifferentFrom(entity.CropPlantingId))
            entity.CropPlantingId = request.CropPlantingId;

        if (request.AnalysisDate.HasValueAndIsDifferentFrom(entity.AnalysisDate))
            entity.AnalysisDate = request.AnalysisDate!.Value;

        if (request.FromDate.HasValueAndIsDifferentFrom(entity.FromDate))
            entity.FromDate = request.FromDate!.Value;

        if (request.ToDate.HasValueAndIsDifferentFrom(entity.ToDate))
            entity.ToDate = request.ToDate!.Value;

        if (request.TotalCost.HasValueAndIsDifferentFrom(entity.TotalCost))
            entity.TotalCost = request.TotalCost!.Value;

        if (request.CostBreakdown.IsDifferentFrom(entity.CostBreakdown))
            entity.CostBreakdown = request.CostBreakdown;

        if (request.CostPerHectare.IsDifferentFrom(entity.CostPerHectare))
            entity.CostPerHectare = request.CostPerHectare;

        if (request.CostPerUnit.IsDifferentFrom(entity.CostPerUnit))
            entity.CostPerUnit = request.CostPerUnit;

        if (request.TotalRevenue.HasValueAndIsDifferentFrom(entity.TotalRevenue))
            entity.TotalRevenue = request.TotalRevenue!.Value;

        if (request.GrossProfit.HasValueAndIsDifferentFrom(entity.GrossProfit))
            entity.GrossProfit = request.GrossProfit!.Value;

        if (request.NetProfit.HasValueAndIsDifferentFrom(entity.NetProfit))
            entity.NetProfit = request.NetProfit!.Value;

        if (request.ProfitMargin.HasValueAndIsDifferentFrom(entity.ProfitMargin))
            entity.ProfitMargin = request.ProfitMargin!.Value;

        if (request.ROI.HasValueAndIsDifferentFrom(entity.ROI))
            entity.ROI = request.ROI!.Value;

        if (request.BreakEvenAnalysis.IsDifferentFrom(entity.BreakEvenAnalysis))
            entity.BreakEvenAnalysis = request.BreakEvenAnalysis;

        if (request.EfficiencyRating.IsDifferentFrom(entity.EfficiencyRating))
            entity.EfficiencyRating = request.EfficiencyRating;

        if (request.Recommendations.IsDifferentFrom(entity.Recommendations))
            entity.Recommendations = request.Recommendations;

        if (request.PreparedBy.IsDifferentFrom(entity.PreparedBy))
            entity.PreparedBy = request.PreparedBy;
    }
}

public class UpdateCostAnalysisCommandValidator : AbstractValidator<UpdateCostAnalysisCommand>
{
    public UpdateCostAnalysisCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID phân tích"));

        RuleFor(x => x.FarmId)
            .NotEmpty().When(x => x.FarmId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));

        RuleFor(x => x.ToDate)
            .GreaterThanOrEqualTo(x => x.FromDate)
            .When(x => x.FromDate.HasValue && x.ToDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Đến ngày phải lớn hơn hoặc bằng Từ ngày"));

        RuleFor(x => x.TotalCost)
            .GreaterThanOrEqualTo(0).When(x => x.TotalCost.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Tổng chi phí", 0));

        RuleFor(x => x.CostBreakdown)
            .MaximumLength(2000).When(x => x.CostBreakdown != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phân bổ chi phí", 2000));

        RuleFor(x => x.CostPerHectare)
            .GreaterThanOrEqualTo(0).When(x => x.CostPerHectare.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí trên mỗi hecta", 0));

        RuleFor(x => x.CostPerUnit)
            .GreaterThanOrEqualTo(0).When(x => x.CostPerUnit.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí trên mỗi đơn vị", 0));

        RuleFor(x => x.TotalRevenue)
            .GreaterThanOrEqualTo(0).When(x => x.TotalRevenue.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Tổng doanh thu", 0));

        RuleFor(x => x.EfficiencyRating)
            .GreaterThanOrEqualTo(0).When(x => x.EfficiencyRating.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Điểm hiệu quả", 0));

        RuleFor(x => x.BreakEvenAnalysis)
            .MaximumLength(500).When(x => x.BreakEvenAnalysis != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phân tích điểm hòa vốn", 500));

        RuleFor(x => x.Recommendations)
            .MaximumLength(1000).When(x => x.Recommendations != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Khuyến nghị", 1000));

        RuleFor(x => x.PreparedBy)
            .MaximumLength(200).When(x => x.PreparedBy != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người thực hiện", 200));
    }
}