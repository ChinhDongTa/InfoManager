namespace InfoManager.Application.Features.SFMS.Customer.Commands;

/// <summary>
/// Command cập nhật thanh toán của khách hàng.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateCustomerPaymentCommand : IRequest<Result>
{
    /// <summary>
    /// ID bản ghi thanh toán. Bắt buộc.
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// ID đơn bán hàng liên quan. Tùy chọn.
    /// </summary>
    public string? SaleId { get; init; }

    /// <summary>
    /// ID doanh thu liên quan. Tùy chọn.
    /// </summary>
    public string? FarmRevenueId { get; init; }

    /// <summary>
    /// Số tiền thanh toán. Tùy chọn.
    /// </summary>
    public decimal? Amount { get; init; }

    /// <summary>
    /// Ngày thanh toán. Tùy chọn.
    /// </summary>
    public DateTimeOffset? PaymentDate { get; init; }

    /// <summary>
    /// Phương thức thanh toán (Tiền mặt, Chuyển khoản, Séc...). Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? PaymentMethod { get; init; }

    /// <summary>
    /// Trạng thái thanh toán. Tùy chọn.
    /// </summary>
    public PaymentStatus? PaymentStatus { get; init; }

    /// <summary>
    /// Mã giao dịch / số tham chiếu. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? ReferenceNumber { get; init; }

    /// <summary>
    /// Ghi chú thanh toán. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Notes { get; init; }
}

public class UpdateCustomerPaymentCommandHandler : BaseUpdateCommandHandler<UpdateCustomerPaymentCommand, CustomerPayment>
{
    public UpdateCustomerPaymentCommandHandler(IApplicationDbContext context, IValidator<UpdateCustomerPaymentCommand> validator, ILogger<UpdateCustomerPaymentCommandHandler> logger) : base(context, validator, logger)
    { }
    protected override async Task<CustomerPayment?> GetEntityAsync(UpdateCustomerPaymentCommand request, CancellationToken cancellationToken)
        => await Context.CustomerPayments.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    protected override async Task UpdateEntityProperties(CustomerPayment entity, UpdateCustomerPaymentCommand request)
    {
        if (request.SaleId.IsDifferentFrom(entity.SaleId))
            entity.SaleId = request.SaleId;
        if (request.FarmRevenueId.IsDifferentFrom(entity.FarmRevenueId))
            entity.FarmRevenueId = request.FarmRevenueId;
        if (request.Amount.HasValueAndIsDifferentFrom(entity.Amount))
            entity.Amount = request.Amount!.Value;
        if (request.PaymentDate.HasValueAndIsDifferentFrom(entity.PaymentDate))
            entity.PaymentDate = request.PaymentDate!.Value;
        if (request.PaymentMethod.IsDifferentFrom(entity.PaymentMethod))
            entity.PaymentMethod = request.PaymentMethod;
        if (request.PaymentStatus.HasValueAndIsDifferentFrom(entity.PaymentStatus))
            entity.PaymentStatus = request.PaymentStatus!.Value;
        if (request.ReferenceNumber.IsDifferentFrom(entity.ReferenceNumber))
            entity.ReferenceNumber = request.ReferenceNumber;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
    }
}
public class UpdateCustomerPaymentCommandValidator : AbstractValidator<UpdateCustomerPaymentCommand>
{
    public UpdateCustomerPaymentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Id bản ghi thanh toán"));
        RuleFor(x => x.PaymentMethod)
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Phương thức thanh toán", 50));
        RuleFor(x => x.ReferenceNumber)
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Mã giao dịch / số tham chiếu", 100));
        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú thanh toán", 500));
    }
}