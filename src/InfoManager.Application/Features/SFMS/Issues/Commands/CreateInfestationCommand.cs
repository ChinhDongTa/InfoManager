namespace InfoManager.Application.Features.SFMS.Issues.Commands;

public record CreateInfestationCommand : IRequest<Result<string>>
{
    public required string CropPlantingId { get; init; }
    public required InfestationType InfestationType { get; init; }
    public string? PestId { get; init; }
    public string? DiseaseId { get; init; }
    public required DateTimeOffset DetectionDate { get; init; }
    public required decimal AffectedArea { get; init; }
    public required decimal AffectedPercentage { get; init; }
    public required SeverityLevel SeverityLevel { get; init; }
    public required InfestationStatus Status { get; init; }
    public string? TreatmentApplied { get; init; }
    public DateTimeOffset? TreatmentDate { get; init; }
    public string? ProductUsed { get; init; }
    public decimal? TreatmentCost { get; init; }
    public decimal? EffectivenessRating { get; init; }
    public DateTimeOffset? ControlledDate { get; init; }
    public decimal? YieldLossPercentage { get; init; }
    public decimal? EconomicLoss { get; init; }
    public string? Notes { get; init; }
    public string? PhotoUrl { get; init; }
}

public class CreateInfestationCommandHandler : BaseCreateCommandHandler<CreateInfestationCommand, Infestation>
{
    public CreateInfestationCommandHandler(IApplicationDbContext context,
                                           IValidator<CreateInfestationCommand> validator,
                                           ILogger<CreateInfestationCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(Infestation entity, CancellationToken ct)
        => await Context.Infestations.AddAsync(entity, ct);

    protected override Task<Infestation> CreateEntity(CreateInfestationCommand request)
        => Task.FromResult(new Infestation
        {
            CropPlantingId = request.CropPlantingId,
            InfestationType = request.InfestationType,
            PestId = request.PestId,
            DiseaseId = request.DiseaseId,
            DetectionDate = request.DetectionDate,
            AffectedArea = request.AffectedArea,
            AffectedPercentage = request.AffectedPercentage,
            SeverityLevel = request.SeverityLevel,
            Status = request.Status,
            TreatmentApplied = request.TreatmentApplied,
            TreatmentDate = request.TreatmentDate,
            ProductUsed = request.ProductUsed,
            TreatmentCost = request.TreatmentCost,
            EffectivenessRating = request.EffectivenessRating,
            ControlledDate = request.ControlledDate,
            YieldLossPercentage = request.YieldLossPercentage,
            EconomicLoss = request.EconomicLoss,
            Notes = request.Notes,
            PhotoUrl = request.PhotoUrl
        });
}

public class CreateInfestationCommandValidator : AbstractValidator<CreateInfestationCommand>
{
    public CreateInfestationCommandValidator()
    {
        RuleFor(x => x.CropPlantingId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID lần trồng"));
        RuleFor(x => x.PestId)
            .NotEmpty().When(x => x.InfestationType == InfestationType.Pest)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID sâu hại"));
        RuleFor(x => x.DiseaseId)
            .NotEmpty().When(x => x.InfestationType == InfestationType.Disease)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID bệnh"));
        RuleFor(x => x.AffectedArea).GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Diện tích bị ảnh hưởng", 0));
        RuleFor(x => x.AffectedPercentage)
            .InclusiveBetween(0, 100).WithMessage(ErrorHelpers.GetErrorOutOfRange("Tỷ lệ cây bị ảnh hưởng", 0, 100));
        RuleFor(x => x.TreatmentApplied).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.TreatmentApplied))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Biện pháp đã áp dụng", 500));
        RuleFor(x => x.ProductUsed).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.ProductUsed))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Thuốc / chế phẩm", 500));
        RuleFor(x => x.TreatmentCost)
            .GreaterThanOrEqualTo(0).When(x => x.TreatmentCost.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Chi phí xử lý", 0));
        RuleFor(x => x.EffectivenessRating)
            .InclusiveBetween(0, 100).When(x => x.EffectivenessRating.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Hiệu quả xử lý", 0, 100));
        RuleFor(x => x.YieldLossPercentage)
            .InclusiveBetween(0, 100).When(x => x.YieldLossPercentage.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Tỷ lệ giảm năng suất", 0, 100));
        RuleFor(x => x.EconomicLoss)
            .GreaterThanOrEqualTo(0).When(x => x.EconomicLoss.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Thiệt hại kinh tế", 0));
        RuleFor(x => x.ControlledDate)
            .GreaterThanOrEqualTo(x => x.DetectionDate)
            .When(x => x.ControlledDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày kiểm soát phải ≥ ngày phát hiện"));
        RuleFor(x => x.Notes).MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
        RuleFor(x => x.PhotoUrl).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.PhotoUrl))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đường dẫn ảnh", 500));
    }
}