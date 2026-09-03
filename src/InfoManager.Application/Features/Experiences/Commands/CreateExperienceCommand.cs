namespace InfoManager.Application.Features.Experiences.Commands;
public record CreateExperienceCommand : IRequest<Result<string>>
{
   public required string Content { get; init; } 
    public string? Description { get; init; }
    public DateOnly? ExperienceDate { get; init; }
    public string? CategoryId { get; init; }
}

public class CreateExperienceCommandHandler : BaseCreateCommandHandler<CreateExperienceCommand, Experience>
{
    public CreateExperienceCommandHandler(IApplicationDbContext context,
                                          IValidator<CreateExperienceCommand> validator,
                                          ILogger<CreateExperienceCommandHandler> logger)
        : base(context, validator, logger)
    {
        
    }

    protected override async Task AddEntityAsync(Experience entity, CancellationToken cancellationToken)
    {
        await Context.Experiences.AddAsync(entity, cancellationToken);
    }

    protected override async Task<Experience> CreateEntity(CreateExperienceCommand request)
    {
        return new Experience
        {
            Content = request.Content.Trim(),
            Description = request.Description?.Trim(),
            ExperienceDate = request.ExperienceDate,
            CategoryId = request.CategoryId
        };
    }
}
public class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
{
    public CreateExperienceCommandValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Content"))
            .MaximumLength(5000).WithMessage(ErrorHelpers.GetErrorMaxLength("Content", 5000));
    }
}