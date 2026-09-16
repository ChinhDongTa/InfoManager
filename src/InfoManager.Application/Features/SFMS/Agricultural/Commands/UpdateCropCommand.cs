namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record UpdateCropCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? CommonName { get; init; } = null;
    public string? ScientificName { get; init; } = null;
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
    public bool? IsActive { get; init; }
}

public class UpdateCropCommandHandler : BaseUpdateCommandHandler<UpdateCropCommand, Crop>
{
    public UpdateCropCommandHandler(IApplicationDbContext context, IValidator<UpdateCropCommand> validator, ILogger<UpdateCropCommandHandler> logger) :
        base(context, validator, logger)
    { }

    protected override async Task<Crop?> GetEntityAsync(UpdateCropCommand request, CancellationToken ct)
    {
        return await Context.Crops.FindAsync([request.Id], ct);
    }

    protected override async Task UpdateEntityProperties(Crop entity, UpdateCropCommand request)
    {
        if (request.CommonName.HasValueAndIsDifferentFrom(entity.CommonName))
            entity.CommonName = request.CommonName!;
        if (request.ScientificName.HasValueAndIsDifferentFrom(entity.ScientificName))
            entity.ScientificName = request.ScientificName!;
        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description!;
        if (request.Family.IsDifferentFrom(entity.Family))
            entity.Family = request.Family!;
        if (request.DaysToMaturity.IsDifferentFrom(entity.DaysToMaturity))
            entity.DaysToMaturity = request.DaysToMaturity;
        if (request.MinTemperature.IsDifferentFrom(entity.MinTemperature))
            entity.MinTemperature = request.MinTemperature;
        if (request.MaxTemperature.IsDifferentFrom(entity.MaxTemperature))
            entity.MaxTemperature = request.MaxTemperature;
        if (request.MinHumidity.IsDifferentFrom(entity.MinHumidity))
            entity.MinHumidity = request.MinHumidity;
        if (request.MaxHumidity.IsDifferentFrom(entity.MaxHumidity))
            entity.MaxHumidity = request.MaxHumidity;
        if (request.MinSoilPh.IsDifferentFrom(entity.MinSoilPh))
            entity.MinSoilPh = request.MinSoilPh;
        if (request.MaxSoilPh.IsDifferentFrom(entity.MaxSoilPh))
            entity.MaxSoilPh = request.MaxSoilPh;
        if (request.WaterRequirement.IsDifferentFrom(entity.WaterRequirement))
            entity.WaterRequirement = request.WaterRequirement;
        if (request.SunLightHours.IsDifferentFrom(entity.SunLightHours))
            entity.SunLightHours = request.SunLightHours;
        if (request.IsActive.HasValueAndIsDifferentFrom(entity.IsActive))
            entity.IsActive = request.IsActive!.Value;
    }
}

public class UpdateCropCommandValidator : AbstractValidator<UpdateCropCommand>
{
    public UpdateCropCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Id"));
        RuleFor(x => x.CommonName)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.CommonName)).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên thông dụng", 100));
        RuleFor(x => x.ScientificName)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.ScientificName)).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên khoa học", 100));
        RuleFor(x => x.Family)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.Family)).WithMessage(ErrorHelpers.GetErrorMaxLength("Họ thực vật", 100));
    }
}