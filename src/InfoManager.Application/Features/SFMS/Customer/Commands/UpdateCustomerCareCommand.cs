namespace InfoManager.Application.Features.SFMS.Customer.Commands;

/// <summary>
/// Command cập nhật chăm sóc / theo dõi khách hàng.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateCustomerCareCommand : IRequest<Result>
{
    /// <summary>
    /// ID bản ghi chăm sóc khách hàng. Bắt buộc.
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Loại chăm sóc (Gọi điện, Ghé thăm, Khiếu nại, Theo dõi...). Tùy chọn.
    /// </summary>
    public CustomerCareType? CareType { get; init; }

    /// <summary>
    /// Tiêu đề. Tùy chọn. MaxLength: 200.
    /// </summary>
    public string? Subject { get; init; }

    /// <summary>
    /// Nội dung chăm sóc. Tùy chọn. MaxLength: 1000.
    /// </summary>
    public string? Content { get; init; }

    /// <summary>
    /// Ngày chăm sóc. Tùy chọn.
    /// </summary>
    public DateTimeOffset? CareDate { get; init; }

    /// <summary>
    /// Ngày theo dõi tiếp theo. Tùy chọn.
    /// </summary>
    public DateTimeOffset? NextFollowUpDate { get; init; }

    /// <summary>
    /// Trạng thái xử lý. Tùy chọn.
    /// </summary>
    public CustomerCareStatus? Status { get; init; }

    /// <summary>
    /// Người phụ trách. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? HandledBy { get; init; }

    /// <summary>
    /// Kết quả / ghi chú xử lý. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Result { get; init; }
}

public class UpdateCustomerCareCommandHandler : BaseUpdateCommandHandler<UpdateCustomerCareCommand, CustomerCare>
{
    public UpdateCustomerCareCommandHandler(IApplicationDbContext context, IValidator<UpdateCustomerCareCommand> validator, ILogger<UpdateCustomerCareCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task<CustomerCare?> GetEntityAsync(UpdateCustomerCareCommand request, CancellationToken ct)
        => await Context.CustomerCares.FirstOrDefaultAsync(x => x.Id == request.Id, ct);

    protected override async Task UpdateEntityProperties(CustomerCare entity, UpdateCustomerCareCommand request)
    {
        if (request.CareType.HasValueAndIsDifferentFrom(entity.CareType))
            entity.CareType = request.CareType!.Value;
        if (request.Subject.HasValueAndIsDifferentFrom(entity.Subject))
            entity.Subject = request.Subject!;
        if (request.Content.IsDifferentFrom(entity.Content))
            entity.Content = request.Content!;
        if (request.CareDate.HasValueAndIsDifferentFrom(entity.CareDate))
            entity.CareDate = request.CareDate!.Value;
        if (request.NextFollowUpDate.IsDifferentFrom(entity.NextFollowUpDate))
            entity.NextFollowUpDate = request.NextFollowUpDate;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
        if (request.HandledBy.IsDifferentFrom(entity.HandledBy))
            entity.HandledBy = request.HandledBy!;
        if (request.Result.IsDifferentFrom(entity.Result))
            entity.Result = request.Result!;
    }
}

public class UpdateCustomerCareCommandValidator : AbstractValidator<UpdateCustomerCareCommand>
{
    public UpdateCustomerCareCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Id bản ghi chăm sóc khách hàng"));
        RuleFor(x => x.Subject).MaximumLength(200)
            .When(x => !string.IsNullOrEmpty(x.Subject))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tiêu đề", 200));
        RuleFor(x => x.Content).MaximumLength(1000)
            .When(x => !string.IsNullOrEmpty(x.Content))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nội dung chăm sóc", 1000));
        RuleFor(x => x.HandledBy).MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.HandledBy))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Người phụ trách", 100));
        RuleFor(x => x.Result).MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Result))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Kết quả / ghi chú xử lý", 500));
    }
}