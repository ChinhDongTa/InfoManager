namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

/// <summary>
/// Command tạo mới cảm biến.
/// </summary>
public record CreateSensorCommand : IRequest<Result<string>>
{
    /// <summary>
    /// Tên / mã định danh cảm biến. Bắt buộc. MaxLength: 100.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Loại cảm biến (Nhiệt độ, Độ ẩm, Độ ẩm đất, pH đất, NPK...). Bắt buộc.
    /// </summary>
    public required SensorType SensorType { get; init; }

    /// <summary>
    /// Model / thương hiệu cảm biến. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? Model { get; init; }

    /// <summary>
    /// Số serial của cảm biến. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? SerialNumber { get; init; }

    /// <summary>
    /// ID thửa ruộng liên quan. Bắt buộc.
    /// </summary>
    public required string FieldId { get; init; }

    /// <summary>
    /// ID thiết bị / gateway thu thập dữ liệu. Tùy chọn.
    /// </summary>
    public string? DeviceId { get; init; }

    /// <summary>
    /// Tọa độ vĩ độ của cảm biến. Tùy chọn. Range: -90-90.
    /// </summary>
    public decimal? Latitude { get; init; }

    /// <summary>
    /// Tọa độ kinh độ của cảm biến. Tùy chọn. Range: -180-180.
    /// </summary>
    public decimal? Longitude { get; init; }

    /// <summary>
    /// Độ sâu lắp đặt (cảm biến đất, cm). Tùy chọn.
    /// </summary>
    public decimal? Depth { get; init; }

    /// <summary>
    /// Trạng thái cảm biến (Hoạt động, Không hoạt động, Lỗi, Bảo trì). Bắt buộc.
    /// </summary>
    public required DeviceStatus Status { get; init; }

    /// <summary>
    /// Ngày lắp đặt. Bắt buộc.
    /// </summary>
    public required DateTimeOffset InstallationDate { get; init; }

    /// <summary>
    /// Ngày hiệu chuẩn tiếp theo. Tùy chọn.
    /// </summary>
    public DateTimeOffset? NextCalibrationDate { get; init; }
}

public class CreateSensorCommandHandler : BaseCreateCommandHandler<CreateSensorCommand, Sensor>
{
    public CreateSensorCommandHandler(IApplicationDbContext context,
                                      IValidator<CreateSensorCommand> validator,
                                      ILogger<CreateSensorCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(Sensor entity, CancellationToken ct)
    {
        await Context.Sensors.AddAsync(entity, ct);
    }

    protected override async Task<Sensor> CreateEntity(CreateSensorCommand request)
    {
        return new Sensor
        {
            Name = request.Name,
            SensorType = request.SensorType,
            Model = request.Model,
            SerialNumber = request.SerialNumber,
            FieldId = request.FieldId,
            DeviceId = request.DeviceId,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Depth = request.Depth,
            Status = request.Status,
            InstallationDate = request.InstallationDate,
            NextCalibrationDate = request.NextCalibrationDate
        };
    }
}

public class CreateSensorCommandValidator : AbstractValidator<CreateSensorCommand>
{
    public CreateSensorCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.SensorType).IsInEnum();
        RuleFor(x => x.Model).MaximumLength(100);
        RuleFor(x => x.SerialNumber).MaximumLength(100);
        RuleFor(x => x.FieldId).NotEmpty();
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90).When(x => x.Latitude.HasValue);
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180).When(x => x.Longitude.HasValue);
        RuleFor(x => x.Status).IsInEnum();
        RuleFor(x => x.InstallationDate).NotEmpty();
    }
}