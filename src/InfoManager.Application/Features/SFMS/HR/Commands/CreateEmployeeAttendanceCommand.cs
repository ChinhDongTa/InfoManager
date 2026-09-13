namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record CreateEmployeeAttendanceCommand : IRequest<Result<string>>
{
    public required string HREmployeeId { get; init; }
    public required DateOnly AttendanceDate { get; init; }
    public TimeOnly? CheckInTime { get; init; }
    public TimeOnly? CheckOutTime { get; init; }
    public string? WorkShiftId { get; init; }
    public required AttendanceStatus Status { get; init; }
    public string? Reason { get; init; }
    public decimal? HoursWorked { get; init; }
    public decimal? OvertimeHours { get; init; }
    public string? Notes { get; init; }
}

public class CreateEmployeeAttendanceCommandHandler : BaseCreateCommandHandler<CreateEmployeeAttendanceCommand, EmployeeAttendance>
{
    public CreateEmployeeAttendanceCommandHandler(IApplicationDbContext context,
                                                  IValidator<CreateEmployeeAttendanceCommand> validator,
                                                  ILogger<CreateEmployeeAttendanceCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(EmployeeAttendance entity, CancellationToken cancellationToken)
        => await Context.EmployeeAttendances.AddAsync(entity, cancellationToken);

    protected override Task<EmployeeAttendance> CreateEntity(CreateEmployeeAttendanceCommand request)
        => Task.FromResult(new EmployeeAttendance
        {
            HREmployeeId = request.HREmployeeId,
            AttendanceDate = request.AttendanceDate,
            CheckInTime = request.CheckInTime,
            CheckOutTime = request.CheckOutTime,
            WorkShiftId = request.WorkShiftId,
            Status = request.Status,
            Reason = request.Reason,
            HoursWorked = request.HoursWorked,
            OvertimeHours = request.OvertimeHours,
            Notes = request.Notes
        });
}

public class CreateEmployeeAttendanceCommandValidator : AbstractValidator<CreateEmployeeAttendanceCommand>
{
    public CreateEmployeeAttendanceCommandValidator()
    {
        RuleFor(x => x.HREmployeeId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nhân viên"));
        RuleFor(x => x.CheckOutTime)
            .GreaterThan(x => x.CheckInTime)
            .When(x => x.CheckInTime.HasValue && x.CheckOutTime.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Giờ ra phải sau giờ vào"));
        RuleFor(x => x.HoursWorked)
            .GreaterThanOrEqualTo(0).When(x => x.HoursWorked.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số giờ làm", 0));
        RuleFor(x => x.OvertimeHours)
            .GreaterThanOrEqualTo(0).When(x => x.OvertimeHours.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Giờ làm thêm", 0));
        RuleFor(x => x.Reason)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Reason))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Lý do", 500));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}