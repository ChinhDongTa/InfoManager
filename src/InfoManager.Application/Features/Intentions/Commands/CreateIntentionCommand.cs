using InfoManager.Domain.Entities.Personal;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoManager.Application.Features.Intentions.Commands;
public record CreateIntentionCommand : IRequest<Result<string>>
{
    public required string Content { get; init; }
    public string? Description { get; init; }
    public DateTimeOffset? PlannDate { get; init; }
    public bool IsCompleted { get; init; } = false;
    public Priority Priority { get; init; } = Priority.Medium;
    public string? CategoryId { get; init; }
}
public class CreateIntentionCommandHandler : BaseCreateCommandHandler<CreateIntentionCommand, Intention>
{
    public CreateIntentionCommandHandler(IApplicationDbContext context,
                                          IValidator<CreateIntentionCommand> validator,
                                          ILogger<CreateIntentionCommandHandler> logger) : base(context, validator, logger)
    {
    }
    protected override async Task<Intention> CreateEntity(CreateIntentionCommand request)
    {
        return new Intention
        {
            Content = request.Content.Trim(),
            Description = request.Description?.Trim(),
            PlannDate = request.PlannDate,
            IsCompleted = request.IsCompleted,
            Priority = request.Priority,
            CategoryId = request.CategoryId
        };
    }
    protected override async Task AddEntityAsync(Intention entity, CancellationToken cancellationToken)
    {
        await Context.Intentions.AddAsync(entity, cancellationToken);
    }
}
public class CreateIntentionCommandValidator : AbstractValidator<CreateIntentionCommand>
{
    public CreateIntentionCommandValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Nội dung ý định"));
    }
}   