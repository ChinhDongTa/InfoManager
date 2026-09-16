namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record CreateCropVarietyCommand : IRequest<Result<string>>
{
    public required string VarietyName { get; init; }
    public required string CropId { get; init; }
    public string? BreederName { get; init; }
    public int? DaysToMaturity { get; init; }
    public decimal? ExpectedYield { get; init; }
    public string? YieldUnit { get; init; }
    public decimal? SeedRate { get; init; }
    public string? DiseaseResistance { get; init; }
    public string? PestResistance { get; init; }
    public string? ClimateSuitability { get; init; }
    public int? YearOfRelease { get; init; }
    public bool IsActive { get; init; }
}

public class CreateCropVarietyCommandHandler : BaseCreateCommandHandler<CreateCropVarietyCommand, CropVariety>
{
    public CreateCropVarietyCommandHandler(IApplicationDbContext context,
                                           IValidator<CreateCropVarietyCommand> validator,
                                           ILogger<CreateCropVarietyCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task AddEntityAsync(CropVariety entity, CancellationToken cancellationToken)
    {
        await Context.CropVarieties.AddAsync(entity, cancellationToken);
    }

    protected override async Task<CropVariety> CreateEntity(CreateCropVarietyCommand request)
    {
        return new CropVariety
        {
            VarietyName = request.VarietyName,
            CropId = request.CropId,
            BreederName = request.BreederName,
            DaysToMaturity = request.DaysToMaturity,
            ExpectedYield = request.ExpectedYield,
            YieldUnit = request.YieldUnit,
            SeedRate = request.SeedRate,
            DiseaseResistance = request.DiseaseResistance,
            PestResistance = request.PestResistance,
            ClimateSuitability = request.ClimateSuitability,
            YearOfRelease = request.YearOfRelease,
            IsActive = request.IsActive
        };
    }
}

public class CreateCropVarietyCommandValidator : AbstractValidator<CreateCropVarietyCommand>
{
    public CreateCropVarietyCommandValidator()
    {
        RuleFor(x => x.VarietyName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên giống cây trồng"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên giống cây trồng", 200));
        RuleFor(x => x.CropId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã cây trồng"));
        RuleFor(x => x.BreederName)
            .MaximumLength(200).When(x => x.BreederName != null).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên nhà lai tạo", 200));
        RuleFor(x => x.YieldUnit)
            .MaximumLength(50).When(x => x.YieldUnit != null).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị năng suất", 50));
        RuleFor(x => x.DiseaseResistance)
            .MaximumLength(500).When(x => x.DiseaseResistance != null).WithMessage(ErrorHelpers.GetErrorMaxLength("Khả năng kháng bệnh", 500));
        RuleFor(x => x.PestResistance)
            .MaximumLength(500).When(x => x.PestResistance != null).WithMessage(ErrorHelpers.GetErrorMaxLength("Khả năng kháng sâu bệnh", 500));
        RuleFor(x => x.ClimateSuitability)
            .MaximumLength(200).When(x => x.ClimateSuitability != null).WithMessage(ErrorHelpers.GetErrorMaxLength("Khả năng thích nghi khí hậu", 200));
    }
}