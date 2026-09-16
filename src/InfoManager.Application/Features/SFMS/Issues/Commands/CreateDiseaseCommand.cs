namespace InfoManager.Application.Features.SFMS.Issues.Commands;

public record CreateDiseaseCommand : IRequest<Result<string>>
{
    public required string CommonName { get; init; }
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

public class CreateDiseaseCommandHandler : BaseCreateCommandHandler<CreateDiseaseCommand, Disease>
{
    public CreateDiseaseCommandHandler(IApplicationDbContext context,
                                       IValidator<CreateDiseaseCommand> validator,
                                       ILogger<CreateDiseaseCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(Disease entity, CancellationToken ct)
        => await Context.Diseases.AddAsync(entity, ct);

    protected override Task<Disease> CreateEntity(CreateDiseaseCommand request)
        => Task.FromResult(new Disease
        {
            CommonName = request.CommonName,
            ScientificName = request.ScientificName,
            DiseaseType = request.DiseaseType,
            CausativeOrganism = request.CausativeOrganism,
            AffectedCrops = request.AffectedCrops,
            Symptoms = request.Symptoms,
            FavorableConditions = request.FavorableConditions,
            TransmissionMethod = request.TransmissionMethod,
            PreventionMethods = request.PreventionMethods,
            RecommendedTreatments = request.RecommendedTreatments,
            SeverityLevel = request.SeverityLevel,
            ImageUrl = request.ImageUrl
        });
}

public class CreateDiseaseCommandValidator : AbstractValidator<CreateDiseaseCommand>
{
    public CreateDiseaseCommandValidator()
    {
        RuleFor(x => x.CommonName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên thông thường"))
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên thông thường", 100));
        RuleFor(x => x.ScientificName).MaximumLength(200).When(x => !string.IsNullOrEmpty(x.ScientificName))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên khoa học", 200));
        RuleFor(x => x.DiseaseType).MaximumLength(50).When(x => !string.IsNullOrEmpty(x.DiseaseType))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Loại bệnh", 50));
        RuleFor(x => x.CausativeOrganism).MaximumLength(200).When(x => !string.IsNullOrEmpty(x.CausativeOrganism))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tác nhân gây bệnh", 200));
        RuleFor(x => x.AffectedCrops).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.AffectedCrops))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Cây bị ảnh hưởng", 500));
        RuleFor(x => x.Symptoms).MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Symptoms))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Triệu chứng", 1000));
        RuleFor(x => x.FavorableConditions).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.FavorableConditions))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Điều kiện thuận lợi", 500));
        RuleFor(x => x.TransmissionMethod).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.TransmissionMethod))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Con đường lây truyền", 500));
        RuleFor(x => x.PreventionMethods).MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.PreventionMethods))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Biện pháp phòng ngừa", 1000));
        RuleFor(x => x.RecommendedTreatments).MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.RecommendedTreatments))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Biện pháp xử lý", 1000));
        RuleFor(x => x.ImageUrl).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.ImageUrl))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đường dẫn ảnh", 500));
    }
}