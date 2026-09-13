namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record UpdateHREmployeeCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? FamilyMemberId { get; init; }
    public string? DepartmentId { get; init; }
    public string? EmployeeNumber { get; init; }
    public EmploymentStatus? Status { get; init; }
    public DateTimeOffset? HireDate { get; init; }
    public DateTimeOffset? TerminationDate { get; init; }
    public string? TerminationReason { get; init; }
    public decimal? Salary { get; init; }
    public SalaryType? SalaryType { get; init; }
    public string? BankAccount { get; init; }
    public string? EmergencyContactName { get; init; }
    public string? EmergencyContactPhone { get; init; }
    public string? Notes { get; init; }
}

public class UpdateHREmployeeCommandHandler : BaseUpdateCommandHandler<UpdateHREmployeeCommand, HREmployee>
{
    public UpdateHREmployeeCommandHandler(IApplicationDbContext context,
                                          IValidator<UpdateHREmployeeCommand> validator,
                                          ILogger<UpdateHREmployeeCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<HREmployee?> GetEntityAsync(UpdateHREmployeeCommand request, CancellationToken cancellationToken)
        => await Context.HREmployees.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(HREmployee entity, UpdateHREmployeeCommand request)
    {
        if (request.FamilyMemberId.IsDifferentFrom(entity.FamilyMemberId))
            entity.FamilyMemberId = request.FamilyMemberId;
        if (request.DepartmentId.IsDifferentFrom(entity.DepartmentId))
            entity.DepartmentId = request.DepartmentId;
        if (request.EmployeeNumber.IsDifferentFrom(entity.EmployeeNumber))
            entity.EmployeeNumber = request.EmployeeNumber;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
        if (request.HireDate.IsDifferentFrom(entity.HireDate))
            entity.HireDate = request.HireDate;
        if (request.TerminationDate.IsDifferentFrom(entity.TerminationDate))
            entity.TerminationDate = request.TerminationDate;
        if (request.TerminationReason.IsDifferentFrom(entity.TerminationReason))
            entity.TerminationReason = request.TerminationReason;
        if (request.Salary.HasValueAndIsDifferentFrom(entity.Salary))
            entity.Salary = request.Salary!.Value;
        if (request.SalaryType.HasValueAndIsDifferentFrom(entity.SalaryType))
            entity.SalaryType = request.SalaryType!.Value;
        if (request.BankAccount.IsDifferentFrom(entity.BankAccount))
            entity.BankAccount = request.BankAccount;
        if (request.EmergencyContactName.IsDifferentFrom(entity.EmergencyContactName))
            entity.EmergencyContactName = request.EmergencyContactName;
        if (request.EmergencyContactPhone.IsDifferentFrom(entity.EmergencyContactPhone))
            entity.EmergencyContactPhone = request.EmergencyContactPhone;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
        return Task.CompletedTask;
    }
}

public class UpdateHREmployeeCommandValidator : AbstractValidator<UpdateHREmployeeCommand>
{
    public UpdateHREmployeeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nhân viên"));
        RuleFor(x => x.EmployeeNumber)
            .MaximumLength(50).When(x => x.EmployeeNumber != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mã nhân viên", 50));
        RuleFor(x => x.Salary)
            .GreaterThanOrEqualTo(0).When(x => x.Salary.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Lương", 0));
        RuleFor(x => x.TerminationDate)
            .GreaterThanOrEqualTo(x => x.HireDate)
            .When(x => x.HireDate.HasValue && x.TerminationDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày nghỉ việc phải ≥ ngày tuyển dụng"));
        RuleFor(x => x.TerminationReason)
            .MaximumLength(500).When(x => x.TerminationReason != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Lý do nghỉ việc", 500));
        RuleFor(x => x.BankAccount)
            .MaximumLength(50).When(x => x.BankAccount != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số tài khoản", 50));
        RuleFor(x => x.EmergencyContactName)
            .MaximumLength(200).When(x => x.EmergencyContactName != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người liên hệ khẩn cấp", 200));
        RuleFor(x => x.EmergencyContactPhone)
            .MaximumLength(20).When(x => x.EmergencyContactPhone != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("SĐT khẩn cấp", 20));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}