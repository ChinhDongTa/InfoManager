namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record CreateLeaveRequestCommand : IRequest<Result<string>>
{
    public required string HREmployeeId { get; init; }
    public required string LeaveType { get; init; }
    public required DateOnly FromDate { get; init; }
    public required DateOnly ToDate { get; init; }
    public string? Reason { get; init; }
}

public class CreateLeaveRequestCommandHandler : BaseCreateCommandHandler<CreateLeaveRequestCommand, LeaveRequest>
{
    public CreateLeaveRequestCommandHandler(IApplicationDbContext context,
                                            IValidator<CreateLeaveRequestCommand> validator,
                                            ILogger<CreateLeaveRequestCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(LeaveRequest entity, CancellationToken ct)
        => await Context.LeaveRequests.AddAsync(entity, ct);

    protected override Task<LeaveRequest> CreateEntity(CreateLeaveRequestCommand request)
        => Task.FromResult(new LeaveRequest
        {
            HREmployeeId = request.HREmployeeId,
            LeaveType = request.LeaveType,
            FromDate = request.FromDate,
            ToDate = request.ToDate,
            Reason = request.Reason
        });
}

public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
{
    public CreateLeaveRequestCommandValidator()
    {
        RuleFor(x => x.HREmployeeId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nhân viên"));
        RuleFor(x => x.LeaveType)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Loại nghỉ"))
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Loại nghỉ", 50));
        RuleFor(x => x.ToDate)
            .GreaterThanOrEqualTo(x => x.FromDate)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày kết thúc phải ≥ ngày bắt đầu"));
        RuleFor(x => x.Reason)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Reason))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Lý do", 500));
    }
}