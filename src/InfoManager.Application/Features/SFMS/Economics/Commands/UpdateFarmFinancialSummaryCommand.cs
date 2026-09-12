namespace InfoManager.Application.Features.SFMS.Economics.Commands;

/// <summary>
/// Command cập nhật tổng hợp tài chính nông trại.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateFarmFinancialSummaryCommand : IRequest<Result>
{
    /// <summary>
    /// ID bản tổng hợp. Bắt buộc. Truyền từ client (route/header).
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// ID nông trại. Tùy chọn.
    /// </summary>
    public string? FarmId { get; init; }

    /// <summary>
    /// Năm tổng hợp. Tùy chọn.
    /// </summary>
    public int? Year { get; init; }

    /// <summary>
    /// Tháng tổng hợp (1-12). Tùy chọn.
    /// </summary>
    public int? Month { get; init; }

    /// <summary>
    /// Tổng chi phí trong kỳ. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? TotalExpenses { get; init; }

    /// <summary>
    /// Tổng doanh thu trong kỳ. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? TotalRevenue { get; init; }

    /// <summary>
    /// Lợi nhuận / lỗ. Tùy chọn.
    /// </summary>
    public decimal? Profit { get; init; }

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

public class UpdateFarmFinancialSummaryCommandHandler
    : BaseUpdateCommandHandler<UpdateFarmFinancialSummaryCommand, FarmFinancialSummary>
{
    public UpdateFarmFinancialSummaryCommandHandler(IApplicationDbContext context,
                                                    IValidator<UpdateFarmFinancialSummaryCommand> validator,
                                                    ILogger<UpdateFarmFinancialSummaryCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task<FarmFinancialSummary?> GetEntityAsync(
        UpdateFarmFinancialSummaryCommand request,
        CancellationToken cancellationToken)
        => await Context.FarmFinancialSummaries.FindAsync([request.Id], cancellationToken);

    protected override async Task UpdateEntityProperties(FarmFinancialSummary entity, UpdateFarmFinancialSummaryCommand request)
    {
        if (request.FarmId.HasValueAndIsDifferentFrom(entity.FarmId))
            entity.FarmId = request.FarmId!;

        if (request.Year.HasValueAndIsDifferentFrom(entity.Year))
            entity.Year = request.Year!.Value;

        if (request.Month.IsDifferentFrom(entity.Month))
            entity.Month = request.Month;

        if (request.TotalExpenses.HasValueAndIsDifferentFrom(entity.TotalExpenses))
            entity.TotalExpenses = request.TotalExpenses!.Value;

        if (request.TotalRevenue.HasValueAndIsDifferentFrom(entity.TotalRevenue))
            entity.TotalRevenue = request.TotalRevenue!.Value;

        if (request.Profit.HasValueAndIsDifferentFrom(entity.Profit))
            entity.Profit = request.Profit!.Value;

        if (request.CropCycleCount.IsDifferentFrom(entity.CropCycleCount))
            entity.CropCycleCount = request.CropCycleCount;

        if (request.TotalAreaCultivated.IsDifferentFrom(entity.TotalAreaCultivated))
            entity.TotalAreaCultivated = request.TotalAreaCultivated;

        if (request.AverageYieldPerHectare.IsDifferentFrom(entity.AverageYieldPerHectare))
            entity.AverageYieldPerHectare = request.AverageYieldPerHectare;

        if (request.AverageCostPerHectare.IsDifferentFrom(entity.AverageCostPerHectare))
            entity.AverageCostPerHectare = request.AverageCostPerHectare;

        if (request.AverageRevenuePerHectare.IsDifferentFrom(entity.AverageRevenuePerHectare))
            entity.AverageRevenuePerHectare = request.AverageRevenuePerHectare;

        if (request.HealthScore.IsDifferentFrom(entity.HealthScore))
            entity.HealthScore = request.HealthScore;

        if (request.KPIs.IsDifferentFrom(entity.KPIs))
            entity.KPIs = request.KPIs;

        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
    }
}

public class UpdateFarmFinancialSummaryCommandValidator : AbstractValidator<UpdateFarmFinancialSummaryCommand>
{
    public UpdateFarmFinancialSummaryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID tổng hợp tài chính"));

        RuleFor(x => x.FarmId)
            .NotEmpty().When(x => x.FarmId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));

        RuleFor(x => x.Year)
            .GreaterThan(0).When(x => x.Year.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Năm", 1));

        RuleFor(x => x.Month)
            .InclusiveBetween(1, 12).When(x => x.Month.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Tháng", 1, 12));

        RuleFor(x => x.TotalExpenses)
            .GreaterThanOrEqualTo(0).When(x => x.TotalExpenses.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Tổng chi phí", 0));

        RuleFor(x => x.TotalRevenue)
            .GreaterThanOrEqualTo(0).When(x => x.TotalRevenue.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Tổng doanh thu", 0));

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
            .MaximumLength(1000).When(x => x.KPIs != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("KPI", 1000));

        RuleFor(x => x.Notes)
            .MaximumLength(1000).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
    }
}