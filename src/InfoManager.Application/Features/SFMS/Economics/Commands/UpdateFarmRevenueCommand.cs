namespace InfoManager.Application.Features.SFMS.Economics.Commands;

/// <summary>
/// Command cập nhật doanh thu nông trại.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateFarmRevenueCommand : IRequest<Result>
{
    /// <summary>
    /// ID doanh thu. Bắt buộc. Truyền từ client (route/header).
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// ID nông trại. Tùy chọn.
    /// </summary>
    public string? FarmId { get; init; }

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
    /// Nguồn doanh thu. Tùy chọn. MaxLength: 200.
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// Số tiền doanh thu. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? Amount { get; init; }

    /// <summary>
    /// Đơn vị tiền tệ. Tùy chọn. MaxLength: 10.
    /// </summary>
    public string? Currency { get; init; }

    /// <summary>
    /// Ngày phát sinh doanh thu. Tùy chọn.
    /// </summary>
    public DateTimeOffset? RevenueDate { get; init; }

    /// <summary>
    /// Tên người mua. Tùy chọn. MaxLength: 200.
    /// </summary>
    public string? BuyerName { get; init; }

    /// <summary>
    /// Trạng thái thanh toán. Tùy chọn.
    /// </summary>
    public PaymentStatus? PaymentStatus { get; init; }

    /// <summary>
    /// Ngày nhận thanh toán. Tùy chọn.
    /// </summary>
    public DateTimeOffset? PaymentReceivedDate { get; init; }

    /// <summary>
    /// Ghi chú. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Notes { get; init; }
}

public class UpdateFarmRevenueCommandHandler : BaseUpdateCommandHandler<UpdateFarmRevenueCommand, FarmRevenue>
{
    public UpdateFarmRevenueCommandHandler(IApplicationDbContext context,
                                           IValidator<UpdateFarmRevenueCommand> validator,
                                           ILogger<UpdateFarmRevenueCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task<FarmRevenue?> GetEntityAsync(UpdateFarmRevenueCommand request, CancellationToken cancellationToken)
        => await Context.FarmRevenues.FindAsync([request.Id], cancellationToken);

    protected override async Task UpdateEntityProperties(FarmRevenue entity, UpdateFarmRevenueCommand request)
    {
        if (request.FarmId.HasValueAndIsDifferentFrom(entity.FarmId))
            entity.FarmId = request.FarmId!;

        if (request.CropPlantingId.IsDifferentFrom(entity.CropPlantingId))
            entity.CropPlantingId = request.CropPlantingId;

        if (request.HarvestId.IsDifferentFrom(entity.HarvestId))
            entity.HarvestId = request.HarvestId;

        if (request.SaleId.IsDifferentFrom(entity.SaleId))
            entity.SaleId = request.SaleId;

        if (request.Source.HasValueAndIsDifferentFrom(entity.Source))
            entity.Source = request.Source!;

        if (request.Amount.HasValueAndIsDifferentFrom(entity.Amount))
            entity.Amount = request.Amount!.Value;

        if (request.Currency.IsDifferentFrom(entity.Currency))
            entity.Currency = request.Currency;

        if (request.RevenueDate.HasValueAndIsDifferentFrom(entity.RevenueDate))
            entity.RevenueDate = request.RevenueDate!.Value;

        if (request.BuyerName.IsDifferentFrom(entity.BuyerName))
            entity.BuyerName = request.BuyerName;

        if (request.PaymentStatus.HasValueAndIsDifferentFrom(entity.PaymentStatus))
            entity.PaymentStatus = request.PaymentStatus!.Value;

        if (request.PaymentReceivedDate.IsDifferentFrom(entity.PaymentReceivedDate))
            entity.PaymentReceivedDate = request.PaymentReceivedDate;

        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
    }
}

public class UpdateFarmRevenueCommandValidator : AbstractValidator<UpdateFarmRevenueCommand>
{
    public UpdateFarmRevenueCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID doanh thu"));

        RuleFor(x => x.FarmId)
            .NotEmpty().When(x => x.FarmId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));

        RuleFor(x => x.Source)
            .NotEmpty().When(x => x.Source != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Nguồn doanh thu"))
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.Source))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nguồn doanh thu", 200));

        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(0).When(x => x.Amount.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số tiền", 0));

        RuleFor(x => x.Currency)
            .MaximumLength(10).When(x => x.Currency != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị tiền tệ", 10));

        RuleFor(x => x.BuyerName)
            .MaximumLength(200).When(x => x.BuyerName != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên người mua", 200));

        RuleFor(x => x.PaymentReceivedDate)
            .GreaterThanOrEqualTo(x => x.RevenueDate)
            .When(x => x.RevenueDate.HasValue && x.PaymentReceivedDate.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Ngày nhận thanh toán phải lớn hơn hoặc bằng ngày phát sinh doanh thu"));

        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}