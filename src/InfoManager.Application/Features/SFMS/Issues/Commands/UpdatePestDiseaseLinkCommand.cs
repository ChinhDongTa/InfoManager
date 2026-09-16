namespace InfoManager.Application.Features.SFMS.Issues.Commands;

public record UpdatePestDiseaseLinkCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? PestId { get; init; }
    public string? DiseaseId { get; init; }
    public string? RelationshipDescription { get; init; }
}

public class UpdatePestDiseaseLinkCommandHandler : BaseUpdateCommandHandler<UpdatePestDiseaseLinkCommand, PestDiseaseLink>
{
    public UpdatePestDiseaseLinkCommandHandler(IApplicationDbContext context,
                                               IValidator<UpdatePestDiseaseLinkCommand> validator,
                                               ILogger<UpdatePestDiseaseLinkCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<PestDiseaseLink?> GetEntityAsync(UpdatePestDiseaseLinkCommand request, CancellationToken cancellationToken)
        => await Context.PestDiseaseLinks.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(PestDiseaseLink entity, UpdatePestDiseaseLinkCommand request)
    {
        if (request.PestId.HasValueAndIsDifferentFrom(entity.PestId))
            entity.PestId = request.PestId!;
        if (request.DiseaseId.HasValueAndIsDifferentFrom(entity.DiseaseId))
            entity.DiseaseId = request.DiseaseId!;
        if (request.RelationshipDescription.IsDifferentFrom(entity.RelationshipDescription))
            entity.RelationshipDescription = request.RelationshipDescription;
        return Task.CompletedTask;
    }
}

public class UpdatePestDiseaseLinkCommandValidator : AbstractValidator<UpdatePestDiseaseLinkCommand>
{
    public UpdatePestDiseaseLinkCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID liên kết"));
        RuleFor(x => x.PestId)
            .NotEmpty().When(x => x.PestId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID sâu hại"));
        RuleFor(x => x.DiseaseId)
            .NotEmpty().When(x => x.DiseaseId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID bệnh"));
        RuleFor(x => x.RelationshipDescription)
            .MaximumLength(500).When(x => x.RelationshipDescription != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả quan hệ", 500));
    }
}