namespace InfoManager.Application.Features.SFMS.Customer.Commands;

public record CreateCustomerCommand : IRequest<Result<string>>
{
    public required string FarmId { get; init; }
    public required string Name { get; init; }
    public string? CustomerCode { get; init; }
    public required CustomerType CustomerType { get; init; }
    public string? Phone { get; init; }
    public string? Email { get; init; }
    public string? Address { get; init; }
    public string? TaxCode { get; init; }
    public string? ContactPerson { get; init; }
    public decimal? CreditLimit { get; init; }
    public required CustomerStatus Status { get; init; }
    public string? Notes { get; init; }
}
public class CreateCustomerCommandHandler : BaseCreateCommandHandler<CreateCustomerCommand, Domain.Entities.SFMS.Customers.Customer>
{

    public CreateCustomerCommandHandler(IApplicationDbContext context, IValidator<CreateCustomerCommand> validator, ILogger<CreateCustomerCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(Domain.Entities.SFMS.Customers.Customer entity, CancellationToken cancellationToken)
    {
        await Context.Customers.AddAsync(entity, cancellationToken);
    }

    protected override async Task<Domain.Entities.SFMS.Customers.Customer> CreateEntity(CreateCustomerCommand request)
        => new()
        {
            FarmId = request.FarmId,
            Name = request.Name,
            CustomerCode = request.CustomerCode,
            CustomerType = request.CustomerType,
            Phone = request.Phone,
            Email = request.Email,
            Address = request.Address,
            TaxCode = request.TaxCode,
            ContactPerson = request.ContactPerson,
            CreditLimit = request.CreditLimit,
            Status = request.Status,
            Notes = request.Notes
        };
}
public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.FarmId)
           .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã nông trại"));
        RuleFor(x => x.Name)
           .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên khác hàng"));
    }
}