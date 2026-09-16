public record CreateHREmployeeCommand : IRequest<Result<string>>
{
    public string? FamilyMemberId { get; init; }
    public required string FarmId { get; init; }
    public required string UserId { get; init; }
    public string? DepartmentId { get; init; }
    public string? EmployeeNumber { get; init; }
    public required EmploymentStatus Status { get; init; }
    public DateTimeOffset? HireDate { get; init; }
    public required decimal Salary { get; init; }
    public required SalaryType SalaryType { get; init; }
    public string? BankAccount { get; init; }
    public string? EmergencyContactName { get; init; }
    public string? EmergencyContactPhone { get; init; }
    public string? Notes { get; init; }
}

public class CreateHREmployeeCommandHandler : BaseCreateCommandHandler<CreateHREmployeeCommand, HREmployee>
{
    public CreateHREmployeeCommandHandler(IApplicationDbContext context,
                                          IValidator<CreateHREmployeeCommand> validator,
                                          ILogger<CreateHREmployeeCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(HREmployee entity, CancellationToken ct)
        => await Context.HREmployees.AddAsync(entity, ct);

    protected override Task<HREmployee> CreateEntity(CreateHREmployeeCommand request)
        => Task.FromResult(new HREmployee
        {
            FamilyMemberId = request.FamilyMemberId,
            FarmId = request.FarmId,
            UserId = request.UserId,
            DepartmentId = request.DepartmentId,
            EmployeeNumber = request.EmployeeNumber,
            Status = request.Status,
            HireDate = request.HireDate,
            Salary = request.Salary,
            SalaryType = request.SalaryType,
            BankAccount = request.BankAccount,
            EmergencyContactName = request.EmergencyContactName,
            EmergencyContactPhone = request.EmergencyContactPhone,
            Notes = request.Notes
        });
}

public class CreateHREmployeeCommandValidator : AbstractValidator<CreateHREmployeeCommand>
{
    public CreateHREmployeeCommandValidator()
    {
        RuleFor(x => x.FarmId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));
        RuleFor(x => x.UserId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID người dùng"));
        RuleFor(x => x.EmployeeNumber)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.EmployeeNumber))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mã nhân viên", 50));
        RuleFor(x => x.Salary).GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Lương", 0));
        RuleFor(x => x.BankAccount)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.BankAccount))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số tài khoản", 50));
        RuleFor(x => x.EmergencyContactName)
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.EmergencyContactName))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người liên hệ khẩn cấp", 200));
        RuleFor(x => x.EmergencyContactPhone)
            .MaximumLength(20).When(x => !string.IsNullOrEmpty(x.EmergencyContactPhone))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("SĐT khẩn cấp", 20));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}