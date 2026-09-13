namespace InfoManager.Application.Features.SFMS.HR.Commands;


public record UpdatePayrollCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public decimal? BaseSalary { get; init; }
    public decimal? DaysWorked { get; init; }
    public decimal? OvertimeHours { get; init; }
    public decimal? OvertimeAmount { get; init; }
    public decimal? BonusAmount { get; init; }
    public decimal? Deductions { get; init; }
    public string? DeductionDetails { get; init; }
    public decimal? NetAmount { get; init; }
    public PayrollStatus? PaymentStatus { get; init; }
    public DateTimeOffset? PaymentDate { get; init; }
    public string? PaymentMethod { get; init; }
    public string? ReferenceNumber { get; init; }
    public string? Notes { get; init; }
}

public class UpdatePayrollCommandHandler : BaseUpdateCommandHandler<UpdatePayrollCommand, Payroll>
{
    public UpdatePayrollCommandHandler(IApplicationDbContext context,
                                       IValidator<UpdatePayrollCommand> validator,
                                       ILogger<UpdatePayrollCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<Payroll?> GetEntityAsync(UpdatePayrollCommand request, CancellationToken cancellationToken)
        => await Context.Payrolls.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(Payroll entity, UpdatePayrollCommand request)
    {
        if (request.BaseSalary.HasValueAndIsDifferentFrom(entity.BaseSalary))
            entity.BaseSalary = request.BaseSalary!.Value;
        if (request.DaysWorked.HasValueAndIsDifferentFrom(entity.DaysWorked))
            entity.DaysWorked = request.DaysWorked!.Value;
        if (request.OvertimeHours.IsDifferentFrom(entity.OvertimeHours))
            entity.OvertimeHours = request.OvertimeHours;
        if (request.OvertimeAmount.IsDifferentFrom(entity.OvertimeAmount))
            entity.OvertimeAmount = request.OvertimeAmount;
        if (request.BonusAmount.IsDifferentFrom(entity.BonusAmount))
            entity.BonusAmount = request.BonusAmount;
        if (request.Deductions.IsDifferentFrom(entity.Deductions))
            entity.Deductions = request.Deductions;
        if (request.DeductionDetails.IsDifferentFrom(entity.DeductionDetails))
            entity.DeductionDetails = request.DeductionDetails;
        if (request.NetAmount.HasValueAndIsDifferentFrom(entity.NetAmount))
            entity.NetAmount = request.NetAmount!.Value;
        if (request.PaymentStatus.HasValueAndIsDifferentFrom(entity.PaymentStatus))
            entity.PaymentStatus = request.PaymentStatus!.Value;
        if (request.PaymentDate.IsDifferentFrom(entity.PaymentDate))
            entity.PaymentDate = request.PaymentDate;
        if (request.PaymentMethod.IsDifferentFrom(entity.PaymentMethod))
            entity.PaymentMethod = request.PaymentMethod;
        if (request.ReferenceNumber.IsDifferentFrom(entity.ReferenceNumber))
            entity.ReferenceNumber = request.ReferenceNumber;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
        return Task.CompletedTask;
    }
}

public class UpdatePayrollCommandValidator : AbstractValidator<UpdatePayrollCommand>
{
    public UpdatePayrollCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID bảng lương"));
        RuleFor(x => x.BaseSalary)
            .GreaterThanOrEqualTo(0).When(x => x.BaseSalary.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Lương cơ bản", 0));
        RuleFor(x => x.DaysWorked)
            .GreaterThanOrEqualTo(0).When(x => x.DaysWorked.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số ngày công", 0));
        RuleFor(x => x.OvertimeHours)
            .GreaterThanOrEqualTo(0).When(x => x.OvertimeHours.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Giờ làm thêm", 0));
        RuleFor(x => x.OvertimeAmount)
            .GreaterThanOrEqualTo(0).When(x => x.OvertimeAmount.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Tiền làm thêm", 0));
        RuleFor(x => x.BonusAmount)
            .GreaterThanOrEqualTo(0).When(x => x.BonusAmount.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Thưởng", 0));
        RuleFor(x => x.Deductions)
            .GreaterThanOrEqualTo(0).When(x => x.Deductions.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Khấu trừ", 0));
        RuleFor(x => x.DeductionDetails)
            .MaximumLength(1000).When(x => x.DeductionDetails != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Chi tiết khấu trừ", 1000));
        RuleFor(x => x.PaymentMethod)
            .MaximumLength(50).When(x => x.PaymentMethod != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phương thức thanh toán", 50));
        RuleFor(x => x.ReferenceNumber)
            .MaximumLength(100).When(x => x.ReferenceNumber != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mã tham chiếu", 100));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}