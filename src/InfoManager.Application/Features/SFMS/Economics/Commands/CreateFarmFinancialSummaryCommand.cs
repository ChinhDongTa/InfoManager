namespace InfoManager.Application.Features.SFMS.Economics.Commands;

/// <summary>
/// Command tạo mới tổng hợp tài chính nông trại.
/// </summary>
public record CreateFarmFinancialSummaryCommand : IRequest<Result<string>>
{
    /// <summary>
    /// ID nông trại. Bắt buộc.
    /// </summary>
    public required string FarmId { get; init; }

    /// <summary>
    /// Năm tổng hợp. Bắt buộc.
    /// </summary>
    public required int Year { get; init; }

    /// <summary>
    /// Tháng tổng hợp (1-12). Tùy chọn; null = tổng hợp cả năm.
    /// </summary>
    public int? Month { get; init; }

    /// <summary>
    /// Tổng chi phí trong kỳ. Bắt buộc. ≥ 0.
    /// </summary>
    public required decimal TotalExpenses { get; init; }

    /// <summary>
    /// Tổng doanh thu trong kỳ. Bắt buộc. ≥ 0.
    /// </summary>
    public required decimal TotalRevenue { get; init; }

    /// <summary>
    /// Lợi nhuận / lỗ. Bắt buộc.
    /// </summary>
    public required decimal Profit { get; init; }

    /// <summary>
    /// Số chu kỳ trồng. Tùy chọn. ≥ 0.
    /// </summary>
    public int? CropCycleCount { get; init; }

    /// <summary>
    /// Tổng diện tích canh tác (hecta). Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? TotalAreaCultivated { get; init; }

    /// <summary>
    /// Năng suất trung bình / hecta. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? AverageYieldPerHectare { get; init; }

    /// <summary>
    /// Chi phí trung bình / hecta. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? AverageCostPerHectare { get; init; }

    /// <summary>
    /// Doanh thu trung bình / hecta. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? AverageRevenuePerHectare { get; init; }

    /// <summary>
    /// Điểm sức khỏe tài chính. Tùy chọn. Range: 0-100.
    /// </summary>
    public decimal? HealthScore { get; init; }

    /// <summary>
    /// Các chỉ số KPI. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? KPIs { get; init; }

    /// <summary>
    /// Ghi chú. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? Notes { get; init; }
}

public class CreateFarmFinancialSummaryCommandHandler
    : BaseCreateCommandHandler<CreateFarmFinancialSummaryCommand, FarmFinancialSummary>
{
    public CreateFarmFinancialSummaryCommandHandler(IApplicationDbContext context,
                                                    IValidator<CreateFarmFinancialSummaryCommand> validator,
                                                    ILogger<CreateFarmFinancialSummaryCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(FarmFinancialSummary entity, CancellationToken cancellationToken)
    {
        await Context.FarmFinancialSummaries.AddAsync(entity, cancellationToken);
    }

    protected override async Task<FarmFinancialSummary> CreateEntity(CreateFarmFinancialSummaryCommand request)
    {
        return new FarmFinancialSummary
        {
            FarmId = request.FarmId,
            Year = request.Year,
            Month = request.Month,
            TotalExpenses = request.TotalExpenses,
            TotalRevenue = request.TotalRevenue,
            Profit = request.Profit,
            CropCycleCount = request.CropCycleCount,
            TotalAreaCultivated = request.TotalAreaCultivated,
            AverageYieldPerHectare = request.AverageYieldPerHectare,
            AverageCostPerHectare = request.AverageCostPerHectare,
            AverageRevenuePerHectare = request.AverageRevenuePerHectare,
            HealthScore = request.HealthScore,
            KPIs = request.KPIs,
            Notes = request.Notes
        };
    }
}

public class CreateFarmFinancialSummaryCommandValidator : AbstractValidator<CreateFarmFinancialSummaryCommand>
{
    public CreateFarmFinancialSummaryCommandValidator()
    {
        RuleFor(x => x.FarmId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));

        RuleFor(x => x.Year)
            .GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Năm", 1));

        RuleFor(x => x.Month)
            .InclusiveBetween(1, 12).When(x => x.Month.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Tháng", 1, 12));

        RuleFor(x => x.TotalExpenses)
            .GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Tổng chi phí", 0));

        RuleFor(x => x.TotalRevenue)
            .GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Tổng doanh thu", 0));

        RuleFor(x => x.CropCycleCount)
            .GreaterThanOrEqualTo(0).When(x => x.CropCycleCount.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số chu kỳ trồng", 0));

        RuleFor(x => x.TotalAreaCultivated)
            .GreaterThanOrEqualTo(0).When(x => x.TotalAreaCultivated.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Tổng diện tích canh tác", 0));

        RuleFor(x => x.AverageYieldPerHectare)
            .GreaterThanOrEqualTo(0).When(x => x.AverageYieldPerHectare.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Năng suất trung bình / hecta", 0));

        RuleFor(x => x.AverageCostPerHectare)
            .GreaterThanOrEqualTo(0).When(x => x.AverageCostPerHectare.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí trung bình / hecta", 0));

        RuleFor(x => x.AverageRevenuePerHectare)
            .GreaterThanOrEqualTo(0).When(x => x.AverageRevenuePerHectare.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Doanh thu trung bình / hecta", 0));

        RuleFor(x => x.HealthScore)
            .InclusiveBetween(0, 100).When(x => x.HealthScore.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Điểm sức khỏe tài chính", 0, 100));

        RuleFor(x => x.KPIs)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.KPIs))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("KPI", 1000));

        RuleFor(x => x.Notes)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
    }
}