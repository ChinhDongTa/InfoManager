namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record UpdatePesticidePlanCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? PesticideId { get; init; }
    public string? PlanName { get; init; }
    public string? Target { get; init; }
    public DateTimeOffset? PlannedDate { get; init; }
    public decimal? PlannedQuantity { get; init; }
    public string? Unit { get; init; }
    public string? ApplicationMethod { get; init; }
    public PesticidePlanStatus? Status { get; init; }
    public string? Notes { get; init; }
}

public class UpdatePesticidePlanCommandHandler : BaseUpdateCommandHandler<UpdatePesticidePlanCommand, PesticidePlan>
{
    public UpdatePesticidePlanCommandHandler(IApplicationDbContext context,
                                             IValidator<UpdatePesticidePlanCommand> validator,
                                             ILogger<UpdatePesticidePlanCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<PesticidePlan?> GetEntityAsync(UpdatePesticidePlanCommand request, CancellationToken cancellationToken)
        => await Context.PesticidePlans.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(PesticidePlan entity, UpdatePesticidePlanCommand request)
    {
        if (request.PesticideId.HasValueAndIsDifferentFrom(entity.PesticideId)) entity.PesticideId = request.PesticideId!;
        if (request.PlanName.HasValueAndIsDifferentFrom(entity.PlanName)) entity.PlanName = request.PlanName!;
        if (request.Target.IsDifferentFrom(entity.Target)) entity.Target = request.Target;
        if (request.PlannedDate.HasValueAndIsDifferentFrom(entity.PlannedDate)) entity.PlannedDate = request.PlannedDate!.Value;
        if (request.PlannedQuantity.HasValueAndIsDifferentFrom(entity.PlannedQuantity)) entity.PlannedQuantity = request.PlannedQuantity!.Value;
        if (request.Unit.HasValueAndIsDifferentFrom(entity.Unit)) entity.Unit = request.Unit!;
        if (request.ApplicationMethod.IsDifferentFrom(entity.ApplicationMethod)) entity.ApplicationMethod = request.ApplicationMethod;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status)) entity.Status = request.Status!.Value;
        if (request.Notes.IsDifferentFrom(entity.Notes)) entity.Notes = request.Notes;
        return Task.CompletedTask;
    }
}

public class UpdatePesticidePlanCommandValidator : AbstractValidator<UpdatePesticidePlanCommand>
{
    public UpdatePesticidePlanCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID kế hoạch phun"));
        RuleFor(x => x.PesticideId).NotEmpty().When(x => x.PesticideId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID thuốc"));
        RuleFor(x => x.PlanName).NotEmpty().When(x => x.PlanName != null).WithMessage(ErrorHelpers.GetErrorRequired("Tên kế hoạch"))
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.PlanName)).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên kế hoạch", 200));
        RuleFor(x => x.Target).MaximumLength(200).When(x => x.Target != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mục đích", 200));
        RuleFor(x => x.PlannedQuantity).GreaterThan(0).When(x => x.PlannedQuantity.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Liều lượng kế hoạch", 0));
        RuleFor(x => x.Unit).NotEmpty().When(x => x.Unit != null).WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(20).When(x => !string.IsNullOrEmpty(x.Unit)).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 20));
        RuleFor(x => x.ApplicationMethod).MaximumLength(100).When(x => x.ApplicationMethod != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Cách phun", 100));
        RuleFor(x => x.Notes).MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}