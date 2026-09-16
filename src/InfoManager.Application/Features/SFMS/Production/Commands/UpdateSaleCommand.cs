namespace InfoManager.Application.Features.SFMS.Production.Commands;

public record UpdateSaleCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? ProductId { get; init; }
    public DateTimeOffset? SaleDate { get; init; }
    public string? BuyerName { get; init; }
    public decimal? QuantitySold { get; init; }
    public decimal? UnitPrice { get; init; }
    public decimal? TotalAmount { get; init; }
    public decimal? DiscountPercentage { get; init; }
    public decimal? NetAmount { get; init; }
    public string? SaleChannel { get; init; }
    public PaymentStatus? PaymentStatus { get; init; }
    public DateTimeOffset? PaymentDate { get; init; }
    public string? InvoiceNumber { get; init; }
    public string? Notes { get; init; }
}

public class UpdateSaleCommandHandler : BaseUpdateCommandHandler<UpdateSaleCommand, Sale>
{
    public UpdateSaleCommandHandler(IApplicationDbContext context,
                                    IValidator<UpdateSaleCommand> validator,
                                    ILogger<UpdateSaleCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<Sale?> GetEntityAsync(UpdateSaleCommand request, CancellationToken ct)
        => await Context.Sales.FindAsync([request.Id], ct);

    protected override Task UpdateEntityProperties(Sale entity, UpdateSaleCommand request)
    {
        if (request.ProductId.HasValueAndIsDifferentFrom(entity.ProductId))
            entity.ProductId = request.ProductId!;
        if (request.SaleDate.HasValueAndIsDifferentFrom(entity.SaleDate))
            entity.SaleDate = request.SaleDate!.Value;
        if (request.BuyerName.HasValueAndIsDifferentFrom(entity.BuyerName))
            entity.BuyerName = request.BuyerName!;
        if (request.QuantitySold.HasValueAndIsDifferentFrom(entity.QuantitySold))
            entity.QuantitySold = request.QuantitySold!.Value;
        if (request.UnitPrice.HasValueAndIsDifferentFrom(entity.UnitPrice))
            entity.UnitPrice = request.UnitPrice!.Value;
        if (request.TotalAmount.HasValueAndIsDifferentFrom(entity.TotalAmount))
            entity.TotalAmount = request.TotalAmount!.Value;
        else if (!request.TotalAmount.HasValue && (request.QuantitySold.HasValue || request.UnitPrice.HasValue))
            entity.TotalAmount = entity.QuantitySold * entity.UnitPrice;
        if (request.DiscountPercentage.IsDifferentFrom(entity.DiscountPercentage))
            entity.DiscountPercentage = request.DiscountPercentage;
        if (request.NetAmount.HasValueAndIsDifferentFrom(entity.NetAmount))
            entity.NetAmount = request.NetAmount!.Value;
        else if (!request.NetAmount.HasValue
                 && (request.TotalAmount.HasValue || request.DiscountPercentage.HasValue
                     || request.QuantitySold.HasValue || request.UnitPrice.HasValue))
            entity.NetAmount = entity.TotalAmount * (1 - (entity.DiscountPercentage ?? 0) / 100);
        if (request.SaleChannel.IsDifferentFrom(entity.SaleChannel))
            entity.SaleChannel = request.SaleChannel;
        if (request.PaymentStatus.HasValueAndIsDifferentFrom(entity.PaymentStatus))
            entity.PaymentStatus = request.PaymentStatus!.Value;
        if (request.PaymentDate.IsDifferentFrom(entity.PaymentDate))
            entity.PaymentDate = request.PaymentDate;
        if (request.InvoiceNumber.IsDifferentFrom(entity.InvoiceNumber))
            entity.InvoiceNumber = request.InvoiceNumber;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
        return Task.CompletedTask;
    }
}

public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID đơn bán"));
        RuleFor(x => x.ProductId)
            .NotEmpty().When(x => x.ProductId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID sản phẩm"));
        RuleFor(x => x.BuyerName)
            .NotEmpty().When(x => x.BuyerName != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Tên người mua"))
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.BuyerName))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên người mua", 200));
        RuleFor(x => x.QuantitySold)
            .GreaterThan(0).When(x => x.QuantitySold.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số lượng bán", 0));
        RuleFor(x => x.UnitPrice)
            .GreaterThanOrEqualTo(0).When(x => x.UnitPrice.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Đơn giá", 0));
        RuleFor(x => x.DiscountPercentage)
            .InclusiveBetween(0, 100).When(x => x.DiscountPercentage.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Chiết khấu", 0, 100));
        RuleFor(x => x.SaleChannel)
            .MaximumLength(50).When(x => x.SaleChannel != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Kênh bán", 50));
        RuleFor(x => x.PaymentDate)
            .NotNull().When(x => x.PaymentStatus == PaymentStatus.Paid)
            .WithMessage(ErrorHelpers.GetErrorRequired("Ngày thanh toán"));
        RuleFor(x => x.InvoiceNumber)
            .MaximumLength(100).When(x => x.InvoiceNumber != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số hóa đơn", 100));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}