namespace InfoManager.Application.Features.Experiences.Commands;
public record UpdateExperienceCommand() : IRequest<Result>
{
    public required string Id { get; init; }
    public string? Content { get; init; }
    public string? Description { get; init; }
    public DateOnly? ExperienceDate { get; init; }
    public string? CategoryId { get; init; }
}
public class UpdateExperienceCommandHandler : BaseUpdateCommandHandler<UpdateExperienceCommand, Experience>
{
    public UpdateExperienceCommandHandler(IApplicationDbContext context,
                                          IValidator<UpdateExperienceCommand> validator,
                                          ILogger<UpdateExperienceCommandHandler> logger)
        : base(context, validator, logger)
    {
    }
    protected override async Task<Experience?> GetEntityAsync(UpdateExperienceCommand request, CancellationToken cancellationToken)
    {
        return await Context.Experiences.FindAsync([request.Id], cancellationToken);
    }

    protected override void UpdateEntityProperties(Experience entity, UpdateExperienceCommand request)
    {
        if (request.Content.HasValueAndIsDifferentFrom(entity.Content))
            entity.Content = request.Content!;

        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description;

        if (request.CategoryId.IsDifferentFrom(entity.CategoryId))
            entity.CategoryId = request.CategoryId;

        if (request.ExperienceDate.IsDifferentFrom(entity.ExperienceDate))
            entity.ExperienceDate = request.ExperienceDate;
    }
}
public class UpdateExperienceCommandValidator : AbstractValidator<UpdateExperienceCommand>
{
    public UpdateExperienceCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));
        //RuleFor(x => x)
        //    .Must(x => HasAtLeastOneFieldToUpdate(x))
            //.WithMessage("At least one field (Content, Description, ExperienceDate, or CategoryId) must be provided for update.");
        RuleFor(x => x.Content)
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("Content", 500))
            .When(x => !string.IsNullOrEmpty(x.Content));
    }

    //public bool HasAtLeastOneFieldToUpdate(UpdateExperienceCommand command)
    //{
    //    return command.Content is not null ||
    //           command.Description is not null ||
    //           command.ExperienceDate.HasValue ||
    //           command.CategoryId is not null;
    //}
}