namespace InfoManager.Application.Features.SFMS.Economics.Commands;

/// <summary>
/// Command cập nhật chi phí nông trại.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateFarmExpenseCommand : IRequest<Result>
{
    /// <summary>
    /// ID chi phí. Bắt buộc. Truyền từ client (route/header).
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
    /// Loại chi phí. Tùy chọn.
    /// </summary>
    public ExpenseType? ExpenseType { get; init; }

    /// <summary>
    /// Mô tả chi phí. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Số tiền đã chi. Tùy chọn. ≥ 0.
    /// </summary>
    public decimal? Amount { get; init; }

    /// <summary>
    /// Danh mục chi phí. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? Category { get; init; }

    /// <summary>
    /// Ngày phát sinh chi phí. Tùy chọn.
    /// </summary>
    public DateTimeOffset? ExpenseDate { get; init; }

    /// <summary>
    /// Nhà cung cấp. Tùy chọn. MaxLength: 200.
    /// </summary>
    public string? Vendor { get; init; }

    /// <summary>
    /// Số hóa đơn. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? InvoiceNumber { get; init; }

    /// <summary>
    /// Phương thức thanh toán. Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? PaymentMethod { get; init; }

    /// <summary>
    /// Trạng thái thanh toán. Tùy chọn.
    /// </summary>
    public PaymentStatus? PaymentStatus { get; init; }

    /// <summary>
    /// Trạng thái phê duyệt. Tùy chọn.
    /// </summary>
    public ApprovalStatus? ApprovalStatus { get; init; }

    /// <summary>
    /// Người phê duyệt. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? ApprovedBy { get; init; }

    /// <summary>
    /// Đường dẫn tệp đính kèm. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? AttachmentUrl { get; init; }

    /// <summary>
    /// Ghi chú. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Notes { get; init; }
}

public class UpdateFarmExpenseCommandHandler : BaseUpdateCommandHandler<UpdateFarmExpenseCommand, FarmExpense>
{
    public UpdateFarmExpenseCommandHandler(IApplicationDbContext context,
                                           IValidator<UpdateFarmExpenseCommand> validator,
                                           ILogger<UpdateFarmExpenseCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task<FarmExpense?> GetEntityAsync(UpdateFarmExpenseCommand request, CancellationToken cancellationToken)
        => await Context.FarmExpenses.FindAsync([request.Id], cancellationToken);

    protected override async Task UpdateEntityProperties(FarmExpense entity, UpdateFarmExpenseCommand request)
    {
        if (request.FarmId.HasValueAndIsDifferentFrom(entity.FarmId))
            entity.FarmId = request.FarmId!;

        if (request.CropPlantingId.IsDifferentFrom(entity.CropPlantingId))
            entity.CropPlantingId = request.CropPlantingId;

        if (request.ExpenseType.HasValueAndIsDifferentFrom(entity.ExpenseType))
            entity.ExpenseType = request.ExpenseType!.Value;

        if (request.Description.HasValueAndIsDifferentFrom(entity.Description))
            entity.Description = request.Description!;

        if (request.Amount.HasValueAndIsDifferentFrom(entity.Amount))
            entity.Amount = request.Amount!.Value;

        if (request.Category.IsDifferentFrom(entity.Category))
            entity.Category = request.Category;

        if (request.ExpenseDate.HasValueAndIsDifferentFrom(entity.ExpenseDate))
            entity.ExpenseDate = request.ExpenseDate!.Value;

        if (request.Vendor.IsDifferentFrom(entity.Vendor))
            entity.Vendor = request.Vendor;

        if (request.InvoiceNumber.IsDifferentFrom(entity.InvoiceNumber))
            entity.InvoiceNumber = request.InvoiceNumber;

        if (request.PaymentMethod.IsDifferentFrom(entity.PaymentMethod))
            entity.PaymentMethod = request.PaymentMethod;

        if (request.PaymentStatus.HasValueAndIsDifferentFrom(entity.PaymentStatus))
            entity.PaymentStatus = request.PaymentStatus!.Value;

        if (request.ApprovalStatus.HasValueAndIsDifferentFrom(entity.ApprovalStatus))
            entity.ApprovalStatus = request.ApprovalStatus!.Value;

        if (request.ApprovedBy.IsDifferentFrom(entity.ApprovedBy))
            entity.ApprovedBy = request.ApprovedBy;

        if (request.AttachmentUrl.IsDifferentFrom(entity.AttachmentUrl))
            entity.AttachmentUrl = request.AttachmentUrl;

        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
    }
}

public class UpdateFarmExpenseCommandValidator : AbstractValidator<UpdateFarmExpenseCommand>
{
    public UpdateFarmExpenseCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID chi phí"));

        RuleFor(x => x.FarmId)
            .NotEmpty().When(x => x.FarmId != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));

        RuleFor(x => x.Description)
            .NotEmpty().When(x => x.Description != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Mô tả chi phí"))
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Description))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả chi phí", 500));

        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(0).When(x => x.Amount.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số tiền", 0));

        RuleFor(x => x.Category)
            .MaximumLength(100).When(x => x.Category != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Danh mục chi phí", 100));

        RuleFor(x => x.Vendor)
            .MaximumLength(200).When(x => x.Vendor != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nhà cung cấp", 200));

        RuleFor(x => x.InvoiceNumber)
            .MaximumLength(100).When(x => x.InvoiceNumber != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số hóa đơn", 100));

        RuleFor(x => x.PaymentMethod)
            .MaximumLength(50).When(x => x.PaymentMethod != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phương thức thanh toán", 50));

        RuleFor(x => x.ApprovedBy)
            .MaximumLength(100).When(x => x.ApprovedBy != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người phê duyệt", 100));

        RuleFor(x => x.AttachmentUrl)
            .MaximumLength(500).When(x => x.AttachmentUrl != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tệp đính kèm", 500));

        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}