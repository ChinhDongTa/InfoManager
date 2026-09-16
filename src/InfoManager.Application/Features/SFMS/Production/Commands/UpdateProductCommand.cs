namespace InfoManager.Application.Features.SFMS.Production.Commands;

public record UpdateProductCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? HarvestId { get; init; }
    public string? ProductName { get; init; }
    public string? Description { get; init; }
    public string? ProcessingType { get; init; }
    public decimal? Quantity { get; init; }
    public string? Unit { get; init; }
    public string? StorageLocation { get; init; }
    public DateTimeOffset? ExpiryDate { get; init; }
    public decimal? CostPerUnit { get; init; }
    public decimal? SellingPrice { get; init; }
    public decimal? TotalValue { get; init; }
    public ProductStatus? Status { get; init; }
    public string? Certification { get; init; }
    public string? Notes { get; init; }
}

public class UpdateProductCommandHandler : BaseUpdateCommandHandler<UpdateProductCommand, Product>
{
    public UpdateProductCommandHandler(IApplicationDbContext context,
                                       IValidator<UpdateProductCommand> validator,
                                       ILogger<UpdateProductCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<Product?> GetEntityAsync(UpdateProductCommand request, CancellationToken ct)
        => await Context.Products.FindAsync([request.Id], ct);

    protected override Task UpdateEntityProperties(Product entity, UpdateProductCommand request)
    {
        if (request.HarvestId.HasValueAndIsDifferentFrom(entity.HarvestId))
            entity.HarvestId = request.HarvestId!;
        if (request.ProductName.HasValueAndIsDifferentFrom(entity.ProductName))
            entity.ProductName = request.ProductName!;
        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description;
        if (request.ProcessingType.IsDifferentFrom(entity.ProcessingType))
            entity.ProcessingType = request.ProcessingType;
        if (request.Quantity.HasValueAndIsDifferentFrom(entity.Quantity))
            entity.Quantity = request.Quantity!.Value;
        if (request.Unit.HasValueAndIsDifferentFrom(entity.Unit))
            entity.Unit = request.Unit!;
        if (request.StorageLocation.IsDifferentFrom(entity.StorageLocation))
            entity.StorageLocation = request.StorageLocation;
        if (request.ExpiryDate.IsDifferentFrom(entity.ExpiryDate))
            entity.ExpiryDate = request.ExpiryDate;
        if (request.CostPerUnit.IsDifferentFrom(entity.CostPerUnit))
            entity.CostPerUnit = request.CostPerUnit;
        if (request.SellingPrice.IsDifferentFrom(entity.SellingPrice))
            entity.SellingPrice = request.SellingPrice;
        if (request.TotalValue.IsDifferentFrom(entity.TotalValue))
            entity.TotalValue = request.TotalValue;
        else if (!request.TotalValue.HasValue && entity.SellingPrice.HasValue
                 && (request.Quantity.HasValue || request.SellingPrice.HasValue))
            entity.TotalValue = entity.Quantity * entity.SellingPrice.Value;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
        if (request.Certification.IsDifferentFrom(entity.Certification))
            entity.Certification = request.Certification;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
        return Task.CompletedTask;
    }
}

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID sản phẩm"));
        RuleFor(x => x.HarvestId)
            .NotEmpty().When(x => x.HarvestId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID thu hoạch"));
        RuleFor(x => x.ProductName)
            .NotEmpty().When(x => x.ProductName != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Tên sản phẩm"))
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.ProductName))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên sản phẩm", 200));
        RuleFor(x => x.Description)
            .MaximumLength(500).When(x => x.Description != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả", 500));
        RuleFor(x => x.ProcessingType)
            .MaximumLength(50).When(x => x.ProcessingType != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Hình thức chế biến", 50));
        RuleFor(x => x.Quantity)
            .GreaterThan(0).When(x => x.Quantity.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số lượng", 0));
        RuleFor(x => x.Unit)
            .NotEmpty().When(x => x.Unit != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.Unit))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 50));
        RuleFor(x => x.StorageLocation)
            .MaximumLength(200).When(x => x.StorageLocation != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Vị trí lưu kho", 200));
        RuleFor(x => x.CostPerUnit)
            .GreaterThanOrEqualTo(0).When(x => x.CostPerUnit.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Giá vốn", 0));
        RuleFor(x => x.SellingPrice)
            .GreaterThanOrEqualTo(0).When(x => x.SellingPrice.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Giá bán", 0));
        RuleFor(x => x.Certification)
            .MaximumLength(200).When(x => x.Certification != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Chứng nhận", 200));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}