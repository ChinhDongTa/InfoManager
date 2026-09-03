namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

/// <summary>
/// Command tạo mới thiết bị.
/// </summary>
public record CreateEquipmentCommand : IRequest<Result<string>>
{
    /// <summary>
    /// Tên thiết bị. Bắt buộc.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Loại thiết bị. Bắt buộc.
    /// </summary>
    public required EquipmentType EquipmentType { get; init; }

    /// <summary>
    /// ID nông trại liên kết. Bắt buộc.
    /// </summary>
    public required string FarmId { get; init; }

    /// <summary>
    /// Tên nhà sản xuất. Tùy chọn.
    /// </summary>
    public string? Manufacturer { get; init; }

    /// <summary>
    /// Số model. Tùy chọn.
    /// </summary>
    public string? Model { get; init; }

    /// <summary>
    /// Số serial. Tùy chọn.
    /// </summary>
    public string? SerialNumber { get; init; }

    /// <summary>
    /// Công suất (HP). Tùy chọn.
    /// </summary>
    public decimal? PowerRating { get; init; }

    /// <summary>
    /// Thông số kỹ thuật / dung tích. Tùy chọn.
    /// </summary>
    public string? Specifications { get; init; }

    /// <summary>
    /// Ngày mua. Tùy chọn.
    /// </summary>
    public DateTimeOffset? PurchaseDate { get; init; }

    /// <summary>
    /// Giá mua. Tùy chọn.
    /// </summary>
    public decimal? PurchaseCost { get; init; }

    /// <summary>
    /// Giá trị hiện tại. Tùy chọn.
    /// </summary>
    public decimal? CurrentValue { get; init; }

    /// <summary>
    /// Trạng thái thiết bị (mã). Tùy chọn.
    /// </summary>
    public EquipmentStatus Status { get; init; }

    /// <summary>
    /// Số giờ vận hành. Tùy chọn.
    /// </summary>
    public decimal? OperatingHours { get; init; }

    /// <summary>
    /// Ngày bảo trì gần nhất. Tùy chọn.
    /// </summary>
    public DateTimeOffset? LastMaintenanceDate { get; init; }

    /// <summary>
    /// Ngày bảo trì kế tiếp. Tùy chọn.
    /// </summary>
    public DateTimeOffset? NextMaintenanceDate { get; init; }

    /// <summary>
    /// Vị trí lưu trữ. Tùy chọn.
    /// </summary>
    public string? StorageLocation { get; init; }

    /// <summary>
    /// Ghi chú. Tùy chọn.
    /// </summary>
    public string? Notes { get; init; }
}
public class CreateEquipmentCommandHandler : BaseCreateCommandHandler<CreateEquipmentCommand, Equipment>
{
    public CreateEquipmentCommandHandler(IApplicationDbContext context,
                                         IValidator<CreateEquipmentCommand> validator,
                                         ILogger<CreateEquipmentCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task AddEntityAsync(Equipment entity, CancellationToken cancellationToken)
    {
        await Context.Equipments.AddAsync(entity,cancellationToken);
    }

    protected override async Task<Equipment> CreateEntity(CreateEquipmentCommand request)
    {
        return new Equipment
        {
            Name = request.Name,
            EquipmentType = request.EquipmentType,
            FarmId = request.FarmId,
            Manufacturer = request.Manufacturer,
            Model = request.Model,
            SerialNumber = request.SerialNumber,
            PowerRating = request.PowerRating,
            Specifications = request.Specifications,
            PurchaseDate= request.PurchaseDate,
            PurchaseCost= request.PurchaseCost,
            CurrentValue= request.CurrentValue,
            Status=request.Status,
            OperatingHours=request.OperatingHours,
            LastMaintenanceDate= request.LastMaintenanceDate,
            NextMaintenanceDate= request.NextMaintenanceDate,
            StorageLocation=request.StorageLocation,
            Notes=request.Notes,
        };
    }
}
public class CreateEquipmentCommandValidator : AbstractValidator<CreateEquipmentCommand>
{
    public CreateEquipmentCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên thiết bị"))
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên thiết bị", 100));
        RuleFor(x => x.EquipmentType)
            .IsInEnum().WithMessage(ErrorHelpers.GetErrorInvalid("Loại thiết bị"));
        RuleFor(x => x.FarmId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại liên kết"));
        RuleFor(x => x.Manufacturer)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.Manufacturer))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nhà sản xuất", 100));
        RuleFor(x => x.Model)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.Model))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Model", 100));
        RuleFor(x => x.SerialNumber)
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.SerialNumber))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Serial Number", 100));
        RuleFor(x => x.PowerRating)
            .GreaterThan(0).When(x => x.PowerRating.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Công suất", 0));
        RuleFor(x => x.Specifications)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Specifications))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Thông số kỹ thuật", 500));
        RuleFor(x => x.PurchaseCost)
            .GreaterThan(0).When(x => x.PurchaseCost.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Giá mua", 0));
        RuleFor(x => x.CurrentValue)
            .GreaterThan(0).When(x => x.CurrentValue.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Giá trị hiện tại", 0));
        RuleFor(x => x.OperatingHours)
            .GreaterThan(0).When(x => x.OperatingHours.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số giờ vận hành", 0));
    }
}