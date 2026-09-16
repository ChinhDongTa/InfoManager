namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record CreateCropCommand : IRequest<Result<string>>
{
    public required string CommonName { get; init; }
    public required string ScientificName { get; init; }
    public string? Description { get; init; } = null;
    public string? Family { get; init; } = null;
    public int? DaysToMaturity { get; init; } = null;
    public decimal? MinTemperature { get; init; } = null;
    public decimal? MaxTemperature { get; init; } = null;
    public decimal? MinHumidity { get; init; } = null;
    public decimal? MaxHumidity { get; init; } = null;
    public decimal? MinSoilPh { get; init; } = null;
    public decimal? MaxSoilPh { get; init; } = null;
    public decimal? WaterRequirement { get; init; } = null;
    public decimal? SunLightHours { get; init; } = null;
    public bool IsActive { get; init; } = true;
}

public class CreateCropCommandHandler : BaseCreateCommandHandler<CreateCropCommand, Crop>
{
    public CreateCropCommandHandler(IApplicationDbContext context, IValidator<CreateCropCommand> validator, ILogger<CreateCropCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(Crop entity, CancellationToken ct)
        => await Context.Crops.AddAsync(entity, ct);

    protected override async Task<Crop> CreateEntity(CreateCropCommand request) => new()
    {
        CommonName = request.CommonName,
        ScientificName = request.ScientificName,
        Description = request.Description,
        Family = request.Family,
        DaysToMaturity = request.DaysToMaturity,
        MinTemperature = request.MinTemperature,
        MaxTemperature = request.MaxTemperature,
        MinHumidity = request.MinHumidity,
        MaxHumidity = request.MaxHumidity,
        MinSoilPh = request.MinSoilPh,
        MaxSoilPh = request.MaxSoilPh,
        WaterRequirement = request.WaterRequirement,
        SunLightHours = request.SunLightHours,
        IsActive = request.IsActive
    };
}

public class CreateCropCommandValidator : AbstractValidator<CreateCropCommand>
{
    public CreateCropCommandValidator()
    {
        RuleFor(x => x.CommonName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên thông dụng"))
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên thông dụng", 100));
        RuleFor(x => x.ScientificName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên khoa học"))
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên khoa học", 100));
        RuleFor(x => x.Family)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.Family)).WithMessage(ErrorHelpers.GetErrorMaxLength("Họ thực vật", 100));
        RuleFor(x => x.DaysToMaturity)
            .GreaterThan(0).When(x => x.DaysToMaturity.HasValue).WithMessage(ErrorHelpers.GetErrorMinValue("Số ngày đến khi trưởng thành", 0));
        RuleFor(x => x.MinTemperature)
            .GreaterThan(-273.15m).When(x => x.MinTemperature.HasValue).WithMessage(ErrorHelpers.GetErrorMinValue("Nhiệt độ tối thiểu", -273.15m));
        RuleFor(x => x.MaxTemperature)
            .GreaterThan(-273.15m).When(x => x.MaxTemperature.HasValue).WithMessage(ErrorHelpers.GetErrorMinValue("Nhiệt độ tối đa", -273.15m));
        RuleFor(x => x.MinHumidity)
            .InclusiveBetween(0, 100).When(x => x.MinHumidity.HasValue).WithMessage(ErrorHelpers.GetErrorOutOfRange("Độ ẩm tối thiểu", 0, 100));
        RuleFor(x => x.MaxHumidity)
            .InclusiveBetween(0, 100).When(x => x.MaxHumidity.HasValue).WithMessage(ErrorHelpers.GetErrorOutOfRange("Độ ẩm tối đa", 0, 100));
        RuleFor(x => x.MinSoilPh)
            .InclusiveBetween(0, 14).When(x => x.MinSoilPh.HasValue).WithMessage(ErrorHelpers.GetErrorOutOfRange("Độ pH đất tối thiểu", 0, 14));
        RuleFor(x => x.MaxSoilPh)
            .InclusiveBetween(0, 14).When(x => x.MaxSoilPh.HasValue).WithMessage(ErrorHelpers.GetErrorOutOfRange("Độ pH đất tối đa", 0, 14));
    }
}