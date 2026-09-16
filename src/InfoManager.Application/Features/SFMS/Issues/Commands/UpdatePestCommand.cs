namespace InfoManager.Application.Features.SFMS.Issues.Commands;

public record UpdatePestCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? CommonName { get; init; }
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

public class UpdatePestCommandHandler : BaseUpdateCommandHandler<UpdatePestCommand, Pest>
{
    public UpdatePestCommandHandler(IApplicationDbContext context,
                                    IValidator<UpdatePestCommand> validator,
                                    ILogger<UpdatePestCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<Pest?> GetEntityAsync(UpdatePestCommand request, CancellationToken ct)
        => await Context.Pests.FindAsync([request.Id], ct);

    protected override Task UpdateEntityProperties(Pest entity, UpdatePestCommand request)
    {
        if (request.CommonName.HasValueAndIsDifferentFrom(entity.CommonName))
            entity.CommonName = request.CommonName!;
        if (request.ScientificName.IsDifferentFrom(entity.ScientificName))
            entity.ScientificName = request.ScientificName;
        if (request.PestType.IsDifferentFrom(entity.PestType))
            entity.PestType = request.PestType;
        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description;
        if (request.AffectedCrops.IsDifferentFrom(entity.AffectedCrops))
            entity.AffectedCrops = request.AffectedCrops;
        if (request.DamageSymptoms.IsDifferentFrom(entity.DamageSymptoms))
            entity.DamageSymptoms = request.DamageSymptoms;
        if (request.LifeCycle.IsDifferentFrom(entity.LifeCycle))
            entity.LifeCycle = request.LifeCycle;
        if (request.PreventionMethods.IsDifferentFrom(entity.PreventionMethods))
            entity.PreventionMethods = request.PreventionMethods;
        if (request.RecommendedPesticides.IsDifferentFrom(entity.RecommendedPesticides))
            entity.RecommendedPesticides = request.RecommendedPesticides;
        if (request.BiologicalControl.IsDifferentFrom(entity.BiologicalControl))
            entity.BiologicalControl = request.BiologicalControl;
        if (request.SeverityLevel.IsDifferentFrom(entity.SeverityLevel))
            entity.SeverityLevel = request.SeverityLevel;
        if (request.ImageUrl.IsDifferentFrom(entity.ImageUrl))
            entity.ImageUrl = request.ImageUrl;
        return Task.CompletedTask;
    }
}

public class UpdatePestCommandValidator : AbstractValidator<UpdatePestCommand>
{
    public UpdatePestCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID sâu hại"));
        RuleFor(x => x.CommonName)
            .NotEmpty().When(x => x.CommonName != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Tên thông thường"))
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.CommonName))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên thông thường", 100));
        RuleFor(x => x.ScientificName).MaximumLength(200).When(x => x.ScientificName != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên khoa học", 200));
        RuleFor(x => x.PestType).MaximumLength(50).When(x => x.PestType != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Loại sâu hại", 50));
        RuleFor(x => x.Description).MaximumLength(1000).When(x => x.Description != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả", 1000));
        RuleFor(x => x.AffectedCrops).MaximumLength(500).When(x => x.AffectedCrops != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Cây bị ảnh hưởng", 500));
        RuleFor(x => x.DamageSymptoms).MaximumLength(1000).When(x => x.DamageSymptoms != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Triệu chứng gây hại", 1000));
        RuleFor(x => x.LifeCycle).MaximumLength(1000).When(x => x.LifeCycle != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Vòng đời", 1000));
        RuleFor(x => x.PreventionMethods).MaximumLength(1000).When(x => x.PreventionMethods != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Biện pháp phòng ngừa", 1000));
        RuleFor(x => x.RecommendedPesticides).MaximumLength(1000).When(x => x.RecommendedPesticides != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Thuốc BVTV khuyến nghị", 1000));
        RuleFor(x => x.BiologicalControl).MaximumLength(1000).When(x => x.BiologicalControl != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Biện pháp sinh học", 1000));
        RuleFor(x => x.ImageUrl).MaximumLength(500).When(x => x.ImageUrl != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đường dẫn ảnh", 500));
    }
}