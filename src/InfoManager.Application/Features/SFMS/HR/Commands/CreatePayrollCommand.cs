namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record CreatePayrollCommand : IRequest<Result<string>>
{
    public required string HREmployeeId { get; init; }
    public required DateOnly PeriodStartDate { get; init; }
    public required DateOnly PeriodEndDate { get; init; }
    public required decimal BaseSalary { get; init; }
    public required decimal DaysWorked { get; init; }
    public decimal? OvertimeHours { get; init; }
    public decimal? OvertimeAmount { get; init; }
    public decimal? BonusAmount { get; init; }
    public decimal? Deductions { get; init; }
    public string? DeductionDetails { get; init; }
    public required decimal NetAmount { get; init; }
    public string? PaymentMethod { get; init; }
    public string? Notes { get; init; }
}

public class CreatePayrollCommandHandler : BaseCreateCommandHandler<CreatePayrollCommand, Payroll>
{
    public CreatePayrollCommandHandler(IApplicationDbContext context,
                                       IValidator<CreatePayrollCommand> validator,
                                       ILogger<CreatePayrollCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(Payroll entity, CancellationToken ct)
        => await Context.Payrolls.AddAsync(entity, ct);

    protected override Task<Payroll> CreateEntity(CreatePayrollCommand request)
        => Task.FromResult(new Payroll
        {
            HREmployeeId = request.HREmployeeId,
            PeriodStartDate = request.PeriodStartDate,
            PeriodEndDate = request.PeriodEndDate,
            BaseSalary = request.BaseSalary,
            DaysWorked = request.DaysWorked,
            OvertimeHours = request.OvertimeHours,
            OvertimeAmount = request.OvertimeAmount,
            BonusAmount = request.BonusAmount,
            Deductions = request.Deductions,
            DeductionDetails = request.DeductionDetails,
            NetAmount = request.NetAmount,
            PaymentMethod = request.PaymentMethod,
            Notes = request.Notes
        });
}

public class CreatePayrollCommandValidator : AbstractValidator<CreatePayrollCommand>
{
    public CreatePayrollCommandValidator()
    {
        RuleFor(x => x.HREmployeeId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nhân viên"));
        RuleFor(x => x.PeriodEndDate)
            .GreaterThanOrEqualTo(x => x.PeriodStartDate)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày kết thúc kỳ lương phải ≥ ngày bắt đầu"));
        RuleFor(x => x.BaseSalary).GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Lương cơ bản", 0));
        RuleFor(x => x.DaysWorked).GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Số ngày công", 0));
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
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.DeductionDetails))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Chi tiết khấu trừ", 1000));
        RuleFor(x => x.PaymentMethod)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.PaymentMethod))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phương thức thanh toán", 50));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}