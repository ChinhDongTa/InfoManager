namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record CreatePesticideApplicationCommand : IRequest<Result<string>>
{
    public required string FarmId { get; init; }
    public required string PesticideId { get; init; }
    public required DateTimeOffset AppliedDate { get; init; }
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

public class CreatePesticideApplicationCommandHandler : BaseCreateCommandHandler<CreatePesticideApplicationCommand, PesticideApplication>
{
    public CreatePesticideApplicationCommandHandler(IApplicationDbContext context,
                                                    IValidator<CreatePesticideApplicationCommand> validator,
                                                    ILogger<CreatePesticideApplicationCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(PesticideApplication entity, CancellationToken cancellationToken)
        => await Context.PesticideApplications.AddAsync(entity, cancellationToken);

    protected override async Task<PesticideApplication> CreateEntity(CreatePesticideApplicationCommand request)
    {
        var pesticide = await Context.Pesticides.FindAsync([request.PesticideId]);
        DateOnly? safeDate = pesticide?.PreHarvestIntervalDays is int days
            ? DateOnly.FromDateTime(request.AppliedDate.UtcDateTime.AddDays(days))
            : null;

        return new PesticideApplication
        {
            FarmId = request.FarmId,
            PesticideId = request.PesticideId,
            AppliedDate = request.AppliedDate,
            AppliedQuantity = request.AppliedQuantity,
            FieldId = request.FieldId,
            CropPlantingId = request.CropPlantingId,
            PesticidePlanId = request.PesticidePlanId,
            Unit = request.Unit,
            ApplicationMethod = request.ApplicationMethod,
            AppliedBy = request.AppliedBy,
            Cost = request.Cost,
            SafeHarvestDate = safeDate,
            Notes = request.Notes
        };
    }
}

public class CreatePesticideApplicationCommandValidator : AbstractValidator<CreatePesticideApplicationCommand>
{
    public CreatePesticideApplicationCommandValidator()
    {
        RuleFor(x => x.FarmId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));
        RuleFor(x => x.PesticideId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID thuốc"));
        RuleFor(x => x.AppliedQuantity).GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Số lượng đã dùng", 0));
        RuleFor(x => x.Unit).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(20).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 20));
        RuleFor(x => x.ApplicationMethod).MaximumLength(100).When(x => !string.IsNullOrEmpty(x.ApplicationMethod))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Cách phun", 100));
        RuleFor(x => x.AppliedBy).MaximumLength(200).When(x => !string.IsNullOrEmpty(x.AppliedBy))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người thực hiện", 200));
        RuleFor(x => x.Cost).GreaterThanOrEqualTo(0).When(x => x.Cost.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí", 0));
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}