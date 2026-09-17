namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record CreateFertilizationPlanCommand : IRequest<Result<string>>
{
    public required string FarmId { get; init; }
    public required string FertilizerId { get; init; }
    public required string PlanName { get; init; }
    public required DateTimeOffset PlannedDate { get; init; }
    public string? CropPlantingId { get; init; }
    public string? GrowthStageId { get; init; }
    public int? DaysAfterPlanting { get; init; }
    public required decimal PlannedQuantity { get; init; }
    public required string Unit { get; init; }
    public string? ApplicationMethod { get; init; }
    public required FertilizationPlanStatus Status { get; init; }
    public string? Notes { get; init; }
}

public class CreateFertilizationPlanCommandHandler : BaseCreateCommandHandler<CreateFertilizationPlanCommand, FertilizationPlan>
{
    public CreateFertilizationPlanCommandHandler(IApplicationDbContext context,
                                                 IValidator<CreateFertilizationPlanCommand> validator,
                                                 ILogger<CreateFertilizationPlanCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(FertilizationPlan entity, CancellationToken cancellationToken)
        => await Context.FertilizationPlans.AddAsync(entity, cancellationToken);

    protected override Task<FertilizationPlan> CreateEntity(CreateFertilizationPlanCommand request)
        => Task.FromResult(new FertilizationPlan
        {
            FarmId = request.FarmId,
            FertilizerId = request.FertilizerId,
            PlanName = request.PlanName,
            PlannedDate = request.PlannedDate,
            CropPlantingId = request.CropPlantingId,
            GrowthStageId = request.GrowthStageId,
            DaysAfterPlanting = request.DaysAfterPlanting,
            PlannedQuantity = request.PlannedQuantity,
            Unit = request.Unit,
            ApplicationMethod = request.ApplicationMethod,
            Status = request.Status,
            Notes = request.Notes
        });
}

public class CreateFertilizationPlanCommandValidator : AbstractValidator<CreateFertilizationPlanCommand>
{
    public CreateFertilizationPlanCommandValidator()
    {
        RuleFor(x => x.FarmId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));
        RuleFor(x => x.FertilizerId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID phân bón"));
        RuleFor(x => x.PlanName).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên kế hoạch"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên kế hoạch", 200));
        RuleFor(x => x.DaysAfterPlanting).GreaterThanOrEqualTo(0).When(x => x.DaysAfterPlanting.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số ngày sau trồng", 0));
        RuleFor(x => x.PlannedQuantity).GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Liều lượng kế hoạch", 0));
        RuleFor(x => x.Unit).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(20).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 20));
        RuleFor(x => x.ApplicationMethod).MaximumLength(100).When(x => !string.IsNullOrEmpty(x.ApplicationMethod))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Cách bón", 100));
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}