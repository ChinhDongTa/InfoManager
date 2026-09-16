namespace InfoManager.Application.Features.SFMS.Production.Commands;

public record CreateSaleCommand : IRequest<Result<string>>
{
    public required string ProductId { get; init; }
    public required DateTimeOffset SaleDate { get; init; }
    public required string BuyerName { get; init; }
    public required decimal QuantitySold { get; init; }
    public required decimal UnitPrice { get; init; }
    public decimal? TotalAmount { get; init; }
    public decimal? DiscountPercentage { get; init; }
    public decimal? NetAmount { get; init; }
    public string? SaleChannel { get; init; }
    public required PaymentStatus PaymentStatus { get; init; }
    public DateTimeOffset? PaymentDate { get; init; }
    public string? InvoiceNumber { get; init; }
    public string? Notes { get; init; }
}

public class CreateSaleCommandHandler : BaseCreateCommandHandler<CreateSaleCommand, Sale>
{
    public CreateSaleCommandHandler(IApplicationDbContext context,
                                    IValidator<CreateSaleCommand> validator,
                                    ILogger<CreateSaleCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(Sale entity, CancellationToken ct)
        => await Context.Sales.AddAsync(entity, ct);

    protected override Task<Sale> CreateEntity(CreateSaleCommand request)
    {
        var total = request.TotalAmount ?? request.QuantitySold * request.UnitPrice;
        var net = request.NetAmount
                  ?? total * (1 - (request.DiscountPercentage ?? 0) / 100);
        return Task.FromResult(new Sale
        {
            ProductId = request.ProductId,
            SaleDate = request.SaleDate,
            BuyerName = request.BuyerName,
            QuantitySold = request.QuantitySold,
            UnitPrice = request.UnitPrice,
            TotalAmount = total,
            DiscountPercentage = request.DiscountPercentage,
            NetAmount = net,
            SaleChannel = request.SaleChannel,
            PaymentStatus = request.PaymentStatus,
            PaymentDate = request.PaymentDate,
            InvoiceNumber = request.InvoiceNumber,
            Notes = request.Notes
        });
    }
}

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID sản phẩm"));
        RuleFor(x => x.BuyerName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên người mua"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên người mua", 200));
        RuleFor(x => x.QuantitySold).GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Số lượng bán", 0));
        RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Đơn giá", 0));
        RuleFor(x => x.DiscountPercentage)
            .InclusiveBetween(0, 100).When(x => x.DiscountPercentage.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Chiết khấu", 0, 100));
        RuleFor(x => x.SaleChannel)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.SaleChannel))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Kênh bán", 50));
        RuleFor(x => x.PaymentDate)
            .NotNull().When(x => x.PaymentStatus == PaymentStatus.Paid)
            .WithMessage(ErrorHelpers.GetErrorRequired("Ngày thanh toán"));
        RuleFor(x => x.InvoiceNumber)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.InvoiceNumber))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số hóa đơn", 100));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}