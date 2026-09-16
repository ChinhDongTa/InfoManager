namespace InfoManager.Application.Features.SFMS.Customer.Commands;

public record UpdateCustomerCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? FarmId { get; init; }
    public string? CustomerCode { get; init; }
    public string? Name { get; init; }
    public CustomerType? CustomerType { get; init; }
    public string? Phone { get; init; }
    public string? Email { get; init; }
    public string? Address { get; init; }
    public string? TaxCode { get; init; }
    public string? ContactPerson { get; init; }
    public decimal? CreditLimit { get; init; }
    public CustomerStatus? Status { get; init; }
    public string? Notes { get; init; }
}

public class UpdateCustomerCommandHanlder : BaseUpdateCommandHandler<UpdateCustomerCommand, Domain.Entities.SFMS.Customers.Customer>
{
    public UpdateCustomerCommandHanlder(IApplicationDbContext context,
                                        IValidator<UpdateCustomerCommand> validator,
                                        ILogger<UpdateCustomerCommandHanlder> logger) : base(context, validator, logger)
    {
    }

    protected override async Task<Domain.Entities.SFMS.Customers.Customer?> GetEntityAsync(UpdateCustomerCommand request, CancellationToken ct)
    {
        return await Context.Customers.FindAsync(request.Id, ct);
    }

    protected override async Task UpdateEntityProperties(Domain.Entities.SFMS.Customers.Customer entity, UpdateCustomerCommand request)
    {
        if (request.FarmId.HasValueAndIsDifferentFrom(entity.FarmId))
            entity.FarmId = request.FarmId!;
        if (request.Name.HasValueAndIsDifferentFrom(entity.Name))
            entity.Name = request.Name!;
        if (request.CustomerCode.IsDifferentFrom(entity.CustomerCode))
            entity.CustomerCode = request.CustomerCode!;
        if (request.CustomerType.HasValueAndIsDifferentFrom(entity.CustomerType))
            entity.CustomerType = request.CustomerType!.Value;
        if (request.Phone.IsDifferentFrom(entity.Phone))
            entity.Phone = request.Phone!;
        if (request.Email.IsDifferentFrom(entity.Email))
            entity.Email = request.Email!;
        if (request.Address.IsDifferentFrom(entity.Address))
            entity.Address = request.Address!;
        if (request.TaxCode.IsDifferentFrom(entity.TaxCode))
            entity.TaxCode = request.TaxCode!;
        if (request.ContactPerson.IsDifferentFrom(entity.ContactPerson))
            entity.ContactPerson = request.ContactPerson!;
        if (request.CreditLimit.IsDifferentFrom(entity.CreditLimit))
            entity.CreditLimit = request.CreditLimit;

        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
    }
}

public class UpdateCustomerCommandValidtor : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidtor()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Id khách hàng"));
        RuleFor(x => x.Name).MaximumLength(200)
             .When(x => !string.IsNullOrEmpty(x.Name))
             .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên khách hàng", 200));
    }
}