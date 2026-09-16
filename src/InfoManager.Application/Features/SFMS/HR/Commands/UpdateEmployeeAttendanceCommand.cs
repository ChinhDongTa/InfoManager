namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record UpdateEmployeeAttendanceCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public TimeOnly? CheckInTime { get; init; }
    public TimeOnly? CheckOutTime { get; init; }
    public string? WorkShiftId { get; init; }
    public AttendanceStatus? Status { get; init; }
    public string? Reason { get; init; }
    public decimal? HoursWorked { get; init; }
    public decimal? OvertimeHours { get; init; }
    public string? Notes { get; init; }
}

public class UpdateEmployeeAttendanceCommandHandler : BaseUpdateCommandHandler<UpdateEmployeeAttendanceCommand, EmployeeAttendance>
{
    public UpdateEmployeeAttendanceCommandHandler(IApplicationDbContext context,
                                                  IValidator<UpdateEmployeeAttendanceCommand> validator,
                                                  ILogger<UpdateEmployeeAttendanceCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<EmployeeAttendance?> GetEntityAsync(UpdateEmployeeAttendanceCommand request, CancellationToken ct)
        => await Context.EmployeeAttendances.FindAsync([request.Id], ct);

    protected override Task UpdateEntityProperties(EmployeeAttendance entity, UpdateEmployeeAttendanceCommand request)
    {
        if (request.CheckInTime.IsDifferentFrom(entity.CheckInTime))
            entity.CheckInTime = request.CheckInTime;
        if (request.CheckOutTime.IsDifferentFrom(entity.CheckOutTime))
            entity.CheckOutTime = request.CheckOutTime;
        if (request.WorkShiftId.IsDifferentFrom(entity.WorkShiftId))
            entity.WorkShiftId = request.WorkShiftId;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
        if (request.Reason.IsDifferentFrom(entity.Reason))
            entity.Reason = request.Reason;
        if (request.HoursWorked.IsDifferentFrom(entity.HoursWorked))
            entity.HoursWorked = request.HoursWorked;
        if (request.OvertimeHours.IsDifferentFrom(entity.OvertimeHours))
            entity.OvertimeHours = request.OvertimeHours;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
        return Task.CompletedTask;
    }
}

public class UpdateEmployeeAttendanceCommandValidator : AbstractValidator<UpdateEmployeeAttendanceCommand>
{
    public UpdateEmployeeAttendanceCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID chấm công"));
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
            .MaximumLength(500).When(x => x.Reason != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Lý do", 500));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}