namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

/// <summary>
/// Command cập nhật thiết bị IoT / gateway.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateDeviceCommand : IRequest<Result>
{
    /// <summary>
    /// ID thiết bị. Bắt buộc. Truyền từ client (route/header).
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Tên / mã định danh thiết bị. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Loại thiết bị (Gateway, DataLogger, WeatherStation...). Tùy chọn.
    /// </summary>
    public DeviceType? DeviceType { get; init; }

    /// <summary>
    /// Model / thương hiệu thiết bị. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? Model { get; init; }

    /// <summary>
    /// Địa chỉ MAC hoặc mã định danh duy nhất. Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? MacAddress { get; init; }

    /// <summary>
    /// ID nông trại liên quan. Tùy chọn.
    /// </summary>
    public string? FarmId { get; init; }

    /// <summary>
    /// Trạng thái thiết bị. Tùy chọn.
    /// </summary>
    public DeviceStatus? Status { get; init; }

    /// <summary>
    /// Địa chỉ IP. Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? IpAddress { get; init; }

    /// <summary>
    /// Giao thức truyền thông (WiFi, LoRaWAN, Cellular, Bluetooth...). Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? CommunicationProtocol { get; init; }

    /// <summary>
    /// Thời điểm truyền dữ liệu gần nhất. Tùy chọn.
    /// </summary>
    public DateTimeOffset? LastDataSyncTime { get; init; }

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

    /// <summary>
    /// Dung lượng đã sử dụng (MB). Tùy chọn.
    /// </summary>
    public decimal? StorageUsed { get; init; }

    /// <summary>
    /// Ngày bảo trì gần nhất. Tùy chọn.
    /// </summary>
    public DateTimeOffset? LastMaintenanceDate { get; init; }

    /// <summary>
    /// Ghi chú về thiết bị. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Notes { get; init; }
}

public class UpdateDeviceCommandHandler: BaseUpdateCommandHandler<UpdateDeviceCommand, Device>
{
    public UpdateDeviceCommandHandler(IApplicationDbContext context,
                                      IValidator<UpdateDeviceCommand> validator,
                                      ILogger<UpdateDeviceCommandHandler> logger) : base(context, validator, logger)
    { }

    protected override async Task<Device?> GetEntityAsync(UpdateDeviceCommand request, CancellationToken cancellationToken) 
        => await Context.Devices.FindAsync(request.Id, cancellationToken);

    protected override async Task UpdateEntityProperties(Device entity, UpdateDeviceCommand request)
    {
        if(request.Name.HasValueAndIsDifferentFrom(entity.Name))
            entity.Name = request.Name!;
        if (request.DeviceType.HasValueAndIsDifferentFrom(entity.DeviceType))
            entity.DeviceType = request.DeviceType!.Value;
        if(request.Model.IsDifferentFrom(entity.Model))
            entity.Model = request.Model;
        if (request.MacAddress.IsDifferentFrom(entity.MacAddress))
            entity.MacAddress = request.MacAddress;
        if (request.FarmId.HasValueAndIsDifferentFrom(entity.FarmId))
            entity.FarmId = request.FarmId!;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
        if (request.IpAddress.IsDifferentFrom(entity.IpAddress))
            entity.IpAddress = request.IpAddress;
        if(request.CommunicationProtocol.IsDifferentFrom(entity.CommunicationProtocol))
            entity.CommunicationProtocol = request.CommunicationProtocol;
        if(request.FirmwareVersion.IsDifferentFrom(entity.FirmwareVersion))
            entity.FirmwareVersion = request.FirmwareVersion;
        if(request.BatteryLevel.IsDifferentFrom(entity.BatteryLevel))
            entity.BatteryLevel = request.BatteryLevel;
        if (request.StorageCapacity.IsDifferentFrom(entity.StorageCapacity))
            entity.StorageCapacity = request.StorageCapacity;
        if(request.StorageUsed.IsDifferentFrom(entity.StorageUsed))
            entity.StorageUsed = request.StorageUsed;
        if(request.LastDataSyncTime.IsDifferentFrom(entity.LastDataSyncTime))
            entity.LastDataSyncTime = request.LastDataSyncTime;
        if(request.LastMaintenanceDate.HasValueAndIsDifferentFrom(entity.LastMaintenanceDate))
            entity.LastMaintenanceDate = request.LastMaintenanceDate!.Value;
        if(request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
    }
}
public class UpdateDeviceCommandValidator : AbstractValidator<UpdateDeviceCommand>
{
    public UpdateDeviceCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id thiết bị là bắt buộc.");
        RuleFor(x => x.Name).MaximumLength(100).When(x => x.Name != null);
        RuleFor(x => x.Model).MaximumLength(100).When(x => x.Model != null);
        RuleFor(x => x.MacAddress).MaximumLength(50).When(x => x.MacAddress != null);
        RuleFor(x => x.IpAddress).MaximumLength(50).When(x => x.IpAddress != null);
        RuleFor(x => x.CommunicationProtocol).MaximumLength(50).When(x => x.CommunicationProtocol != null);
        RuleFor(x => x.FirmwareVersion).MaximumLength(50).When(x => x.FirmwareVersion != null);
        RuleFor(x => x.Notes).MaximumLength(500).When(x => x.Notes != null);
        RuleFor(x => x.BatteryLevel)
            .InclusiveBetween(0, 100)
            .When(x => x.BatteryLevel.HasValue)
            .WithMessage("Mức pin phải nằm trong khoảng từ 0 đến 100.");
    }
}