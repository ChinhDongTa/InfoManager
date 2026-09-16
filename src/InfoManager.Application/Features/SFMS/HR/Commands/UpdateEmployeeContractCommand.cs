namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record UpdateEmployeeContractCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? ContractNumber { get; init; }
    public string? ContractType { get; init; }
    public DateTimeOffset? StartDate { get; init; }
    public DateTimeOffset? EndDate { get; init; }
    public SalaryType? SalaryType { get; init; }
    public decimal? BaseSalary { get; init; }
    public bool? IsActive { get; init; }
}

public class UpdateEmployeeContractCommandHandler : BaseUpdateCommandHandler<UpdateEmployeeContractCommand, EmployeeContract>
{
    public UpdateEmployeeContractCommandHandler(IApplicationDbContext context,
                                                IValidator<UpdateEmployeeContractCommand> validator,
                                                ILogger<UpdateEmployeeContractCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<EmployeeContract?> GetEntityAsync(UpdateEmployeeContractCommand request, CancellationToken ct)
        => await Context.EmployeeContracts.FindAsync([request.Id], ct);

    protected override Task UpdateEntityProperties(EmployeeContract entity, UpdateEmployeeContractCommand request)
    {
        if (request.ContractNumber.HasValueAndIsDifferentFrom(entity.ContractNumber))
            entity.ContractNumber = request.ContractNumber!;
        if (request.ContractType.HasValueAndIsDifferentFrom(entity.ContractType))
            entity.ContractType = request.ContractType!;
        if (request.StartDate.HasValueAndIsDifferentFrom(entity.StartDate))
            entity.StartDate = request.StartDate!.Value;
        if (request.EndDate.IsDifferentFrom(entity.EndDate))
            entity.EndDate = request.EndDate;
        if (request.SalaryType.HasValueAndIsDifferentFrom(entity.SalaryType))
            entity.SalaryType = request.SalaryType!.Value;
        if (request.BaseSalary.HasValueAndIsDifferentFrom(entity.BaseSalary))
            entity.BaseSalary = request.BaseSalary!.Value;
        if (request.IsActive.HasValueAndIsDifferentFrom(entity.IsActive))
            entity.IsActive = request.IsActive!.Value;
        return Task.CompletedTask;
    }
}

public class UpdateEmployeeContractCommandValidator : AbstractValidator<UpdateEmployeeContractCommand>
{
    public UpdateEmployeeContractCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID hợp đồng"));
        RuleFor(x => x.ContractNumber)
            .NotEmpty().When(x => x.ContractNumber != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Số hợp đồng"))
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.ContractNumber))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số hợp đồng", 50));
        RuleFor(x => x.ContractType)
            .NotEmpty().When(x => x.ContractType != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Loại hợp đồng"))
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.ContractType))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Loại hợp đồng", 50));
        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(x => x.StartDate)
            .When(x => x.StartDate.HasValue && x.EndDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày kết thúc phải ≥ ngày bắt đầu"));
        RuleFor(x => x.BaseSalary)
            .GreaterThanOrEqualTo(0).When(x => x.BaseSalary.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Lương hợp đồng", 0));
    }
}