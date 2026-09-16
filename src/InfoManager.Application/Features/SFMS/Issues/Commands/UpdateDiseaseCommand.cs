namespace InfoManager.Application.Features.SFMS.Issues.Commands;

public record UpdateDiseaseCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? CommonName { get; init; }
    public string? ScientificName { get; init; }
    public string? DiseaseType { get; init; }
    public string? CausativeOrganism { get; init; }
    public string? AffectedCrops { get; init; }
    public string? Symptoms { get; init; }
    public string? FavorableConditions { get; init; }
    public string? TransmissionMethod { get; init; }
    public string? PreventionMethods { get; init; }
    public string? RecommendedTreatments { get; init; }
    public SeverityLevel? SeverityLevel { get; init; }
    public string? ImageUrl { get; init; }
}

public class UpdateDiseaseCommandHandler : BaseUpdateCommandHandler<UpdateDiseaseCommand, Disease>
{
    public UpdateDiseaseCommandHandler(IApplicationDbContext context,
                                       IValidator<UpdateDiseaseCommand> validator,
                                       ILogger<UpdateDiseaseCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<Disease?> GetEntityAsync(UpdateDiseaseCommand request, CancellationToken ct)
        => await Context.Diseases.FindAsync([request.Id], ct);

    protected override Task UpdateEntityProperties(Disease entity, UpdateDiseaseCommand request)
    {
        if (request.CommonName.HasValueAndIsDifferentFrom(entity.CommonName))
            entity.CommonName = request.CommonName!;
        if (request.ScientificName.IsDifferentFrom(entity.ScientificName))
            entity.ScientificName = request.ScientificName;
        if (request.DiseaseType.IsDifferentFrom(entity.DiseaseType))
            entity.DiseaseType = request.DiseaseType;
        if (request.CausativeOrganism.IsDifferentFrom(entity.CausativeOrganism))
            entity.CausativeOrganism = request.CausativeOrganism;
        if (request.AffectedCrops.IsDifferentFrom(entity.AffectedCrops))
            entity.AffectedCrops = request.AffectedCrops;
        if (request.Symptoms.IsDifferentFrom(entity.Symptoms))
            entity.Symptoms = request.Symptoms;
        if (request.FavorableConditions.IsDifferentFrom(entity.FavorableConditions))
            entity.FavorableConditions = request.FavorableConditions;
        if (request.TransmissionMethod.IsDifferentFrom(entity.TransmissionMethod))
            entity.TransmissionMethod = request.TransmissionMethod;
        if (request.PreventionMethods.IsDifferentFrom(entity.PreventionMethods))
            entity.PreventionMethods = request.PreventionMethods;
        if (request.RecommendedTreatments.IsDifferentFrom(entity.RecommendedTreatments))
            entity.RecommendedTreatments = request.RecommendedTreatments;
        if (request.SeverityLevel.IsDifferentFrom(entity.SeverityLevel))
            entity.SeverityLevel = request.SeverityLevel;
        if (request.ImageUrl.IsDifferentFrom(entity.ImageUrl))
            entity.ImageUrl = request.ImageUrl;
        return Task.CompletedTask;
    }
}

public class UpdateDiseaseCommandValidator : AbstractValidator<UpdateDiseaseCommand>
{
    public UpdateDiseaseCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID bệnh"));
        RuleFor(x => x.CommonName)
            .NotEmpty().When(x => x.CommonName != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Tên thông thường"))
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.CommonName))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên thông thường", 100));
        RuleFor(x => x.ScientificName).MaximumLength(200).When(x => x.ScientificName != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên khoa học", 200));
        RuleFor(x => x.DiseaseType).MaximumLength(50).When(x => x.DiseaseType != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Loại bệnh", 50));
        RuleFor(x => x.CausativeOrganism).MaximumLength(200).When(x => x.CausativeOrganism != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tác nhân gây bệnh", 200));
        RuleFor(x => x.AffectedCrops).MaximumLength(500).When(x => x.AffectedCrops != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Cây bị ảnh hưởng", 500));
        RuleFor(x => x.Symptoms).MaximumLength(1000).When(x => x.Symptoms != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Triệu chứng", 1000));
        RuleFor(x => x.FavorableConditions).MaximumLength(500).When(x => x.FavorableConditions != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Điều kiện thuận lợi", 500));
        RuleFor(x => x.TransmissionMethod).MaximumLength(500).When(x => x.TransmissionMethod != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Con đường lây truyền", 500));
        RuleFor(x => x.PreventionMethods).MaximumLength(1000).When(x => x.PreventionMethods != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Biện pháp phòng ngừa", 1000));
        RuleFor(x => x.RecommendedTreatments).MaximumLength(1000).When(x => x.RecommendedTreatments != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Biện pháp xử lý", 1000));
        RuleFor(x => x.ImageUrl).MaximumLength(500).When(x => x.ImageUrl != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đường dẫn ảnh", 500));
    }
}