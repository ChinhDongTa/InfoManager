namespace InfoManager.Application.Features.SFMS.Resources.Commands;
public record UpdatePesticideApplicationCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? FarmId { get; init; }
    public string? PesticideId { get; init; }
    public DateTimeOffset? AppliedDate { get; init; }
    public required decimal AppliedQuantity { get; init; }
    public string? FieldId { get; init; }
    public string? CropPlantingId { get; init; }
    public string? PesticidePlanId { get; init; }
    public required string Unit { get; init; }
    public string? ApplicationMethod { get; init; }
    public string? AppliedBy { get; init; }
    public decimal? Cost { get; init; }
    public string? Notes { get; init; }
}

public class UpdatePesticideApplicationCommandHandler : BaseUpdateCommandHandler<UpdatePesticideApplicationCommand, PesticideApplication>
{
    public UpdatePesticideApplicationCommandHandler(IApplicationDbContext context,
                                                    IValidator<UpdatePesticideApplicationCommand> validator,
                                                    ILogger<UpdatePesticideApplicationCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<PesticideApplication?> GetEntityAsync(UpdatePesticideApplicationCommand request, CancellationToken cancellationToken)
        => await Context.PesticideApplications.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(PesticideApplication entity, UpdatePesticideApplicationCommand request)
    {
        if (request.FarmId.HasValueAndIsDifferentFrom(entity.FarmId)) entity.FarmId = request.FarmId!;
        if (request.PesticideId.HasValueAndIsDifferentFrom(entity.PesticideId)) entity.PesticideId = request.PesticideId!;
        if (request.AppliedDate.HasValueAndIsDifferentFrom(entity.AppliedDate)) entity.AppliedDate = request.AppliedDate!.Value;
        if (request.AppliedQuantity != entity.AppliedQuantity) entity.AppliedQuantity = request.AppliedQuantity;
        if (request.FieldId.IsDifferentFrom(entity.FieldId)) entity.FieldId = request.FieldId;
        if (request.CropPlantingId.IsDifferentFrom(entity.CropPlantingId)) entity.CropPlantingId = request.CropPlantingId;
        if (request.PesticidePlanId.IsDifferentFrom(entity.PesticidePlanId)) entity.PesticidePlanId = request.PesticidePlanId;
        if (request.Unit.HasValueAndIsDifferentFrom(entity.Unit)) entity.Unit = request.Unit;
        if (request.ApplicationMethod.IsDifferentFrom(entity.ApplicationMethod)) entity.ApplicationMethod = request.ApplicationMethod;
        if (request.AppliedBy.IsDifferentFrom(entity.AppliedBy)) entity.AppliedBy = request.AppliedBy;
        if (request.Cost.IsDifferentFrom(entity.Cost)) entity.Cost = request.Cost;
        if (request.Notes.IsDifferentFrom(entity.Notes)) entity.Notes = request.Notes;
        return Task.CompletedTask;
    }
}

public class UpdatePesticideApplicationCommandValidator : AbstractValidator<UpdatePesticideApplicationCommand>
{
    public UpdatePesticideApplicationCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID lần phun"));
        RuleFor(x => x.FarmId).NotEmpty().When(x => x.FarmId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));
        RuleFor(x => x.PesticideId).NotEmpty().When(x => x.PesticideId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID thuốc"));
        RuleFor(x => x.AppliedQuantity).GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Số lượng đã dùng", 0));
        RuleFor(x => x.Unit).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(20).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 20));
        RuleFor(x => x.ApplicationMethod).MaximumLength(100).When(x => x.ApplicationMethod != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Cách phun", 100));
        RuleFor(x => x.AppliedBy).MaximumLength(200).When(x => x.AppliedBy != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người thực hiện", 200));
        RuleFor(x => x.Cost).GreaterThanOrEqualTo(0).When(x => x.Cost.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí", 0));
        RuleFor(x => x.Notes).MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}