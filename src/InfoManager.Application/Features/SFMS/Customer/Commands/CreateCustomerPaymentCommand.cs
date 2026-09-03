namespace InfoManager.Application.Features.SFMS.Customer.Commands;

/// <summary>
/// Command tạo mới thanh toán của khách hàng.
/// </summary>
public record CreateCustomerPaymentCommand : IRequest<Result<string>>
{
    /// <summary>
    /// ID khách hàng. Bắt buộc.
    /// </summary>
    public required string CustomerId { get; init; }

    /// <summary>
    /// ID nông trại. Bắt buộc.
    /// </summary>
    public required string FarmId { get; init; }

    /// <summary>
    /// ID đơn bán hàng liên quan. Tùy chọn.
    /// </summary>
    public string? SaleId { get; init; }

    /// <summary>
    /// ID doanh thu liên quan. Tùy chọn.
    /// </summary>
    public string? FarmRevenueId { get; init; }

    /// <summary>
    /// Số tiền thanh toán. Bắt buộc.
    /// </summary>
    public required decimal Amount { get; init; }

    /// <summary>
    /// Ngày thanh toán. Bắt buộc.
    /// </summary>
    public required DateTimeOffset PaymentDate { get; init; }

    /// <summary>
    /// Phương thức thanh toán (Tiền mặt, Chuyển khoản, Séc...). Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? PaymentMethod { get; init; }

    /// <summary>
    /// Trạng thái thanh toán. Bắt buộc.
    /// </summary>
    public required PaymentStatus PaymentStatus { get; init; }

    /// <summary>
    /// Mã giao dịch / số tham chiếu. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? ReferenceNumber { get; init; }

    /// <summary>
    /// Ghi chú thanh toán. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Notes { get; init; }
}

public class CreateCustomerPaymentCommandHandler : BaseCreateCommandHandler<CreateCustomerPaymentCommand, CustomerPayment>
{
    public CreateCustomerPaymentCommandHandler(IApplicationDbContext context, IValidator<CreateCustomerPaymentCommand> validator, ILogger<CreateCustomerPaymentCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(CustomerPayment entity, CancellationToken cancellationToken)
    {
        await Context.CustomerPayments.AddAsync(entity, cancellationToken);
    }

    protected override async Task<CustomerPayment> CreateEntity(CreateCustomerPaymentCommand request)
        => new()
        {
            CustomerId = request.CustomerId,
            FarmId = request.FarmId,
            SaleId = request.SaleId,
            FarmRevenueId = request.FarmRevenueId,
            Amount = request.Amount,
            PaymentDate = request.PaymentDate,
            PaymentMethod = request.PaymentMethod,
            PaymentStatus = request.PaymentStatus,
            ReferenceNumber = request.ReferenceNumber,
            Notes = request.Notes
        };
}
public class CreateCustomerPaymentCommandValidator : AbstractValidator<CreateCustomerPaymentCommand>
{
    public CreateCustomerPaymentCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã khách hàng"));
        RuleFor(x => x.FarmId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã nông trại"));
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Số tiền thanh toán", 1));
        RuleFor(x => x.PaymentDate)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Ngày thanh toán"));
        RuleFor(x => x.PaymentMethod)
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Phương thức thanh toán", 50));
        RuleFor(x => x.ReferenceNumber)
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Mã giao dịch / số tham chiếu", 100));
        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú thanh toán", 500));
    }
}