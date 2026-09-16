namespace InfoManager.Application.Features.SFMS.Production.Commands;

public record UpdateYieldCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? CropPlantingId { get; init; }
    public string? HarvestId { get; init; }
    public decimal? ActualYield { get; init; }
    public decimal? ExpectedYield { get; init; }
    public string? Unit { get; init; }
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

public class UpdateYieldCommandHandler : BaseUpdateCommandHandler<UpdateYieldCommand, Yield>
{
    public UpdateYieldCommandHandler(IApplicationDbContext context,
                                     IValidator<UpdateYieldCommand> validator,
                                     ILogger<UpdateYieldCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<Yield?> GetEntityAsync(UpdateYieldCommand request, CancellationToken ct)
        => await Context.Yields.FindAsync([request.Id], ct);

    protected override Task UpdateEntityProperties(Yield entity, UpdateYieldCommand request)
    {
        if (request.CropPlantingId.HasValueAndIsDifferentFrom(entity.CropPlantingId))
            entity.CropPlantingId = request.CropPlantingId!;
        if (request.HarvestId.IsDifferentFrom(entity.HarvestId))
            entity.HarvestId = request.HarvestId;
        if (request.ActualYield.HasValueAndIsDifferentFrom(entity.ActualYield))
            entity.ActualYield = request.ActualYield!.Value;
        if (request.ExpectedYield.IsDifferentFrom(entity.ExpectedYield))
            entity.ExpectedYield = request.ExpectedYield;
        if (request.Unit.HasValueAndIsDifferentFrom(entity.Unit))
            entity.Unit = request.Unit!;
        if (request.YieldPerHectare.HasValueAndIsDifferentFrom(entity.YieldPerHectare))
            entity.YieldPerHectare = request.YieldPerHectare!.Value;
        if (request.QualityRating.IsDifferentFrom(entity.QualityRating))
            entity.QualityRating = request.QualityRating;
        if (request.WastePercentage.IsDifferentFrom(entity.WastePercentage))
            entity.WastePercentage = request.WastePercentage;
        if (request.YieldVariance.IsDifferentFrom(entity.YieldVariance))
            entity.YieldVariance = request.YieldVariance;
        else if (!request.YieldVariance.HasValue && entity.ExpectedYield is > 0
                 && (request.ActualYield.HasValue || request.ExpectedYield.HasValue))
            entity.YieldVariance = (entity.ActualYield - entity.ExpectedYield.Value) / entity.ExpectedYield.Value * 100;
        if (request.GrowthDays.IsDifferentFrom(entity.GrowthDays))
            entity.GrowthDays = request.GrowthDays;
        if (request.ProductionCost.IsDifferentFrom(entity.ProductionCost))
            entity.ProductionCost = request.ProductionCost;
        if (request.Revenue.IsDifferentFrom(entity.Revenue))
            entity.Revenue = request.Revenue;
        if (request.Profit.IsDifferentFrom(entity.Profit))
            entity.Profit = request.Profit;
        else if (!request.Profit.HasValue && entity.Revenue.HasValue && entity.ProductionCost.HasValue
                 && (request.Revenue.HasValue || request.ProductionCost.HasValue))
            entity.Profit = entity.Revenue.Value - entity.ProductionCost.Value;
        if (request.ROI.IsDifferentFrom(entity.ROI))
            entity.ROI = request.ROI;
        else if (!request.ROI.HasValue && entity.Profit.HasValue && entity.ProductionCost is > 0)
            entity.ROI = entity.Profit.Value / entity.ProductionCost.Value * 100;
        if (request.AffectingFactors.IsDifferentFrom(entity.AffectingFactors))
            entity.AffectingFactors = request.AffectingFactors;
        if (request.Analysis.IsDifferentFrom(entity.Analysis))
            entity.Analysis = request.Analysis;
        if (request.Recommendations.IsDifferentFrom(entity.Recommendations))
            entity.Recommendations = request.Recommendations;
        return Task.CompletedTask;
    }
}

public class UpdateYieldCommandValidator : AbstractValidator<UpdateYieldCommand>
{
    public UpdateYieldCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID năng suất"));
        RuleFor(x => x.CropPlantingId)
            .NotEmpty().When(x => x.CropPlantingId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID lần trồng"));
        RuleFor(x => x.ActualYield)
            .GreaterThanOrEqualTo(0).When(x => x.ActualYield.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Sản lượng thực tế", 0));
        RuleFor(x => x.ExpectedYield)
            .GreaterThanOrEqualTo(0).When(x => x.ExpectedYield.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Sản lượng kỳ vọng", 0));
        RuleFor(x => x.Unit)
            .NotEmpty().When(x => x.Unit != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.Unit))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 50));
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
            .MaximumLength(1000).When(x => x.AffectingFactors != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Yếu tố ảnh hưởng", 1000));
        RuleFor(x => x.Analysis)
            .MaximumLength(1000).When(x => x.Analysis != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phân tích", 1000));
        RuleFor(x => x.Recommendations)
            .MaximumLength(1000).When(x => x.Recommendations != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Khuyến nghị", 1000));
    }
}