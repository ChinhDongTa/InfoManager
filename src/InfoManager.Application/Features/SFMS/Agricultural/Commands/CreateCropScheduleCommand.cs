namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record CreateCropScheduleCommand : IRequest<Result<string>>
{
    public required string ScheduleName { get; init; }
    public required string CropId { get; init; }
    public string? CropVarietyId { get; init; }
    public string? PlantingSeason { get; init; }
    public string? PlantingDateRange { get; init; }
    public string? HarvestDateRange { get; init; }
    public int DaysToHarvest { get; init; }
    public decimal? PlantSpacing { get; init; }
    public decimal? RowSpacing { get; init; }
    public string? IrrigationSchedule { get; init; }
    public string? FertilizationSchedule { get; init; }
    public string? PesticideSchedule { get; init; }
    public decimal? ExpectedYield { get; init; }
    public decimal? EstimatedCost { get; init; }
    public bool IsActive { get; init; } = true;
    public string? Notes { get; init; }
}

public class CreateCropScheduleCommandHandler : BaseCreateCommandHandler<CreateCropScheduleCommand, CropSchedule>
{
    public CreateCropScheduleCommandHandler(IApplicationDbContext context,
                                            IValidator<CreateCropScheduleCommand> validator,
                                            ILogger<CreateCropScheduleCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(CropSchedule entity, CancellationToken ct)
    {
        await Context.CropSchedules.AddAsync(entity, ct);
    }

    protected override async Task<CropSchedule> CreateEntity(CreateCropScheduleCommand request)
    {
        return new CropSchedule
        {
            ScheduleName = request.ScheduleName,
            CropId = request.CropId,
            CropVarietyId = request.CropVarietyId,
            PlantingSeason = request.PlantingSeason,
            PlantingDateRange = request.PlantingDateRange,
            HarvestDateRange = request.HarvestDateRange,
            DaysToHarvest = request.DaysToHarvest,
            PlantSpacing = request.PlantSpacing,
            RowSpacing = request.RowSpacing,
            IrrigationSchedule = request.IrrigationSchedule,
            FertilizationSchedule = request.FertilizationSchedule,
            PesticideSchedule = request.PesticideSchedule,
            ExpectedYield = request.ExpectedYield,
            EstimatedCost = request.EstimatedCost,
            IsActive = request.IsActive,
            Notes = request.Notes
        };
    }
}

public class CreateCropScheduleCommandValidator : AbstractValidator<CreateCropScheduleCommand>
{
    public CreateCropScheduleCommandValidator()
    {
        RuleFor(x => x.ScheduleName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên lịch trình"))
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên lịch trình", 100));
        RuleFor(x => x.CropId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã cây trồng"));
        RuleFor(x => x.DaysToHarvest)
            .GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Số ngày thu hoạch", 0));
        RuleFor(x => x.PlantSpacing)
            .GreaterThanOrEqualTo(1).When(x => x.PlantSpacing.HasValue).WithMessage(ErrorHelpers.GetErrorMinValue("Khoảng cách trồng", 1));
        RuleFor(x => x.RowSpacing)
            .GreaterThanOrEqualTo(1).When(x => x.RowSpacing.HasValue).WithMessage(ErrorHelpers.GetErrorMinValue("Khoảng cách hàng", 1));
        RuleFor(x => x.ExpectedYield)
            .GreaterThanOrEqualTo(1).When(x => x.ExpectedYield.HasValue).WithMessage(ErrorHelpers.GetErrorMinValue("Năng suất dự kiến", 1));
        RuleFor(x => x.EstimatedCost)
            .GreaterThanOrEqualTo(1).When(x => x.EstimatedCost.HasValue).WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí dự kiến", 1));
    }
}