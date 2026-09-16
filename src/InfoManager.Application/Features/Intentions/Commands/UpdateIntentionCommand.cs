namespace InfoManager.Application.Features.Intentions.Commands;

public record UpdateIntentionCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? Content { get; init; }
    public string? Description { get; init; }
    public DateTimeOffset? PlannDate { get; init; }
    public bool? IsCompleted { get; init; }
    public Priority? Priority { get; init; }
    public string? CategoryId { get; init; }
}

public class UpdateIntentionCommandHandler : BaseUpdateCommandHandler<UpdateIntentionCommand, Intention>
{
    public UpdateIntentionCommandHandler(IApplicationDbContext context,
                                          IValidator<UpdateIntentionCommand> validator,
                                          ILogger<UpdateIntentionCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task<Intention?> GetEntityAsync(UpdateIntentionCommand request, CancellationToken ct)
    {
        return await Context.Intentions.FindAsync([request.Id], ct);
    }

    protected override async Task UpdateEntityProperties(Intention entity, UpdateIntentionCommand request)
    {
        if (request.Content.HasValueAndIsDifferentFrom(entity.Content))
            entity.Content = request.Content!;

        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description;

        if (request.PlannDate.IsDifferentFrom(entity.PlannDate))
            entity.PlannDate = request.PlannDate;

        if (request.IsCompleted.HasValueAndIsDifferentFrom(entity.IsCompleted))
            entity.IsCompleted = request.IsCompleted!.Value;

        if (request.Priority.HasValueAndIsDifferentFrom(entity.Priority))
            entity.Priority = request.Priority!.Value;

        if (request.CategoryId.IsDifferentFrom(entity.CategoryId))
            entity.CategoryId = request.CategoryId;
    }
}

public class UpdateIntentionCommandValidator : AbstractValidator<UpdateIntentionCommand>
{
    public UpdateIntentionCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));
    }
}