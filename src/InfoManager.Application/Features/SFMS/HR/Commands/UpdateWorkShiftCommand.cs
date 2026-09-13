namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record UpdateWorkShiftCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? Name { get; init; }
    public TimeOnly? StartTime { get; init; }
    public TimeOnly? EndTime { get; init; }
}
public class UpdateWorkShiftCommandHandler : BaseUpdateCommandHandler<UpdateWorkShiftCommand, WorkShift>
{
    public UpdateWorkShiftCommandHandler(IApplicationDbContext context,
                                         IValidator<UpdateWorkShiftCommand> validator,
                                         ILogger<UpdateWorkShiftCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<WorkShift?> GetEntityAsync(UpdateWorkShiftCommand request, CancellationToken cancellationToken)
        => await Context.WorkShifts.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(WorkShift entity, UpdateWorkShiftCommand request)
    {
        if (request.Name.HasValueAndIsDifferentFrom(entity.Name))
            entity.Name = request.Name!;
        if (request.StartTime.HasValueAndIsDifferentFrom(entity.StartTime))
            entity.StartTime = request.StartTime!.Value;
        if (request.EndTime.HasValueAndIsDifferentFrom(entity.EndTime))
            entity.EndTime = request.EndTime!.Value;
        return Task.CompletedTask;
    }
}

public class UpdateWorkShiftCommandValidator : AbstractValidator<UpdateWorkShiftCommand>
{
    public UpdateWorkShiftCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID ca làm việc"));
        RuleFor(x => x.Name)
            .NotEmpty().When(x => x.Name != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Tên ca"))
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.Name))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên ca", 50));
    }
}