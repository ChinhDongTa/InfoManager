namespace InfoManager.Application.Features.SFMS.Production.Commands;

public record CreateHarvestCommand : IRequest<Result<string>>
{
    public required string CropPlantingId { get; init; }
    public required DateTimeOffset HarvestDate { get; init; }
    public string? HarvestMethod { get; init; }
    public required decimal HarvestedArea { get; init; }
    public required decimal TotalQuantity { get; init; }
    public required string QuantityUnit { get; init; }
    public decimal? YieldPerHectare { get; init; }
    public string? QualityGrade { get; init; }
    public string? HarvesterName { get; init; }
    public string? WeatherCondition { get; init; }
    public decimal? LossPercentage { get; init; }
    public string? Notes { get; init; }
    public string? PhotoUrl { get; init; }
}

public class CreateHarvestCommandHandler : BaseCreateCommandHandler<CreateHarvestCommand, Harvest>
{
    public CreateHarvestCommandHandler(IApplicationDbContext context,
                                       IValidator<CreateHarvestCommand> validator,
                                       ILogger<CreateHarvestCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(Harvest entity, CancellationToken ct)
        => await Context.Harvests.AddAsync(entity, ct);

    protected override Task<Harvest> CreateEntity(CreateHarvestCommand request)
        => Task.FromResult(new Harvest
        {
            CropPlantingId = request.CropPlantingId,
            HarvestDate = request.HarvestDate,
            HarvestMethod = request.HarvestMethod,
            HarvestedArea = request.HarvestedArea,
            TotalQuantity = request.TotalQuantity,
            QuantityUnit = request.QuantityUnit,
            YieldPerHectare = request.YieldPerHectare
                ?? (request.HarvestedArea > 0 ? request.TotalQuantity / request.HarvestedArea : null),
            QualityGrade = request.QualityGrade,
            HarvesterName = request.HarvesterName,
            WeatherCondition = request.WeatherCondition,
            LossPercentage = request.LossPercentage,
            Notes = request.Notes,
            PhotoUrl = request.PhotoUrl
        });
}

public class CreateHarvestCommandValidator : AbstractValidator<CreateHarvestCommand>
{
    public CreateHarvestCommandValidator()
    {
        RuleFor(x => x.CropPlantingId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID lần trồng"));
        RuleFor(x => x.HarvestedArea).GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Diện tích đã thu", 0));
        RuleFor(x => x.TotalQuantity).GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Tổng sản lượng", 0));
        RuleFor(x => x.QuantityUnit)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị sản lượng"))
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị sản lượng", 50));
        RuleFor(x => x.HarvestMethod)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.HarvestMethod))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phương pháp thu hoạch", 50));
        RuleFor(x => x.YieldPerHectare)
            .GreaterThanOrEqualTo(0).When(x => x.YieldPerHectare.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Năng suất / hecta", 0));
        RuleFor(x => x.QualityGrade)
            .MaximumLength(10).When(x => !string.IsNullOrEmpty(x.QualityGrade))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phân loại chất lượng", 10));
        RuleFor(x => x.HarvesterName)
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.HarvesterName))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người thu hoạch", 200));
        RuleFor(x => x.WeatherCondition)
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.WeatherCondition))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Điều kiện thời tiết", 200));
        RuleFor(x => x.LossPercentage)
            .InclusiveBetween(0, 100).When(x => x.LossPercentage.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Tỷ lệ thất thoát", 0, 100));
        RuleFor(x => x.Notes)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
        RuleFor(x => x.PhotoUrl)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.PhotoUrl))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đường dẫn ảnh", 500));
    }
}