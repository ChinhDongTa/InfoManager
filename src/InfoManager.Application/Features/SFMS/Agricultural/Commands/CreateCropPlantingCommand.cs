namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record CreateCropPlantingCommand : IRequest<Result<string>>
{
    public required string FieldId { get; init; }
    public required string CropId { get; init; }
    public string? CropVarietyId { get; init; } = null;
    public string? CropScheduleId { get; init; } = null;
    public DateTimeOffset PlantingDate { get; init; } = default;
    public DateTimeOffset? ActualHarvestDate { get; init; } = null;
    public DateTimeOffset? ExpectedHarvestDate { get; init; } = null;
    public decimal PlantedArea { get; init; } = 0;
    public decimal? QuantityPlanted { get; init; } = null;
    public string? PlantedUnit { get; init; } = null;
    public PlantingStatus Status { get; init; } = PlantingStatus.Planned;
    public string? Notes { get; init; } = null;
}

public class CreateCropPlantingCommandHandler : BaseCreateCommandHandler<CreateCropPlantingCommand, CropPlanting>
{
    private readonly ICodeGeneratorService _codeGenerator;

    public CreateCropPlantingCommandHandler(IApplicationDbContext context,
                                            IValidator<CreateCropPlantingCommand> validator,
                                            ILogger<CreateCropPlantingCommandHandler> logger, ICodeGeneratorService codeGenerator) : base(context, validator, logger)
    {
        _codeGenerator = codeGenerator;
    }

    protected override async Task AddEntityAsync(CropPlanting entity, CancellationToken ct)
    {
        await Context.CropPlantings.AddAsync(entity, ct);
    }

    private async Task<string> GetPlantingCode(CreateCropPlantingCommand request, CancellationToken ct)
    {
        return await _codeGenerator.PlantingCodeGenerator(request.FieldId, request.CropId, request.PlantingDate, ct);
    }

    protected override async Task<CropPlanting> CreateEntity(CreateCropPlantingCommand request)
    {
        return new CropPlanting
        {
            PlantingCode = await GetPlantingCode(request, CancellationToken.None),
            FieldId = request.FieldId,
            CropId = request.CropId,
            CropVarietyId = request.CropVarietyId,
            CropScheduleId = request.CropScheduleId,
            PlantingDate = request.PlantingDate,
            ActualHarvestDate = request.ActualHarvestDate,
            ExpectedHarvestDate = request.ExpectedHarvestDate,
            PlantedArea = request.PlantedArea,
            QuantityPlanted = request.QuantityPlanted,
            PlantedUnit = request.PlantedUnit,
            Status = request.Status,
            Notes = request.Notes
        };
    }
}

public class CreateCropPlantingCommandValidator : AbstractValidator<CreateCropPlantingCommand>
{
    public CreateCropPlantingCommandValidator()
    {
        RuleFor(x => x.FieldId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã thửa ruộng"));
        RuleFor(x => x.CropId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã cây trồng"));
        RuleFor(x => x.PlantingDate)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Ngày gieo trồng"));
        RuleFor(x => x.PlantedArea)
            .GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Diện tích gieo trồng", 1));
    }
}