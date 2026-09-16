namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

/// <summary>
/// Command cập nhật cảm biến.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateSensorCommand : IRequest<Result>
{
    /// <summary>
    /// ID cảm biến. Bắt buộc. Truyền từ client (route).
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Tên / mã định danh cảm biến. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Loại cảm biến. Tùy chọn.
    /// </summary>
    public SensorType? SensorType { get; init; }

    /// <summary>
    /// Model / thương hiệu cảm biến. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? Model { get; init; }

    /// <summary>
    /// Số serial của cảm biến. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? SerialNumber { get; init; }

    /// <summary>
    /// ID thửa ruộng liên quan. Tùy chọn.
    /// </summary>
    public string? FieldId { get; init; }

    /// <summary>
    /// ID thiết bị / gateway. Tùy chọn.
    /// </summary>
    public string? DeviceId { get; init; }

    /// <summary>
    /// Tọa độ vĩ độ. Tùy chọn. Range: -90-90.
    /// </summary>
    public decimal? Latitude { get; init; }

    /// <summary>
    /// Tọa độ kinh độ. Tùy chọn. Range: -180-180.
    /// </summary>
    public decimal? Longitude { get; init; }

    /// <summary>
    /// Độ sâu lắp đặt (cm). Tùy chọn.
    /// </summary>
    public decimal? Depth { get; init; }

    /// <summary>
    /// Trạng thái cảm biến. Tùy chọn.
    /// </summary>
    public DeviceStatus? Status { get; init; }

    /// <summary>
    /// Thời điểm đọc dữ liệu gần nhất. Tùy chọn.
    /// </summary>
    public DateTimeOffset? LastReadingTime { get; init; }

    /// <summary>
    /// Mức pin. Tùy chọn. Range: 0-100.
    /// </summary>
    public decimal? BatteryLevel { get; init; }

    /// <summary>
    /// Cường độ tín hiệu. Tùy chọn. Range: 0-100.
    /// </summary>
    public decimal? SignalStrength { get; init; }

    /// <summary>
    /// Ngày hiệu chuẩn tiếp theo. Tùy chọn.
    /// </summary>
    public DateTimeOffset? NextCalibrationDate { get; init; }
}

public class UpdateSensorCommandHandler : BaseUpdateCommandHandler<UpdateSensorCommand, Sensor>
{
    public UpdateSensorCommandHandler(IApplicationDbContext context,
                                      IValidator<UpdateSensorCommand> validator,
                                      ILogger<UpdateSensorCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task<Sensor?> GetEntityAsync(UpdateSensorCommand request, CancellationToken ct)
        => await Context.Sensors.FindAsync([request.Id], ct);

    protected override async Task UpdateEntityProperties(Sensor entity, UpdateSensorCommand request)
    {
        if (request.Name.HasValueAndIsDifferentFrom(entity.Name))
            entity.Name = request.Name!;
        if (request.SensorType.HasValueAndIsDifferentFrom(entity.SensorType))
            entity.SensorType = request.SensorType!.Value;
        if (request.Model.IsDifferentFrom(entity.Model))
            entity.Model = request.Model;
        if (request.SerialNumber.IsDifferentFrom(entity.SerialNumber))
            entity.SerialNumber = request.SerialNumber;
        if (request.FieldId.HasValueAndIsDifferentFrom(entity.FieldId))
            entity.FieldId = request.FieldId!;
        if (request.DeviceId.IsDifferentFrom(entity.DeviceId))
            entity.DeviceId = request.DeviceId;
        if (request.Latitude.IsDifferentFrom(entity.Latitude))
            entity.Latitude = request.Latitude;
        if (request.Longitude.IsDifferentFrom(entity.Longitude))
            entity.Longitude = request.Longitude;
        if (request.Depth.IsDifferentFrom(entity.Depth))
            entity.Depth = request.Depth!.Value;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
        if (request.LastReadingTime.IsDifferentFrom(entity.LastReadingTime))
            entity.LastReadingTime = request.LastReadingTime;
        if (request.BatteryLevel.IsDifferentFrom(entity.BatteryLevel))
            entity.BatteryLevel = request.BatteryLevel;
        if (request.SignalStrength.IsDifferentFrom(entity.SignalStrength))
            entity.SignalStrength = request.SignalStrength;
        if (request.NextCalibrationDate.IsDifferentFrom(entity.NextCalibrationDate))
            entity.NextCalibrationDate = request.NextCalibrationDate;
    }
}

public class UpdateSensorCommandValidator : AbstractValidator<UpdateSensorCommand>
{
    public UpdateSensorCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID"));
        RuleFor(x => x.Name).MaximumLength(100)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên cảm biến", 100));
        RuleFor(x => x.Model).MaximumLength(100)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Model cảm biến", 100));
        RuleFor(x => x.SerialNumber).MaximumLength(100)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số serial cảm biến", 100));
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90)
            .When(x => x.Latitude.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Vĩ độ", -90, 90));
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180)
            .When(x => x.Longitude.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Kinh độ", -180, 180));
        RuleFor(x => x.BatteryLevel).InclusiveBetween(0, 100).When(x => x.BatteryLevel.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Mức pin", 0, 100));
        RuleFor(x => x.SignalStrength).InclusiveBetween(0, 100).When(x => x.SignalStrength.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Cường độ tín hiệu", 0, 100));
    }
}