namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record UpdateLeaveRequestCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? LeaveType { get; init; }
    public DateOnly? FromDate { get; init; }
    public DateOnly? ToDate { get; init; }
    public string? Reason { get; init; }
    public string? Status { get; init; }
    public string? ApprovedBy { get; init; }
}

public class UpdateLeaveRequestCommandHandler : BaseUpdateCommandHandler<UpdateLeaveRequestCommand, LeaveRequest>
{
    public UpdateLeaveRequestCommandHandler(IApplicationDbContext context,
                                            IValidator<UpdateLeaveRequestCommand> validator,
                                            ILogger<UpdateLeaveRequestCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<LeaveRequest?> GetEntityAsync(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        => await Context.LeaveRequests.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(LeaveRequest entity, UpdateLeaveRequestCommand request)
    {
        if (request.LeaveType.HasValueAndIsDifferentFrom(entity.LeaveType))
            entity.LeaveType = request.LeaveType!;
        if (request.FromDate.HasValueAndIsDifferentFrom(entity.FromDate))
            entity.FromDate = request.FromDate!.Value;
        if (request.ToDate.HasValueAndIsDifferentFrom(entity.ToDate))
            entity.ToDate = request.ToDate!.Value;
        if (request.Reason.IsDifferentFrom(entity.Reason))
            entity.Reason = request.Reason;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
        {
            entity.Status = request.Status!;
            if (string.Equals(request.Status, "Approved", StringComparison.OrdinalIgnoreCase)
                && entity.ApprovedAt == null)
                entity.ApprovedAt = DateTimeOffset.UtcNow;
        }
        if (request.ApprovedBy.IsDifferentFrom(entity.ApprovedBy))
            entity.ApprovedBy = request.ApprovedBy;
        return Task.CompletedTask;
    }
}

public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
{
    public UpdateLeaveRequestCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID đơn nghỉ"));
        RuleFor(x => x.LeaveType)
            .NotEmpty().When(x => x.LeaveType != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Loại nghỉ"))
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.LeaveType))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Loại nghỉ", 50));
        RuleFor(x => x.ToDate)
            .GreaterThanOrEqualTo(x => x.FromDate)
            .When(x => x.FromDate.HasValue && x.ToDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày kết thúc phải ≥ ngày bắt đầu"));
        RuleFor(x => x.Reason)
            .MaximumLength(500).When(x => x.Reason != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Lý do", 500));
        RuleFor(x => x.Status)
            .MaximumLength(20).When(x => x.Status != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Trạng thái", 20));
    }
}