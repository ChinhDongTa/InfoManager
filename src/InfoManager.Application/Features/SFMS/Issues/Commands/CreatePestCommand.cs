namespace InfoManager.Application.Features.SFMS.Issues.Commands;

public record CreatePestCommand : IRequest<Result<string>>
{
    public required string CommonName { get; init; }
    public string? ScientificName { get; init; }
    public string? PestType { get; init; }
    public string? Description { get; init; }
    public string? AffectedCrops { get; init; }
    public string? DamageSymptoms { get; init; }
    public string? LifeCycle { get; init; }
    public string? PreventionMethods { get; init; }
    public string? RecommendedPesticides { get; init; }
    public string? BiologicalControl { get; init; }
    public SeverityLevel? SeverityLevel { get; init; }
    public string? ImageUrl { get; init; }
}

public class CreatePestCommandHandler : BaseCreateCommandHandler<CreatePestCommand, Pest>
{
    public CreatePestCommandHandler(IApplicationDbContext context,
                                    IValidator<CreatePestCommand> validator,
                                    ILogger<CreatePestCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(Pest entity, CancellationToken ct)
        => await Context.Pests.AddAsync(entity, ct);

    protected override Task<Pest> CreateEntity(CreatePestCommand request)
        => Task.FromResult(new Pest
        {
            CommonName = request.CommonName,
            ScientificName = request.ScientificName,
            PestType = request.PestType,
            Description = request.Description,
            AffectedCrops = request.AffectedCrops,
            DamageSymptoms = request.DamageSymptoms,
            LifeCycle = request.LifeCycle,
            PreventionMethods = request.PreventionMethods,
            RecommendedPesticides = request.RecommendedPesticides,
            BiologicalControl = request.BiologicalControl,
            SeverityLevel = request.SeverityLevel,
            ImageUrl = request.ImageUrl
        });
}

public class CreatePestCommandValidator : AbstractValidator<CreatePestCommand>
{
    public CreatePestCommandValidator()
    {
        RuleFor(x => x.CommonName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên thông thường"))
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên thông thường", 100));
        RuleFor(x => x.ScientificName).MaximumLength(200).When(x => !string.IsNullOrEmpty(x.ScientificName))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên khoa học", 200));
        RuleFor(x => x.PestType).MaximumLength(50).When(x => !string.IsNullOrEmpty(x.PestType))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Loại sâu hại", 50));
        RuleFor(x => x.Description).MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Description))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả", 1000));
        RuleFor(x => x.AffectedCrops).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.AffectedCrops))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Cây bị ảnh hưởng", 500));
        RuleFor(x => x.DamageSymptoms).MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.DamageSymptoms))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Triệu chứng gây hại", 1000));
        RuleFor(x => x.LifeCycle).MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.LifeCycle))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Vòng đời", 1000));
        RuleFor(x => x.PreventionMethods).MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.PreventionMethods))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Biện pháp phòng ngừa", 1000));
        RuleFor(x => x.RecommendedPesticides).MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.RecommendedPesticides))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Thuốc BVTV khuyến nghị", 1000));
        RuleFor(x => x.BiologicalControl).MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.BiologicalControl))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Biện pháp sinh học", 1000));
        RuleFor(x => x.ImageUrl).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.ImageUrl))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đường dẫn ảnh", 500));
    }
}