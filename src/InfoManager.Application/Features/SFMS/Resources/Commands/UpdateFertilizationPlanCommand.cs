namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record UpdateFertilizationPlanCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? FertilizerId { get; init; }
    public string? PlanName { get; init; }
    public DateTimeOffset? PlannedDate { get; init; }
    public string? CropPlantingId { get; init; }
    public string? GrowthStageId { get; init; }
    public int? DaysAfterPlanting { get; init; }
    public decimal? PlannedQuantity { get; init; }
    public string? Unit { get; init; }
    public string? ApplicationMethod { get; init; }
    public FertilizationPlanStatus? Status { get; init; }
    public string? Notes { get; init; }
}

public class UpdateFertilizationPlanCommandHandler : BaseUpdateCommandHandler<UpdateFertilizationPlanCommand, FertilizationPlan>
{
    public UpdateFertilizationPlanCommandHandler(IApplicationDbContext context,
                                                 IValidator<UpdateFertilizationPlanCommand> validator,
                                                 ILogger<UpdateFertilizationPlanCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<FertilizationPlan?> GetEntityAsync(UpdateFertilizationPlanCommand request, CancellationToken cancellationToken)
        => await Context.FertilizationPlans.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(FertilizationPlan entity, UpdateFertilizationPlanCommand request)
    {
        if (request.FertilizerId.HasValueAndIsDifferentFrom(entity.FertilizerId)) entity.FertilizerId = request.FertilizerId!;
        if (request.PlanName.HasValueAndIsDifferentFrom(entity.PlanName)) entity.PlanName = request.PlanName!;
        if (request.PlannedDate.HasValueAndIsDifferentFrom(entity.PlannedDate)) entity.PlannedDate = request.PlannedDate!.Value;
        if (request.CropPlantingId.IsDifferentFrom(entity.CropPlantingId)) entity.CropPlantingId = request.CropPlantingId;
        if (request.GrowthStageId.IsDifferentFrom(entity.GrowthStageId)) entity.GrowthStageId = request.GrowthStageId;
        if (request.DaysAfterPlanting.IsDifferentFrom(entity.DaysAfterPlanting)) entity.DaysAfterPlanting = request.DaysAfterPlanting;
        if (request.PlannedQuantity.HasValueAndIsDifferentFrom(entity.PlannedQuantity)) entity.PlannedQuantity = request.PlannedQuantity!.Value;
        if (request.Unit.HasValueAndIsDifferentFrom(entity.Unit)) entity.Unit = request.Unit!;
        if (request.ApplicationMethod.IsDifferentFrom(entity.ApplicationMethod)) entity.ApplicationMethod = request.ApplicationMethod;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status)) entity.Status = request.Status!.Value;
        if (request.Notes.IsDifferentFrom(entity.Notes)) entity.Notes = request.Notes;
        return Task.CompletedTask;
    }
}

public class UpdateFertilizationPlanCommandValidator : AbstractValidator<UpdateFertilizationPlanCommand>
{
    public UpdateFertilizationPlanCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID kế hoạch bón"));
        RuleFor(x => x.FertilizerId).NotEmpty().When(x => x.FertilizerId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID phân bón"));
        RuleFor(x => x.PlanName).NotEmpty().When(x => x.PlanName != null).WithMessage(ErrorHelpers.GetErrorRequired("Tên kế hoạch"))
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.PlanName)).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên kế hoạch", 200));
        RuleFor(x => x.DaysAfterPlanting).GreaterThanOrEqualTo(0).When(x => x.DaysAfterPlanting.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số ngày sau trồng", 0));
        RuleFor(x => x.PlannedQuantity).GreaterThan(0).When(x => x.PlannedQuantity.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Liều lượng kế hoạch", 0));
        RuleFor(x => x.Unit).NotEmpty().When(x => x.Unit != null).WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(20).When(x => !string.IsNullOrEmpty(x.Unit)).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 20));
        RuleFor(x => x.ApplicationMethod).MaximumLength(100).When(x => x.ApplicationMethod != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Cách bón", 100));
        RuleFor(x => x.Notes).MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}