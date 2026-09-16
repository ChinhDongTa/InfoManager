namespace InfoManager.Application.Features.SFMS.Production.Commands;

public record CreateProductCommand : IRequest<Result<string>>
{
    public required string HarvestId { get; init; }
    public required string ProductName { get; init; }
    public string? Description { get; init; }
    public string? ProcessingType { get; init; }
    public required decimal Quantity { get; init; }
    public required string Unit { get; init; }
    public string? StorageLocation { get; init; }
    public DateTimeOffset? ExpiryDate { get; init; }
    public decimal? CostPerUnit { get; init; }
    public decimal? SellingPrice { get; init; }
    public decimal? TotalValue { get; init; }
    public required ProductStatus Status { get; init; }
    public string? Certification { get; init; }
    public string? Notes { get; init; }
}

public class CreateProductCommandHandler : BaseCreateCommandHandler<CreateProductCommand, Product>
{
    public CreateProductCommandHandler(IApplicationDbContext context,
                                       IValidator<CreateProductCommand> validator,
                                       ILogger<CreateProductCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(Product entity, CancellationToken ct)
        => await Context.Products.AddAsync(entity, ct);

    protected override Task<Product> CreateEntity(CreateProductCommand request)
        => Task.FromResult(new Product
        {
            HarvestId = request.HarvestId,
            ProductName = request.ProductName,
            Description = request.Description,
            ProcessingType = request.ProcessingType,
            Quantity = request.Quantity,
            Unit = request.Unit,
            StorageLocation = request.StorageLocation,
            ExpiryDate = request.ExpiryDate,
            CostPerUnit = request.CostPerUnit,
            SellingPrice = request.SellingPrice,
            TotalValue = request.TotalValue ?? (request.SellingPrice.HasValue ? request.Quantity * request.SellingPrice.Value : null),
            Status = request.Status,
            Certification = request.Certification,
            Notes = request.Notes
        });
}

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.HarvestId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID thu hoạch"));
        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên sản phẩm"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên sản phẩm", 200));
        RuleFor(x => x.Description)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Description))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả", 500));
        RuleFor(x => x.ProcessingType)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.ProcessingType))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Hình thức chế biến", 50));
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Số lượng", 0));
        RuleFor(x => x.Unit)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 50));
        RuleFor(x => x.StorageLocation)
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.StorageLocation))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Vị trí lưu kho", 200));
        RuleFor(x => x.CostPerUnit)
            .GreaterThanOrEqualTo(0).When(x => x.CostPerUnit.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Giá vốn", 0));
        RuleFor(x => x.SellingPrice)
            .GreaterThanOrEqualTo(0).When(x => x.SellingPrice.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Giá bán", 0));
        RuleFor(x => x.Certification)
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.Certification))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Chứng nhận", 200));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}