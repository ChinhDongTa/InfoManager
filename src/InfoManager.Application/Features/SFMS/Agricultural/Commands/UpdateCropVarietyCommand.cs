namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record UpdateCropVarietyCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? VarietyName { get; init; }
    public string? CropId { get; init; }
    public string? BreederName { get; init; }
    public int? DaysToMaturity { get; init; }
    public decimal? ExpectedYield { get; init; }
    public string? YieldUnit { get; init; }
    public decimal? SeedRate { get; init; }
    public string? DiseaseResistance { get; init; }
    public string? PestResistance { get; init; }
    public string? ClimateSuitability { get; init; }
    public int? YearOfRelease { get; init; }
    public bool? IsActive { get; init; }
}

public class UpdateCropVarietyCommandHandler : BaseUpdateCommandHandler<UpdateCropVarietyCommand, CropVariety>
{
    public UpdateCropVarietyCommandHandler(IApplicationDbContext context,
                                           IValidator<UpdateCropVarietyCommand> validator,
                                           ILogger<UpdateCropVarietyCommandHandler> logger)
        : base(context, validator, logger)
    {
    }

    protected override async Task<CropVariety?> GetEntityAsync(UpdateCropVarietyCommand request, CancellationToken ct)
    {
        return await Context.CropVarieties.FindAsync([request.Id], ct);
    }

    protected override async Task UpdateEntityProperties(CropVariety entity, UpdateCropVarietyCommand request)
    {
        if (request.VarietyName.HasValueAndIsDifferentFrom(entity.VarietyName))
            entity.VarietyName = request.VarietyName!;
        if (request.CropId.HasValueAndIsDifferentFrom(entity.CropId))
            entity.CropId = request.CropId!;
        if (request.BreederName.IsDifferentFrom(entity.BreederName))
            entity.BreederName = request.BreederName!;
        if (request.DaysToMaturity.IsDifferentFrom(entity.DaysToMaturity))
            entity.DaysToMaturity = request.DaysToMaturity;
        if (request.ExpectedYield.IsDifferentFrom(entity.ExpectedYield))
            entity.ExpectedYield = request.ExpectedYield;
        if (request.YieldUnit.IsDifferentFrom(entity.YieldUnit))
            entity.YieldUnit = request.YieldUnit!;
        if (request.SeedRate.IsDifferentFrom(entity.SeedRate))
            entity.SeedRate = request.SeedRate;
        if (request.DiseaseResistance.IsDifferentFrom(entity.DiseaseResistance))
            entity.DiseaseResistance = request.DiseaseResistance!;
        if (request.PestResistance.IsDifferentFrom(entity.PestResistance))
            entity.PestResistance = request.PestResistance!;
        if (request.ClimateSuitability.IsDifferentFrom(entity.ClimateSuitability))
            entity.ClimateSuitability = request.ClimateSuitability!;
        if (request.YearOfRelease.IsDifferentFrom(entity.YearOfRelease))
            entity.YearOfRelease = request.YearOfRelease;
        if (request.IsActive.HasValueAndIsDifferentFrom(entity.IsActive))
            entity.IsActive = request.IsActive!.Value;
    }
}

public class UpdateCropVarietyCommandValidator : AbstractValidator<UpdateCropVarietyCommand>
{
    public UpdateCropVarietyCommandValidator()
    {
        RuleFor(x => x.VarietyName)
            .MaximumLength(200).When(x => x.VarietyName != null).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên giống cây trồng", 200));
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