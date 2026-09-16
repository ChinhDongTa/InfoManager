namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

/// <summary>
/// Command tạo mới thiết bị IoT / gateway.
/// </summary>
public record CreateDeviceCommand : IRequest<Result<string>>
{
    /// <summary>
    /// Tên / mã định danh thiết bị. Bắt buộc. MaxLength: 100.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Loại thiết bị (Gateway, DataLogger, WeatherStation...). Bắt buộc.
    /// </summary>
    public required DeviceType DeviceType { get; init; }

    /// <summary>
    /// Model / thương hiệu thiết bị. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? Model { get; init; }

    /// <summary>
    /// Địa chỉ MAC hoặc mã định danh duy nhất. Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? MacAddress { get; init; }

    /// <summary>
    /// ID nông trại liên quan. Bắt buộc.
    /// </summary>
    public required string FarmId { get; init; }

    /// <summary>
    /// Trạng thái thiết bị. Bắt buộc.
    /// </summary>
    public required DeviceStatus Status { get; init; }

    /// <summary>
    /// Địa chỉ IP. Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? IpAddress { get; init; }

    /// <summary>
    /// Giao thức truyền thông (WiFi, LoRaWAN, Cellular, Bluetooth...). Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? CommunicationProtocol { get; init; }

    /// <summary>
    /// Phiên bản firmware. Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? FirmwareVersion { get; init; }

    /// <summary>
    /// Mức pin (0-100) nếu có. Tùy chọn. Range: 0-100.
    /// </summary>
    public decimal? BatteryLevel { get; init; }

    /// <summary>
    /// Dung lượng lưu trữ (MB). Tùy chọn.
    /// </summary>
    public decimal? StorageCapacity { get; init; }

    public decimal? StorageUsed { get; init; }

    /// <summary>
    /// Ngày lắp đặt. Bắt buộc.
    /// </summary>
    public required DateTimeOffset InstallationDate { get; init; }

    /// <summary>
    /// Ghi chú về thiết bị. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Notes { get; init; }
}

public class CreateDeviceCommandHandler : BaseCreateCommandHandler<CreateDeviceCommand, Device>
{
    public CreateDeviceCommandHandler(IApplicationDbContext context,
                                      IValidator<CreateDeviceCommand> validator,
                                      ILogger<CreateDeviceCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task AddEntityAsync(Device entity, CancellationToken ct)
    {
        await Context.Devices.AddAsync(entity, ct);
    }

    protected override async Task<Device> CreateEntity(CreateDeviceCommand request)
    {
        return new Device
        {
            Name = request.Name,
            DeviceType = request.DeviceType,
            Model = request.Model,
            MacAddress = request.MacAddress,
            FarmId = request.FarmId,
            Status = request.Status,
            IpAddress = request.IpAddress,
            CommunicationProtocol = request.CommunicationProtocol,
            FirmwareVersion = request.FirmwareVersion,
            BatteryLevel = request.BatteryLevel,
            StorageCapacity = request.StorageCapacity,
            StorageUsed = request.StorageUsed,
            InstallationDate = request.InstallationDate,
            Notes = request.Notes
        };
    }
}

public class CreateDeviceCommandValidator : AbstractValidator<CreateDeviceCommand>
{
    public CreateDeviceCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên thiết bị"))
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên thiết bị", 100));
        RuleFor(x => x.Model)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.Model)).WithMessage(ErrorHelpers.GetErrorMaxLength("Model thiết bị", 100));
        RuleFor(x => x.MacAddress)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.MacAddress)).WithMessage(ErrorHelpers.GetErrorMaxLength("Địa chỉ MAC", 50));
        RuleFor(x => x.FarmId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));
        RuleFor(x => x.IpAddress)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.IpAddress)).WithMessage(ErrorHelpers.GetErrorMaxLength("Địa chỉ IP", 50));
        RuleFor(x => x.CommunicationProtocol)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.CommunicationProtocol)).WithMessage(ErrorHelpers.GetErrorMaxLength("Giao thức truyền thông", 50));
        RuleFor(x => x.FirmwareVersion)
            .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.FirmwareVersion)).WithMessage(ErrorHelpers.GetErrorMaxLength("Phiên bản firmware", 50));
        RuleFor(x => x.BatteryLevel)
            .InclusiveBetween(0, 100).When(x => x.BatteryLevel.HasValue).WithMessage(ErrorHelpers.GetErrorOutOfRange("Mức pin", 0, 100));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes)).WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}