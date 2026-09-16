namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record UpdateCropPlantingCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? PlantingCode { get; init; }
    public string? FieldId { get; init; }
    public string? CropId { get; init; }
    public string? CropVarietyId { get; init; }
    public string? CropScheduleId { get; init; }
    public DateTimeOffset? PlantingDate { get; init; }
    public DateTimeOffset? ActualHarvestDate { get; init; }
    public DateTimeOffset? ExpectedHarvestDate { get; init; }
    public decimal? PlantedArea { get; init; }
    public decimal? QuantityPlanted { get; init; }
    public string? PlantedUnit { get; init; }
    public PlantingStatus? Status { get; init; }
    public string? Notes { get; init; }
}

public class UpdateCropPlantingCommandHandler : BaseUpdateCommandHandler<UpdateCropPlantingCommand, CropPlanting>
{
    public UpdateCropPlantingCommandHandler(IApplicationDbContext context,
                                            IValidator<UpdateCropPlantingCommand> validator,
                                            ILogger<UpdateCropPlantingCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task<CropPlanting?> GetEntityAsync(UpdateCropPlantingCommand request, CancellationToken ct)
    {
        return await Context.CropPlantings.FindAsync([request.Id], ct);
    }

    protected override async Task UpdateEntityProperties(CropPlanting entity, UpdateCropPlantingCommand request)
    {
        //Cần kiểm tra PlantingCode đã có chưa, nếu đã có thì không được update, nếu chưa có thì mới update
        if (request.PlantingCode.HasValueAndIsDifferentFrom(entity.PlantingCode))
            entity.PlantingCode = request.PlantingCode!;
        if (request.FieldId.HasValueAndIsDifferentFrom(entity.FieldId))
            entity.FieldId = request.FieldId!;
        if (request.CropId.HasValueAndIsDifferentFrom(entity.CropId))
            entity.CropId = request.CropId!;
        if (request.CropVarietyId.IsDifferentFrom(entity.CropVarietyId))
            entity.CropVarietyId = request.CropVarietyId;
        if (request.CropScheduleId.IsDifferentFrom(entity.CropScheduleId))
            entity.CropScheduleId = request.CropScheduleId;
        if (request.PlantingDate.IsDifferentFrom(entity.PlantingDate))
            entity.PlantingDate = request.PlantingDate!.Value;
        if (request.ActualHarvestDate.IsDifferentFrom(entity.ActualHarvestDate))
            entity.ActualHarvestDate = request.ActualHarvestDate;
        if (request.ExpectedHarvestDate.IsDifferentFrom(entity.ExpectedHarvestDate))
            entity.ExpectedHarvestDate = request.ExpectedHarvestDate;
        if (request.PlantedArea.IsDifferentFrom(entity.PlantedArea))
            entity.PlantedArea = request.PlantedArea!.Value;
        if (request.QuantityPlanted.IsDifferentFrom(entity.QuantityPlanted))
            entity.QuantityPlanted = request.QuantityPlanted;
        if (request.PlantedUnit.IsDifferentFrom(entity.PlantedUnit))
            entity.PlantedUnit = request.PlantedUnit;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
    }
}

public class UpdateCropPlantingCommandValidator : AbstractValidator<UpdateCropPlantingCommand>
{
    public UpdateCropPlantingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã vụ trồng"));
        RuleFor(x => x.PlantingCode)
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Mã vụ trồng", 50));
        RuleFor(x => x.PlantedArea)
            .GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Diện tích gieo trồng", 1));
        RuleFor(x => x.QuantityPlanted)
            .GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Số lượng gieo trồng", 1));
    }
}