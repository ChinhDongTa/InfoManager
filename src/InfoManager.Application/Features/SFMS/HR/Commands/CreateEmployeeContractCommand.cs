namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record CreateEmployeeContractCommand : IRequest<Result<string>>
{
    public required string HREmployeeId { get; init; }
    public required string ContractNumber { get; init; }
    public required string ContractType { get; init; }
    public required DateTimeOffset StartDate { get; init; }
    public DateTimeOffset? EndDate { get; init; }
    public required SalaryType SalaryType { get; init; }
    public required decimal BaseSalary { get; init; }
    public required bool IsActive { get; init; }
}

public class CreateEmployeeContractCommandHandler : BaseCreateCommandHandler<CreateEmployeeContractCommand, EmployeeContract>
{
    public CreateEmployeeContractCommandHandler(IApplicationDbContext context,
                                                IValidator<CreateEmployeeContractCommand> validator,
                                                ILogger<CreateEmployeeContractCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(EmployeeContract entity, CancellationToken cancellationToken)
        => await Context.EmployeeContracts.AddAsync(entity, cancellationToken);

    protected override Task<EmployeeContract> CreateEntity(CreateEmployeeContractCommand request)
        => Task.FromResult(new EmployeeContract
        {
            HREmployeeId = request.HREmployeeId,
            ContractNumber = request.ContractNumber,
            ContractType = request.ContractType,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            SalaryType = request.SalaryType,
            BaseSalary = request.BaseSalary,
            IsActive = request.IsActive
        });
}

public class CreateEmployeeContractCommandValidator : AbstractValidator<CreateEmployeeContractCommand>
{
    public CreateEmployeeContractCommandValidator()
    {
        RuleFor(x => x.HREmployeeId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nhân viên"));
        RuleFor(x => x.ContractNumber)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Số hợp đồng"))
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Số hợp đồng", 50));
        RuleFor(x => x.ContractType)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Loại hợp đồng"))
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Loại hợp đồng", 50));
        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(x => x.StartDate)
            .When(x => x.EndDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày kết thúc phải ≥ ngày bắt đầu"));
        RuleFor(x => x.BaseSalary).GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Lương hợp đồng", 0));
    }
}