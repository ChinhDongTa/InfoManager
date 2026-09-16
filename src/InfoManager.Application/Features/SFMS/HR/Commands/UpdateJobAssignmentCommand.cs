namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record UpdateJobAssignmentCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public DateTimeOffset? EndDate { get; init; }
    public AssignmentStatus? Status { get; init; }
    public decimal? AssignedSalary { get; init; }
    public string? AssignedFieldId { get; init; }
    public string? SupervisorId { get; init; }
    public string? PerformanceNotes { get; init; }
    public string? AssignmentReason { get; init; }
}

public class UpdateJobAssignmentCommandHandler : BaseUpdateCommandHandler<UpdateJobAssignmentCommand, JobAssignment>
{
    public UpdateJobAssignmentCommandHandler(IApplicationDbContext context,
                                             IValidator<UpdateJobAssignmentCommand> validator,
                                             ILogger<UpdateJobAssignmentCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<JobAssignment?> GetEntityAsync(UpdateJobAssignmentCommand request, CancellationToken ct)
        => await Context.JobAssignments.FindAsync([request.Id], ct);

    protected override Task UpdateEntityProperties(JobAssignment entity, UpdateJobAssignmentCommand request)
    {
        if (request.EndDate.IsDifferentFrom(entity.EndDate))
            entity.EndDate = request.EndDate;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
        if (request.AssignedSalary.IsDifferentFrom(entity.AssignedSalary))
            entity.AssignedSalary = request.AssignedSalary;
        if (request.AssignedFieldId.IsDifferentFrom(entity.AssignedFieldId))
            entity.AssignedFieldId = request.AssignedFieldId;
        if (request.SupervisorId.IsDifferentFrom(entity.SupervisorId))
            entity.SupervisorId = request.SupervisorId;
        if (request.PerformanceNotes.IsDifferentFrom(entity.PerformanceNotes))
            entity.PerformanceNotes = request.PerformanceNotes;
        if (request.AssignmentReason.IsDifferentFrom(entity.AssignmentReason))
            entity.AssignmentReason = request.AssignmentReason;
        return Task.CompletedTask;
    }
}

public class UpdateJobAssignmentCommandValidator : AbstractValidator<UpdateJobAssignmentCommand>
{
    public UpdateJobAssignmentCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID phân công"));
        RuleFor(x => x.AssignedSalary)
            .GreaterThanOrEqualTo(0).When(x => x.AssignedSalary.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Lương gán", 0));
        RuleFor(x => x.PerformanceNotes)
            .MaximumLength(500).When(x => x.PerformanceNotes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú hiệu suất", 500));
        RuleFor(x => x.AssignmentReason)
            .MaximumLength(500).When(x => x.AssignmentReason != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Lý do phân công", 500));
    }
}