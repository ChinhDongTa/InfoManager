namespace InfoManager.Application.Features.SFMS.Economics.Commands;

/// <summary>
/// Command tạo mới chi phí nông trại.
/// </summary>
public record CreateFarmExpenseCommand : IRequest<Result<string>>
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
    /// Loại chi phí. Bắt buộc.
    /// </summary>
    public required ExpenseType ExpenseType { get; init; }

    /// <summary>
    /// Mô tả chi phí. Bắt buộc. MaxLength: 500.
    /// </summary>
    public required string Description { get; init; }

    /// <summary>
    /// Số tiền đã chi. Bắt buộc. ≥ 0.
    /// </summary>
    public required decimal Amount { get; init; }

    /// <summary>
    /// Danh mục chi phí. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? Category { get; init; }

    /// <summary>
    /// Ngày phát sinh chi phí. Bắt buộc.
    /// </summary>
    public required DateTimeOffset ExpenseDate { get; init; }

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
    /// Trạng thái thanh toán. Bắt buộc.
    /// </summary>
    public required PaymentStatus PaymentStatus { get; init; }

    /// <summary>
    /// Trạng thái phê duyệt. Bắt buộc.
    /// </summary>
    public required ApprovalStatus ApprovalStatus { get; init; }

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

public class CreateFarmExpenseCommandHandler : BaseCreateCommandHandler<CreateFarmExpenseCommand, FarmExpense>
{
    public CreateFarmExpenseCommandHandler(IApplicationDbContext context,
                                           IValidator<CreateFarmExpenseCommand> validator,
                                           ILogger<CreateFarmExpenseCommandHandler> logger)
        : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(FarmExpense entity, CancellationToken cancellationToken)
    {
        await Context.FarmExpenses.AddAsync(entity, cancellationToken);
    }

    protected override async Task<FarmExpense> CreateEntity(CreateFarmExpenseCommand request)
    {
        return new FarmExpense
        {
            FarmId = request.FarmId,
            CropPlantingId = request.CropPlantingId,
            ExpenseType = request.ExpenseType,
            Description = request.Description,
            Amount = request.Amount,
            Category = request.Category,
            ExpenseDate = request.ExpenseDate,
            Vendor = request.Vendor,
            InvoiceNumber = request.InvoiceNumber,
            PaymentMethod = request.PaymentMethod,
            PaymentStatus = request.PaymentStatus,
            ApprovalStatus = request.ApprovalStatus,
            ApprovedBy = request.ApprovedBy,
            AttachmentUrl = request.AttachmentUrl,
            Notes = request.Notes
        };
    }
}

public class CreateFarmExpenseCommandValidator : AbstractValidator<CreateFarmExpenseCommand>
{
    public CreateFarmExpenseCommandValidator()
    {
        RuleFor(x => x.FarmId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mô tả chi phí"))
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả chi phí", 500));

        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(0).WithMessage(ErrorHelpers.GetErrorMinValue("Số tiền", 0));

        RuleFor(x => x.Category)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.Category))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Danh mục chi phí", 100));

        RuleFor(x => x.Vendor)
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.Vendor))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nhà cung cấp", 200));

        RuleFor(x => x.InvoiceNumber)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.InvoiceNumber))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số hóa đơn", 100));

        RuleFor(x => x.PaymentMethod)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.PaymentMethod))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Phương thức thanh toán", 50));

        RuleFor(x => x.ApprovedBy)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.ApprovedBy))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người phê duyệt", 100));

        RuleFor(x => x.AttachmentUrl)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.AttachmentUrl))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tệp đính kèm", 500));

        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}