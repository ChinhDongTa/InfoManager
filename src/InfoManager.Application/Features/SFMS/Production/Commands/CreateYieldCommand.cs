namespace InfoManager.Application.Features.SFMS.Production.Commands;

public record CreateYieldCommand : IRequest<Result<string>>
{
    public required string CropPlantingId { get; init; }
    public string? HarvestId { get; init; }
    public required decimal ActualYield { get; init; }
    public decimal? ExpectedYield { get; init; }
    public required string Unit { get; init; }
    public decimal? YieldPerHectare { get; init; }
    public decimal? QualityRating { get; init; }
    public decimal? WastePercentage { get; init; }
    public decimal? YieldVariance { get; init; }
    public int? GrowthDays { get; init; }
    public decimal? ProductionCost { get; init; }
    public decimal? Revenue { get; init; }
    public decimal? Profit { get; init; }
    public decimal? ROI { get; init; }
    public string? AffectingFactors { get; init; }
    public string? Analysis { get; init; }
    public string? Recommendations { get; init; }
}

public class CreateYieldCommandHandler : BaseCreateCommandHandler<CreateYieldCommand, Yield>
{
    public CreateYieldCommandHandler(IApplicationDbContext context,
                                     IValidator<CreateYieldCommand> validator,
                                     ILogger<CreateYieldCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(Yield entity, CancellationToken ct)
        => await Context.Yields.AddAsync(entity, ct);

    protected override Task<Yield> CreateEntity(CreateYieldCommand request)
    {
        var profit = request.Profit ?? (request.Revenue.HasValue && request.ProductionCost.HasValue
            ? request.Revenue.Value - request.ProductionCost.Value
            : null);
        var variance = request.YieldVariance
            ?? (request.ExpectedYield is > 0
                ? (request.ActualYield - request.ExpectedYield.Value) / request.ExpectedYield.Value * 100
                : null);
        var roi = request.ROI
            ?? (profit.HasValue && request.ProductionCost is > 0
                ? profit.Value / request.ProductionCost.Value * 100
                : null);

        return Task.FromResult(new Yield
        {
            CropPlantingId = request.CropPlantingId,
            HarvestId = request.HarvestId,
            ActualYield = request.ActualYield,
            ExpectedYield = request.ExpectedYield,
            Unit = request.Unit,
            YieldPerHectare = request.YieldPerHectare ?? 0,
            QualityRating = request.QualityRating,
            WastePercentage = request.WastePercentage,
            YieldVariance = variance,
            GrowthDays = request.GrowthDays,
            ProductionCost = request.ProductionCost,
            Revenue = request.Revenue,
            Profit = profit,
            ROI = roi,
            AffectingFactors = request.AffectingFactors,
            Analysis = request.Analysis,
            Recommendations = request.Recommendations
        });
    }
}

public class CreateYieldCommandValidator : AbstractValidator<CreateYieldCommand>
{
    public CreateYieldCommandValidator()
    {
        RuleFor(x => x.CropPlantingId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID lần trồng"));
        RuleFor(x => x.ActualYield).GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Sản lượng thực tế", 0));
        RuleFor(x => x.ExpectedYield)
            .GreaterThanOrEqualTo(0).When(x => x.ExpectedYield.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Sản lượng kỳ vọng", 0));
        RuleFor(x => x.Unit)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 50));
        RuleFor(x => x.YieldPerHectare)
            .GreaterThanOrEqualTo(0).When(x => x.YieldPerHectare.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Năng suất / hecta", 0));
        RuleFor(x => x.QualityRating)
            .InclusiveBetween(0, 100).When(x => x.QualityRating.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Điểm chất lượng", 0, 100));
        RuleFor(x => x.WastePercentage)
            .InclusiveBetween(0, 100).When(x => x.WastePercentage.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Tỷ lệ hao hụt", 0, 100));
        RuleFor(x => x.GrowthDays)
            .GreaterThanOrEqualTo(0).When(x => x.GrowthDays.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số ngày sinh trưởng", 0));
        RuleFor(x => x.ProductionCost)
            .GreaterThanOrEqualTo(0).When(x => x.ProductionCost.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí sản xuất", 0));
        RuleFor(x => x.Revenue)
            .GreaterThanOrEqualTo(0).When(x => x.Revenue.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Doanh thu", 0));
        RuleFor(x => x.AffectingFactors)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.AffectingFactors))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Yếu tố ảnh hưởng", 1000));
        RuleFor(x => x.Analysis)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Analysis))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phân tích", 1000));
        RuleFor(x => x.Recommendations)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Recommendations))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Khuyến nghị", 1000));
    }
}