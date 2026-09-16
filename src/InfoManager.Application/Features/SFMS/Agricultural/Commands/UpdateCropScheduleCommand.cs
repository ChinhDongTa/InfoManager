namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record UpdateCropScheduleCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? ScheduleName { get; init; }
    public string? CropId { get; init; }
    public string? CropVarietyId { get; init; }
    public string? PlantingSeason { get; init; }
    public string? PlantingDateRange { get; init; }
    public string? HarvestDateRange { get; init; }
    public int? DaysToHarvest { get; init; }
    public decimal? PlantSpacing { get; init; }
    public decimal? RowSpacing { get; init; }
    public string? IrrigationSchedule { get; init; }
    public string? FertilizationSchedule { get; init; }
    public string? PesticideSchedule { get; init; }
    public decimal? ExpectedYield { get; init; }
    public decimal? EstimatedCost { get; init; }
    public bool? IsActive { get; init; } = true;
    public string? Notes { get; init; }
}

public class UpdateCropScheduleCommandHandler : BaseUpdateCommandHandler<UpdateCropScheduleCommand, CropSchedule>
{
    public UpdateCropScheduleCommandHandler(IApplicationDbContext context, IValidator<UpdateCropScheduleCommand> validator, ILogger<UpdateCropScheduleCommandHandler> logger)
        : base(context, validator, logger)
    {
    }

    protected override async Task<CropSchedule?> GetEntityAsync(UpdateCropScheduleCommand request, CancellationToken ct)
    {
        return await Context.CropSchedules.FindAsync([request.Id], ct);
    }

    protected override async Task UpdateEntityProperties(CropSchedule entity, UpdateCropScheduleCommand request)
    {
        if (request.ScheduleName.HasValueAndIsDifferentFrom(entity.ScheduleName))
            entity.ScheduleName = request.ScheduleName!;
        if (request.CropId.HasValueAndIsDifferentFrom(entity.CropId))
            entity.CropId = request.CropId!;
        if (request.CropVarietyId.IsDifferentFrom(entity.CropVarietyId))
            entity.CropVarietyId = request.CropVarietyId!;
        if (request.PlantingSeason.IsDifferentFrom(entity.PlantingSeason))
            entity.PlantingSeason = request.PlantingSeason!;
        if (request.PlantingDateRange.IsDifferentFrom(entity.PlantingDateRange))
            entity.PlantingDateRange = request.PlantingDateRange!;
        if (request.HarvestDateRange.IsDifferentFrom(entity.HarvestDateRange))
            entity.HarvestDateRange = request.HarvestDateRange!;
        if (request.DaysToHarvest.HasValueAndIsDifferentFrom(entity.DaysToHarvest))
            entity.DaysToHarvest = request.DaysToHarvest!.Value;
        if (request.PlantSpacing.IsDifferentFrom(entity.PlantSpacing))
            entity.PlantSpacing = request.PlantSpacing;
        if (request.RowSpacing.IsDifferentFrom(entity.RowSpacing))
            entity.RowSpacing = request.RowSpacing;
        if (request.IrrigationSchedule.IsDifferentFrom(entity.IrrigationSchedule))
            entity.IrrigationSchedule = request.IrrigationSchedule;
        if (request.FertilizationSchedule.IsDifferentFrom(entity.FertilizationSchedule))
            entity.FertilizationSchedule = request.FertilizationSchedule;
        if (request.PesticideSchedule.IsDifferentFrom(entity.PesticideSchedule))
            entity.PesticideSchedule = request.PesticideSchedule;
        if (request.ExpectedYield.IsDifferentFrom(entity.ExpectedYield))
            entity.ExpectedYield = request.ExpectedYield;
        if (request.EstimatedCost.IsDifferentFrom(entity.EstimatedCost))
            entity.EstimatedCost = request.EstimatedCost;
        if (request.IsActive.HasValue && request.IsActive != entity.IsActive)
            entity.IsActive = request.IsActive.Value;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
    }
}

public class UpdateCropScheduleCommandValidator : AbstractValidator<UpdateCropScheduleCommand>
{
    public UpdateCropScheduleCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.ScheduleName).MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("ScheduleName", 200));
    }
}