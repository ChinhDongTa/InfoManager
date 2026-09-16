namespace InfoManager.Application.Features.SFMS.Issues.Commands;

public record UpdateInfestationCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? CropPlantingId { get; init; }
    public InfestationType? InfestationType { get; init; }
    public string? PestId { get; init; }
    public string? DiseaseId { get; init; }
    public DateTimeOffset? DetectionDate { get; init; }
    public decimal? AffectedArea { get; init; }
    public decimal? AffectedPercentage { get; init; }
    public SeverityLevel? SeverityLevel { get; init; }
    public InfestationStatus? Status { get; init; }
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

public class UpdateInfestationCommandHandler : BaseUpdateCommandHandler<UpdateInfestationCommand, Infestation>
{
    public UpdateInfestationCommandHandler(IApplicationDbContext context,
                                           IValidator<UpdateInfestationCommand> validator,
                                           ILogger<UpdateInfestationCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<Infestation?> GetEntityAsync(UpdateInfestationCommand request, CancellationToken ct)
        => await Context.Infestations.FindAsync([request.Id], ct);

    protected override Task UpdateEntityProperties(Infestation entity, UpdateInfestationCommand request)
    {
        if (request.CropPlantingId.HasValueAndIsDifferentFrom(entity.CropPlantingId))
            entity.CropPlantingId = request.CropPlantingId!;
        if (request.InfestationType.HasValueAndIsDifferentFrom(entity.InfestationType))
            entity.InfestationType = request.InfestationType!.Value;
        if (request.PestId.IsDifferentFrom(entity.PestId))
            entity.PestId = request.PestId;
        if (request.DiseaseId.IsDifferentFrom(entity.DiseaseId))
            entity.DiseaseId = request.DiseaseId;
        if (request.DetectionDate.HasValueAndIsDifferentFrom(entity.DetectionDate))
            entity.DetectionDate = request.DetectionDate!.Value;
        if (request.AffectedArea.HasValueAndIsDifferentFrom(entity.AffectedArea))
            entity.AffectedArea = request.AffectedArea!.Value;
        if (request.AffectedPercentage.HasValueAndIsDifferentFrom(entity.AffectedPercentage))
            entity.AffectedPercentage = request.AffectedPercentage!.Value;
        if (request.SeverityLevel.HasValueAndIsDifferentFrom(entity.SeverityLevel))
            entity.SeverityLevel = request.SeverityLevel!.Value;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
        if (request.TreatmentApplied.IsDifferentFrom(entity.TreatmentApplied))
            entity.TreatmentApplied = request.TreatmentApplied;
        if (request.TreatmentDate.IsDifferentFrom(entity.TreatmentDate))
            entity.TreatmentDate = request.TreatmentDate;
        if (request.ProductUsed.IsDifferentFrom(entity.ProductUsed))
            entity.ProductUsed = request.ProductUsed;
        if (request.TreatmentCost.IsDifferentFrom(entity.TreatmentCost))
            entity.TreatmentCost = request.TreatmentCost;
        if (request.EffectivenessRating.IsDifferentFrom(entity.EffectivenessRating))
            entity.EffectivenessRating = request.EffectivenessRating;
        if (request.ControlledDate.IsDifferentFrom(entity.ControlledDate))
            entity.ControlledDate = request.ControlledDate;
        if (request.YieldLossPercentage.IsDifferentFrom(entity.YieldLossPercentage))
            entity.YieldLossPercentage = request.YieldLossPercentage;
        if (request.EconomicLoss.IsDifferentFrom(entity.EconomicLoss))
            entity.EconomicLoss = request.EconomicLoss;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
        if (request.PhotoUrl.IsDifferentFrom(entity.PhotoUrl))
            entity.PhotoUrl = request.PhotoUrl;
        return Task.CompletedTask;
    }
}

public class UpdateInfestationCommandValidator : AbstractValidator<UpdateInfestationCommand>
{
    public UpdateInfestationCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID vụ sâu bệnh"));
        RuleFor(x => x.CropPlantingId)
            .NotEmpty().When(x => x.CropPlantingId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID lần trồng"));
        RuleFor(x => x.PestId)
            .NotEmpty().When(x => x.InfestationType == InfestationType.Pest)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID sâu hại"));
        RuleFor(x => x.DiseaseId)
            .NotEmpty().When(x => x.InfestationType == InfestationType.Disease)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID bệnh"));
        RuleFor(x => x.AffectedArea)
            .GreaterThanOrEqualTo(0).When(x => x.AffectedArea.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Diện tích bị ảnh hưởng", 0));
        RuleFor(x => x.AffectedPercentage)
            .InclusiveBetween(0, 100).When(x => x.AffectedPercentage.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Tỷ lệ cây bị ảnh hưởng", 0, 100));
        RuleFor(x => x.TreatmentApplied).MaximumLength(500).When(x => x.TreatmentApplied != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Biện pháp đã áp dụng", 500));
        RuleFor(x => x.ProductUsed).MaximumLength(500).When(x => x.ProductUsed != null)
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
            .When(x => x.DetectionDate.HasValue && x.ControlledDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày kiểm soát phải ≥ ngày phát hiện"));
        RuleFor(x => x.Notes).MaximumLength(1000).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
        RuleFor(x => x.PhotoUrl).MaximumLength(500).When(x => x.PhotoUrl != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đường dẫn ảnh", 500));
    }
}