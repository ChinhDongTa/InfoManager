public record UpdateHarvestCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? CropPlantingId { get; init; }
    public DateTimeOffset? HarvestDate { get; init; }
    public string? HarvestMethod { get; init; }
    public decimal? HarvestedArea { get; init; }
    public decimal? TotalQuantity { get; init; }
    public string? QuantityUnit { get; init; }
    public decimal? YieldPerHectare { get; init; }
    public string? QualityGrade { get; init; }
    public string? HarvesterName { get; init; }
    public string? WeatherCondition { get; init; }
    public decimal? LossPercentage { get; init; }
    public string? Notes { get; init; }
    public string? PhotoUrl { get; init; }
}

public class UpdateHarvestCommandHandler : BaseUpdateCommandHandler<UpdateHarvestCommand, Harvest>
{
    public UpdateHarvestCommandHandler(IApplicationDbContext context,
                                       IValidator<UpdateHarvestCommand> validator,
                                       ILogger<UpdateHarvestCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<Harvest?> GetEntityAsync(UpdateHarvestCommand request, CancellationToken ct)
        => await Context.Harvests.FindAsync([request.Id], ct);

    protected override Task UpdateEntityProperties(Harvest entity, UpdateHarvestCommand request)
    {
        if (request.CropPlantingId.HasValueAndIsDifferentFrom(entity.CropPlantingId))
            entity.CropPlantingId = request.CropPlantingId!;
        if (request.HarvestDate.HasValueAndIsDifferentFrom(entity.HarvestDate))
            entity.HarvestDate = request.HarvestDate!.Value;
        if (request.HarvestMethod.IsDifferentFrom(entity.HarvestMethod))
            entity.HarvestMethod = request.HarvestMethod;
        if (request.HarvestedArea.HasValueAndIsDifferentFrom(entity.HarvestedArea))
            entity.HarvestedArea = request.HarvestedArea!.Value;
        if (request.TotalQuantity.HasValueAndIsDifferentFrom(entity.TotalQuantity))
            entity.TotalQuantity = request.TotalQuantity!.Value;
        if (request.QuantityUnit.HasValueAndIsDifferentFrom(entity.QuantityUnit))
            entity.QuantityUnit = request.QuantityUnit!;
        if (request.YieldPerHectare.IsDifferentFrom(entity.YieldPerHectare))
            entity.YieldPerHectare = request.YieldPerHectare;
        else if (!request.YieldPerHectare.HasValue && entity.HarvestedArea > 0
                 && (request.HarvestedArea.HasValue || request.TotalQuantity.HasValue))
            entity.YieldPerHectare = entity.TotalQuantity / entity.HarvestedArea;
        if (request.QualityGrade.IsDifferentFrom(entity.QualityGrade))
            entity.QualityGrade = request.QualityGrade;
        if (request.HarvesterName.IsDifferentFrom(entity.HarvesterName))
            entity.HarvesterName = request.HarvesterName;
        if (request.WeatherCondition.IsDifferentFrom(entity.WeatherCondition))
            entity.WeatherCondition = request.WeatherCondition;
        if (request.LossPercentage.IsDifferentFrom(entity.LossPercentage))
            entity.LossPercentage = request.LossPercentage;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
        if (request.PhotoUrl.IsDifferentFrom(entity.PhotoUrl))
            entity.PhotoUrl = request.PhotoUrl;
        return Task.CompletedTask;
    }
}

public class UpdateHarvestCommandValidator : AbstractValidator<UpdateHarvestCommand>
{
    public UpdateHarvestCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID thu hoạch"));
        RuleFor(x => x.CropPlantingId)
            .NotEmpty().When(x => x.CropPlantingId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID lần trồng"));
        RuleFor(x => x.HarvestedArea)
            .GreaterThan(0).When(x => x.HarvestedArea.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Diện tích đã thu", 0));
        RuleFor(x => x.TotalQuantity)
            .GreaterThan(0).When(x => x.TotalQuantity.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Tổng sản lượng", 0));
        RuleFor(x => x.QuantityUnit)
            .NotEmpty().When(x => x.QuantityUnit != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị sản lượng"))
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.QuantityUnit))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị sản lượng", 50));
        RuleFor(x => x.HarvestMethod)
            .MaximumLength(50).When(x => x.HarvestMethod != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phương pháp thu hoạch", 50));
        RuleFor(x => x.YieldPerHectare)
            .GreaterThanOrEqualTo(0).When(x => x.YieldPerHectare.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Năng suất / hecta", 0));
        RuleFor(x => x.QualityGrade)
            .MaximumLength(10).When(x => x.QualityGrade != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phân loại chất lượng", 10));
        RuleFor(x => x.HarvesterName)
            .MaximumLength(200).When(x => x.HarvesterName != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người thu hoạch", 200));
        RuleFor(x => x.WeatherCondition)
            .MaximumLength(200).When(x => x.WeatherCondition != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Điều kiện thời tiết", 200));
        RuleFor(x => x.LossPercentage)
            .InclusiveBetween(0, 100).When(x => x.LossPercentage.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Tỷ lệ thất thoát", 0, 100));
        RuleFor(x => x.Notes)
            .MaximumLength(1000).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
        RuleFor(x => x.PhotoUrl)
            .MaximumLength(500).When(x => x.PhotoUrl != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đường dẫn ảnh", 500));
    }
}