namespace InfoManager.Application.Features.SFMS.Economics.Commands;

/// <summary>
/// Command tạo mới doanh thu nông trại.
/// </summary>
public record CreateFarmRevenueCommand : IRequest<Result<string>>
{
    /// <summary>
    /// ID nông trại. Bắt buộc.
    /// </summary>
    public required string FarmId { get; init; }

    /// <summary>
    /// ID lần trồng liên quan. Tùy chọn.
    /// </summary>
    public string? CropPlantingId { get; init; }

    /// <summary>
    /// ID đợt thu hoạch liên quan. Tùy chọn.
    /// </summary>
    public string? HarvestId { get; init; }

    /// <summary>
    /// ID giao dịch bán hàng liên quan. Tùy chọn.
    /// </summary>
    public string? SaleId { get; init; }

    /// <summary>
    /// Nguồn doanh thu. Bắt buộc. MaxLength: 200.
    /// </summary>
    public required string Source { get; init; }

    /// <summary>
    /// Số tiền doanh thu. Bắt buộc. ≥ 0.
    /// </summary>
    public required decimal Amount { get; init; }

    /// <summary>
    /// Đơn vị tiền tệ. Tùy chọn. MaxLength: 10.
    /// </summary>
    public string? Currency { get; init; }

    /// <summary>
    /// Ngày phát sinh doanh thu. Bắt buộc.
    /// </summary>
    public required DateTimeOffset RevenueDate { get; init; }

    /// <summary>
    /// Tên người mua. Tùy chọn. MaxLength: 200.
    /// </summary>
    public string? BuyerName { get; init; }

    /// <summary>
    /// Trạng thái thanh toán. Bắt buộc.
    /// </summary>
    public required PaymentStatus PaymentStatus { get; init; }

    /// <summary>
    /// Ngày nhận thanh toán. Tùy chọn.
    /// </summary>
    public DateTimeOffset? PaymentReceivedDate { get; init; }

    /// <summary>
    /// Ghi chú. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Notes { get; init; }
}

public class CreateFarmRevenueCommandHandler : BaseCreateCommandHandler<CreateFarmRevenueCommand, FarmRevenue>
{
    public CreateFarmRevenueCommandHandler(IApplicationDbContext context,
                                           IValidator<CreateFarmRevenueCommand> validator,
                                           ILogger<CreateFarmRevenueCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(FarmRevenue entity, CancellationToken ct)
    {
        await Context.FarmRevenues.AddAsync(entity, ct);
    }

    protected override async Task<FarmRevenue> CreateEntity(CreateFarmRevenueCommand request)
    {
        return new FarmRevenue
        {
            FarmId = request.FarmId,
            CropPlantingId = request.CropPlantingId,
            HarvestId = request.HarvestId,
            SaleId = request.SaleId,
            Source = request.Source,
            Amount = request.Amount,
            Currency = request.Currency,
            RevenueDate = request.RevenueDate,
            BuyerName = request.BuyerName,
            PaymentStatus = request.PaymentStatus,
            PaymentReceivedDate = request.PaymentReceivedDate,
            Notes = request.Notes
        };
    }
}

public class CreateFarmRevenueCommandValidator : AbstractValidator<CreateFarmRevenueCommand>
{
    public CreateFarmRevenueCommandValidator()
    {
        RuleFor(x => x.FarmId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));

        RuleFor(x => x.Source)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Nguồn doanh thu"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Nguồn doanh thu", 200));

        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Số tiền", 0));

        RuleFor(x => x.Currency)
            .MaximumLength(10).When(x => !string.IsNullOrEmpty(x.Currency))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị tiền tệ", 10));

        RuleFor(x => x.BuyerName)
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.BuyerName))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên người mua", 200));

        RuleFor(x => x.PaymentReceivedDate)
            .GreaterThanOrEqualTo(x => x.RevenueDate)
            .When(x => x.PaymentReceivedDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày nhận thanh toán phải lớn hơn hoặc bằng ngày phát sinh doanh thu"));

        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}