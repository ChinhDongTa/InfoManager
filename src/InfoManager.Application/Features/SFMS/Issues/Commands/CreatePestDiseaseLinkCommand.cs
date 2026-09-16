namespace InfoManager.Application.Features.SFMS.Issues.Commands;

public record CreatePestDiseaseLinkCommand : IRequest<Result<string>>
{
    public required string PestId { get; init; }
    public required string DiseaseId { get; init; }
    public string? RelationshipDescription { get; init; }
}

public class CreatePestDiseaseLinkCommandHandler : BaseCreateCommandHandler<CreatePestDiseaseLinkCommand, PestDiseaseLink>
{
    public CreatePestDiseaseLinkCommandHandler(IApplicationDbContext context,
                                               IValidator<CreatePestDiseaseLinkCommand> validator,
                                               ILogger<CreatePestDiseaseLinkCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(PestDiseaseLink entity, CancellationToken ct)
        => await Context.PestDiseaseLinks.AddAsync(entity, ct);

    protected override Task<PestDiseaseLink> CreateEntity(CreatePestDiseaseLinkCommand request)
        => Task.FromResult(new PestDiseaseLink
        {
            PestId = request.PestId,
            DiseaseId = request.DiseaseId,
            RelationshipDescription = request.RelationshipDescription
        });
}

public class CreatePestDiseaseLinkCommandValidator : AbstractValidator<CreatePestDiseaseLinkCommand>
{
    public CreatePestDiseaseLinkCommandValidator()
    {
        RuleFor(x => x.PestId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID sâu hại"));
        RuleFor(x => x.DiseaseId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID bệnh"));
        RuleFor(x => x.RelationshipDescription)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.RelationshipDescription))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả quan hệ", 500));
    }
}