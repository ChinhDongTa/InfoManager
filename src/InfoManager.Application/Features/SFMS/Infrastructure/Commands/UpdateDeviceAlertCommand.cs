namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

/// <summary>
/// Command cập nhật cảnh báo thiết bị.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateDeviceAlertCommand : IRequest<Result>
{
    /// <summary>
    /// ID cảnh báo. Bắt buộc. Truyền từ client (route).
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Loại cảnh báo. Tùy chọn.
    /// </summary>
    public AlertType? AlertType { get; init; }

    /// <summary>
    /// Nội dung cảnh báo. Tùy chọn.
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    /// Mức độ nghiêm trọng. Tùy chọn.
    /// </summary>
    public AlertSeverity? Severity { get; init; }

    /// <summary>
    /// Thời điểm xử lý xong. Tùy chọn.
    /// </summary>
    public DateTimeOffset? ResolvedTime { get; init; }

    /// <summary>
    /// Đã xử lý hay chưa. Tùy chọn.
    /// </summary>
    public bool? IsResolved { get; init; }

    /// <summary>
    /// Ghi chú xử lý. Tùy chọn.
    /// </summary>
    public string? ResolutionNotes { get; init; }
}
public class UpdateDeviceAlertCommandHandler : BaseUpdateCommandHandler<UpdateDeviceAlertCommand, DeviceAlert>
{
    public UpdateDeviceAlertCommandHandler(IApplicationDbContext context,
                                           IValidator<UpdateDeviceAlertCommand> validator,
                                           ILogger<UpdateDeviceAlertCommandHandler> logger) : base(context, validator, logger)
    { }
   
    protected override async Task<DeviceAlert?> GetEntityAsync(UpdateDeviceAlertCommand request, CancellationToken cancellationToken) 
        => await Context.DeviceAlerts.FindAsync([request.Id], cancellationToken);

    protected override async Task UpdateEntityProperties(DeviceAlert entity, UpdateDeviceAlertCommand request)
    {
        if (request.AlertType.HasValueAndIsDifferentFrom(entity.AlertType))
            entity.AlertType = request.AlertType!.Value;
        if (request.Message.HasValueAndIsDifferentFrom(entity.Message))
            entity.Message = request.Message!;
        if (request.Severity.HasValueAndIsDifferentFrom(entity.Severity))
            entity.Severity = request.Severity!.Value;
        if (request.ResolvedTime.HasValueAndIsDifferentFrom(entity.ResolvedTime))
            entity.ResolvedTime = request.ResolvedTime!.Value;
        if (request.IsResolved.HasValueAndIsDifferentFrom(entity.IsResolved))
            entity.IsResolved = request.IsResolved!.Value;
        if (request.ResolutionNotes.IsDifferentFrom(entity.ResolutionNotes))
            entity.ResolutionNotes = request.ResolutionNotes!;
    }
}
public class UpdateDeviceAlertCommandValidator : AbstractValidator<UpdateDeviceAlertCommand>
{
    public UpdateDeviceAlertCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id cảnh báo"));
        RuleFor(x => x.AlertType)
            .IsInEnum().When(x => x.AlertType.HasValue)            ;
        RuleFor(x => x.Severity)
            .IsInEnum().When(x => x.Severity.HasValue)            ;
         RuleFor(x => x.Message)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Message))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nội dung cảnh báo", 500));
    }
}