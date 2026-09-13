namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record CreateJobAssignmentCommand : IRequest<Result<string>>
{
    public required string HREmployeeId { get; init; }
    public required string JobPositionId { get; init; }
    public required DateTimeOffset StartDate { get; init; }
    public DateTimeOffset? EndDate { get; init; }
    public required AssignmentStatus Status { get; init; }
    public decimal? AssignedSalary { get; init; }
    public string? AssignedFieldId { get; init; }
    public string? SupervisorId { get; init; }
    public string? PerformanceNotes { get; init; }
    public string? AssignmentReason { get; init; }
}

public class CreateJobAssignmentCommandHandler : BaseCreateCommandHandler<CreateJobAssignmentCommand, JobAssignment>
{
    public CreateJobAssignmentCommandHandler(IApplicationDbContext context,
                                             IValidator<CreateJobAssignmentCommand> validator,
                                             ILogger<CreateJobAssignmentCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(JobAssignment entity, CancellationToken cancellationToken)
        => await Context.JobAssignments.AddAsync(entity, cancellationToken);

    protected override Task<JobAssignment> CreateEntity(CreateJobAssignmentCommand request)
        => Task.FromResult(new JobAssignment
        {
            HREmployeeId = request.HREmployeeId,
            JobPositionId = request.JobPositionId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Status = request.Status,
            AssignedSalary = request.AssignedSalary,
            AssignedFieldId = request.AssignedFieldId,
            SupervisorId = request.SupervisorId,
            PerformanceNotes = request.PerformanceNotes,
            AssignmentReason = request.AssignmentReason
        });
}

public class CreateJobAssignmentCommandValidator : AbstractValidator<CreateJobAssignmentCommand>
{
    public CreateJobAssignmentCommandValidator()
    {
        RuleFor(x => x.HREmployeeId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nhân viên"));
        RuleFor(x => x.JobPositionId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID vị trí"));
        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(x => x.StartDate)
            .When(x => x.EndDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày kết thúc phải ≥ ngày bắt đầu"));
        RuleFor(x => x.AssignedSalary)
            .GreaterThanOrEqualTo(0).When(x => x.AssignedSalary.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Lương gán", 0));
        RuleFor(x => x.SupervisorId)
            .NotEqual(x => x.HREmployeeId).When(x => !string.IsNullOrEmpty(x.SupervisorId))
            .WithMessage(ErrorHelpers.GetErrorCustom("Người giám sát không được trùng nhân viên được phân công"));
        RuleFor(x => x.PerformanceNotes)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.PerformanceNotes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú hiệu suất", 500));
        RuleFor(x => x.AssignmentReason)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.AssignmentReason))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Lý do phân công", 500));
    }
}