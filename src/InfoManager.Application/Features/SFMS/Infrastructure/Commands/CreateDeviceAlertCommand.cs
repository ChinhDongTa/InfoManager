namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

/// <summary>
/// Command tạo mới cảnh báo thiết bị.
/// </summary>
public record CreateDeviceAlertCommand : IRequest<Result<string>>
{
    /// <summary>
    /// ID thiết bị. Bắt buộc.
    /// </summary>
    public required string DeviceId { get; init; }

    /// <summary>
    /// Loại cảnh báo. Bắt buộc.
    /// </summary>
    public required AlertType AlertType { get; init; }

    /// <summary>
    /// Nội dung cảnh báo. Bắt buộc.
    /// </summary>
    public required string Message { get; init; }

    /// <summary>
    /// Mức độ nghiêm trọng. Bắt buộc.
    /// </summary>
    public required AlertSeverity Severity { get; init; }

    /// <summary>
    /// Thời điểm cảnh báo. Bắt buộc.
    /// </summary>
    public required DateTimeOffset AlertTime { get; init; }

    /// <summary>
    /// Đã xử lý hay chưa. Bắt buộc.
    /// </summary>
    public required bool IsResolved { get; init; }

    /// <summary>
    /// Ghi chú xử lý. Tùy chọn.
    /// </summary>
    public string? ResolutionNotes { get; init; }
}

public class CreateDeviceAlertCommandHandler : BaseCreateCommandHandler<CreateDeviceAlertCommand, DeviceAlert>
{
    public CreateDeviceAlertCommandHandler(IApplicationDbContext context, IValidator<CreateDeviceAlertCommand> validator, ILogger<CreateDeviceAlertCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(DeviceAlert entity, CancellationToken ct)
    {
        await Context.DeviceAlerts.AddAsync(entity, ct);
    }

    protected override async Task<DeviceAlert> CreateEntity(CreateDeviceAlertCommand request)
    {
        return new DeviceAlert
        {
            DeviceId = request.DeviceId,
            AlertType = request.AlertType,
            Message = request.Message,
            Severity = request.Severity,
            AlertTime = request.AlertTime,
            IsResolved = request.IsResolved,
            ResolutionNotes = request.ResolutionNotes
        };
    }
}

public class CreateDeviceAlertCommandValidator : AbstractValidator<CreateDeviceAlertCommand>
{
    public CreateDeviceAlertCommandValidator()
    {
        RuleFor(x => x.DeviceId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID thiết bị"))
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("ID thiết bị", 50));
        RuleFor(x => x.AlertType)
            .IsInEnum().WithMessage(ErrorHelpers.GetErrorInvalid("Loại cảnh báo"));
        RuleFor(x => x.Message)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Nội dung cảnh báo"))
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("Nội dung cảnh báo", 500));
        RuleFor(x => x.Severity)
            .IsInEnum().WithMessage(ErrorHelpers.GetErrorInvalid("Mức độ nghiêm trọng"));
        RuleFor(x => x.AlertTime)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Thời điểm cảnh báo"));
        RuleFor(x => x.ResolutionNotes)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.ResolutionNotes)).WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú xử lý", 500));
    }
}