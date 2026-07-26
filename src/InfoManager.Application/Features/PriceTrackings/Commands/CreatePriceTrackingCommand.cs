namespace InfoManager.Application.Features.PriceTrackings.Commands;
public record CreatePriceTrackingCommand : IRequest<Result<string>>
{
    public string ProductName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public decimal CurrentPrice { get; init; }
    public decimal? DesiredPrice { get; init; }
    public decimal? LowestPriceSeen { get; init; }
    public string? StoreName { get; init; }
    public string? ProductUrl { get; init; }
    public bool IsPurchased { get; init; } = false;
    public DateTimeOffset? LastCheckedDate { get; init; }
}
public class CreatePriceTrackingCommandHandler : BaseCreateCommandHandler<CreatePriceTrackingCommand, PriceTracking>
{
    public CreatePriceTrackingCommandHandler(IApplicationDbContext context,
                                             IValidator<CreatePriceTrackingCommand> validator,
                                             ILogger<CreatePriceTrackingCommandHandler> logger) : base(context, validator, logger)
    {
    }
    protected override PriceTracking CreateEntity(CreatePriceTrackingCommand request)
    {
        return new PriceTracking
        {
            ProductName = request.ProductName.Trim(),
            Description = request.Description?.Trim(),
            CurrentPrice = request.CurrentPrice,
            DesiredPrice = request.DesiredPrice,
            LowestPriceSeen = request.LowestPriceSeen,
            StoreName = request.StoreName?.Trim(),
            ProductUrl = request.ProductUrl?.Trim(),
            IsPurchased = request.IsPurchased,
            LastCheckedDate = request.LastCheckedDate
        };
    }
    protected override async Task AddEntityAsync(PriceTracking entity, CancellationToken cancellationToken)
    {
        await Context.PriceTrackings.AddAsync(entity, cancellationToken);
    }
}
public class CreatePriceTrackingCommandValidator : AbstractValidator<CreatePriceTrackingCommand>
{
    public CreatePriceTrackingCommandValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên sản phẩm"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên sản phẩm", 200));
        RuleFor(x => x.CurrentPrice)
            .GreaterThan(0).WithMessage(ErrorHelpers.GetErrorMinValue("Giá hiện tại", 0));
        RuleFor(x => x.DesiredPrice)
            .GreaterThan(0).When(x => x.DesiredPrice.HasValue).WithMessage(ErrorHelpers.GetErrorMinValue("Giá mong muốn", 0));
        RuleFor(x => x.LowestPriceSeen)
            .GreaterThan(0).When(x => x.LowestPriceSeen.HasValue).WithMessage(ErrorHelpers.GetErrorMinValue("Giá thấp nhất đã thấy", 0));
        RuleFor(x => x.StoreName)
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên cửa hàng", 200));
        RuleFor(x => x.ProductUrl)
            .MaximumLength(300).WithMessage(ErrorHelpers.GetErrorMaxLength("URL sản phẩm", 300));
    }
}