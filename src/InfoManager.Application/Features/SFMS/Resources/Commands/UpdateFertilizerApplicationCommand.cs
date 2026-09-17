namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record UpdateFertilizerApplicationCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? FieldId { get; init; }
    public string? CropPlantingId { get; init; }
    public string? FertilizationPlanId { get; init; }
    public string? FertilizerId { get; init; }
    public DateTimeOffset? AppliedDate { get; init; }
    public decimal? AppliedQuantity { get; init; }
    public string? Unit { get; init; }
    public string? ApplicationMethod { get; init; }
    public string? AppliedBy { get; init; }
    public decimal? Cost { get; init; }
    public string? Notes { get; init; }
}

public class UpdateFertilizerApplicationCommandHandler : BaseUpdateCommandHandler<UpdateFertilizerApplicationCommand, FertilizerApplication>
{
    public UpdateFertilizerApplicationCommandHandler(IApplicationDbContext context,
                                                     IValidator<UpdateFertilizerApplicationCommand> validator,
                                                     ILogger<UpdateFertilizerApplicationCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<FertilizerApplication?> GetEntityAsync(UpdateFertilizerApplicationCommand request, CancellationToken cancellationToken)
        => await Context.FertilizerApplications.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(FertilizerApplication entity, UpdateFertilizerApplicationCommand request)
    {
        if (request.FieldId.IsDifferentFrom(entity.FieldId)) entity.FieldId = request.FieldId;
        if (request.CropPlantingId.IsDifferentFrom(entity.CropPlantingId)) entity.CropPlantingId = request.CropPlantingId;
        if (request.FertilizationPlanId.IsDifferentFrom(entity.FertilizationPlanId)) entity.FertilizationPlanId = request.FertilizationPlanId;
        if (request.FertilizerId.HasValueAndIsDifferentFrom(entity.FertilizerId)) entity.FertilizerId = request.FertilizerId!;
        if (request.AppliedDate.HasValueAndIsDifferentFrom(entity.AppliedDate)) entity.AppliedDate = request.AppliedDate!.Value;
        if (request.AppliedQuantity.HasValueAndIsDifferentFrom(entity.AppliedQuantity)) entity.AppliedQuantity = request.AppliedQuantity!.Value;
        if (request.Unit.HasValueAndIsDifferentFrom(entity.Unit)) entity.Unit = request.Unit!;
        if (request.ApplicationMethod.IsDifferentFrom(entity.ApplicationMethod)) entity.ApplicationMethod = request.ApplicationMethod;
        if (request.AppliedBy.IsDifferentFrom(entity.AppliedBy)) entity.AppliedBy = request.AppliedBy;
        if (request.Cost.IsDifferentFrom(entity.Cost)) entity.Cost = request.Cost;
        if (request.Notes.IsDifferentFrom(entity.Notes)) entity.Notes = request.Notes;
        return Task.CompletedTask;
    }
}

public class UpdateFertilizerApplicationCommandValidator : AbstractValidator<UpdateFertilizerApplicationCommand>
{
    public UpdateFertilizerApplicationCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID lần bón"));
        RuleFor(x => x.FertilizerId).NotEmpty().When(x => x.FertilizerId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID phân bón"));
        RuleFor(x => x.AppliedQuantity).GreaterThan(0).When(x => x.AppliedQuantity.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số lượng đã bón", 0));
        RuleFor(x => x.Unit).NotEmpty().When(x => x.Unit != null).WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(20).When(x => !string.IsNullOrEmpty(x.Unit)).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 20));
        RuleFor(x => x.ApplicationMethod).MaximumLength(100).When(x => x.ApplicationMethod != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Cách bón", 100));
        RuleFor(x => x.AppliedBy).MaximumLength(200).When(x => x.AppliedBy != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người thực hiện", 200));
        RuleFor(x => x.Cost).GreaterThanOrEqualTo(0).When(x => x.Cost.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí", 0));
        RuleFor(x => x.Notes).MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}