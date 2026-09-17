namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record CreatePesticidePlanCommand : IRequest<Result<string>>
{
    public required string FarmId { get; init; }
    public required string PesticideId { get; init; }
    public required string PlanName { get; init; }
    public required DateTimeOffset PlannedDate { get; init; }
    public string? CropPlantingId { get; init; }
    public string? GrowthStageId { get; init; }
    public string? Target { get; init; }
    public required decimal PlannedQuantity { get; init; }
    public required string Unit { get; init; }
    public string? ApplicationMethod { get; init; }
    public PesticidePlanStatus? Status { get; init; }
    public string? Notes { get; init; }
}

public class CreatePesticidePlanCommandHandler : BaseCreateCommandHandler<CreatePesticidePlanCommand, PesticidePlan>
{
    public CreatePesticidePlanCommandHandler(IApplicationDbContext context,
                                             IValidator<CreatePesticidePlanCommand> validator,
                                             ILogger<CreatePesticidePlanCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(PesticidePlan entity, CancellationToken cancellationToken)
        => await Context.PesticidePlans.AddAsync(entity, cancellationToken);

    protected override Task<PesticidePlan> CreateEntity(CreatePesticidePlanCommand request)
        => Task.FromResult(new PesticidePlan
        {
            FarmId = request.FarmId,
            PesticideId = request.PesticideId,
            PlanName = request.PlanName,
            PlannedDate = request.PlannedDate,
            CropPlantingId = request.CropPlantingId,
            GrowthStageId = request.GrowthStageId,
            Target = request.Target,
            PlannedQuantity = request.PlannedQuantity,
            Unit = request.Unit,
            ApplicationMethod = request.ApplicationMethod,
            Status = request.Status ?? PesticidePlanStatus.Planned,
            Notes = request.Notes
        });
}

public class CreatePesticidePlanCommandValidator : AbstractValidator<CreatePesticidePlanCommand>
{
    public CreatePesticidePlanCommandValidator()
    {
        RuleFor(x => x.FarmId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));
        RuleFor(x => x.PesticideId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID thuốc"));
        RuleFor(x => x.PlanName).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên kế hoạch"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên kế hoạch", 200));
        RuleFor(x => x.Target).MaximumLength(200).When(x => !string.IsNullOrEmpty(x.Target))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mục đích", 200));
        RuleFor(x => x.PlannedQuantity).GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Liều lượng kế hoạch", 0));
        RuleFor(x => x.Unit).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(20).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 20));
        RuleFor(x => x.ApplicationMethod).MaximumLength(100).When(x => !string.IsNullOrEmpty(x.ApplicationMethod))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Cách phun", 100));
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}