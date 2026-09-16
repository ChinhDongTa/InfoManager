namespace InfoManager.Application.Features.SFMS.Customer.Commands;

/// <summary>
/// Command tạo mới chăm sóc / theo dõi khách hàng.
/// </summary>
public record CreateCustomerCareCommand : IRequest<Result<string>>
{
    /// <summary>
    /// ID khách hàng. Bắt buộc.
    /// </summary>
    public required string CustomerId { get; init; }

    /// <summary>
    /// ID nông trại. Bắt buộc.
    /// </summary>
    public required string FarmId { get; init; }

    /// <summary>
    /// Tiêu đề. Bắt buộc. MaxLength: 200.
    /// </summary>
    public required string Subject { get; init; }

    /// <summary>
    /// Loại chăm sóc (Gọi điện, Ghé thăm, Khiếu nại, Theo dõi...). Bắt buộc.
    /// </summary>
    public required CustomerCareType CareType { get; init; }

    /// <summary>
    /// Nội dung chăm sóc. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    /// Ngày chăm sóc. Bắt buộc.
    /// </summary>
    public required DateTimeOffset CareDate { get; init; }

    /// <summary>
    /// Ngày theo dõi tiếp theo. Tùy chọn.
    /// </summary>
    public DateTimeOffset? NextFollowUpDate { get; init; }

    /// <summary>
    /// Trạng thái xử lý. Bắt buộc.
    /// </summary>
    public required CustomerCareStatus Status { get; init; }

    /// <summary>
    /// Người phụ trách. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? HandledBy { get; init; }

    /// <summary>
    /// Kết quả / ghi chú xử lý. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Result { get; init; }
}

public class CreateCustomerCareCommandHandler : BaseCreateCommandHandler<CreateCustomerCareCommand, CustomerCare>
{
    public CreateCustomerCareCommandHandler(IApplicationDbContext context,
                                            IValidator<CreateCustomerCareCommand> validator,
                                            ILogger<CreateCustomerCareCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(CustomerCare entity, CancellationToken ct)
    {
        await Context.CustomerCares.AddAsync(entity, ct);
    }

    protected override async Task<CustomerCare> CreateEntity(CreateCustomerCareCommand request)
        => new()
        {
            CustomerId = request.CustomerId,
            FarmId = request.FarmId,
            Subject = request.Subject,
            CareType = request.CareType,
            Content = request.Content,
            CareDate = request.CareDate,
            NextFollowUpDate = request.NextFollowUpDate,
            Status = request.Status,
            HandledBy = request.HandledBy,
            Result = request.Result
        };
}

public class CreateCustomerCareCommandValidator : AbstractValidator<CreateCustomerCareCommand>
{
    public CreateCustomerCareCommandValidator()
    {
        RuleFor(x => x.CustomerId)
           .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã khách hàng"));
        RuleFor(x => x.FarmId)
           .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã nông trại"));
        RuleFor(x => x.Subject)
           .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tiêu đề"))
           .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tiêu đề", 200));
    }
}