namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record CreateWorkShiftCommand : IRequest<Result<string>>
{
    public required string Name { get; init; }
    public required TimeOnly StartTime { get; init; }
    public required TimeOnly EndTime { get; init; }
    public required string FarmId { get; init; }
}

public class CreateWorkShiftCommandHandler : BaseCreateCommandHandler<CreateWorkShiftCommand, WorkShift>
{
    public CreateWorkShiftCommandHandler(IApplicationDbContext context,
                                         IValidator<CreateWorkShiftCommand> validator,
                                         ILogger<CreateWorkShiftCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(WorkShift entity, CancellationToken ct)
        => await Context.WorkShifts.AddAsync(entity, ct);

    protected override Task<WorkShift> CreateEntity(CreateWorkShiftCommand request)
        => Task.FromResult(new WorkShift
        {
            Name = request.Name,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            FarmId = request.FarmId
        });
}

public class CreateWorkShiftCommandValidator : AbstractValidator<CreateWorkShiftCommand>
{
    public CreateWorkShiftCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên ca"))
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên ca", 50));
        RuleFor(x => x.FarmId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));
    }
}