namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

/// <summary>
/// Command cập nhật thiết bị.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateEquipmentCommand : IRequest<Result>
{
    /// <summary>
    /// Khóa chính (UUID) của thiết bị cần cập nhật. Bắt buộc. Truyền từ client (route).
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Tên thiết bị. Tùy chọn.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Loại thiết bị. Tùy chọn.
    /// </summary>
    public EquipmentType? EquipmentType { get; init; }

    /// <summary>
    /// ID nông trại liên kết. Tùy chọn.
    /// </summary>
    public string? FarmId { get; init; }

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
    public EquipmentStatus? Status { get; init; }

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

public class UpdateEquipmentCommandHandler : BaseUpdateCommandHandler<UpdateEquipmentCommand, Equipment>
{
    public UpdateEquipmentCommandHandler(IApplicationDbContext context,
                                         IValidator<UpdateEquipmentCommand> validator,
                                         ILogger<UpdateEquipmentCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task<Equipment?> GetEntityAsync(UpdateEquipmentCommand request, CancellationToken cancellationToken) 
        => await Context.Equipments.FindAsync(request.Id, cancellationToken);

    protected override async Task UpdateEntityProperties(Equipment entity, UpdateEquipmentCommand request)
    {
        if(request.Name.HasValueAndIsDifferentFrom(entity.Name))
            entity.Name = request.Name!;
        if (request.EquipmentType.HasValueAndIsDifferentFrom(entity.EquipmentType))
            entity.EquipmentType = request.EquipmentType!.Value;
        if (request.FarmId.HasValueAndIsDifferentFrom(entity.FarmId))
            entity.FarmId = request.FarmId!;
        if (request.Manufacturer.IsDifferentFrom(entity.Manufacturer))
            entity.Manufacturer = request.Manufacturer;
        if (request.Model.IsDifferentFrom(entity.Model))
            entity.Model = request.Model;
        if (request.SerialNumber.IsDifferentFrom(entity.SerialNumber))
            entity.SerialNumber = request.SerialNumber!;
        if (request.PowerRating.IsDifferentFrom(entity.PowerRating))
            entity.PowerRating = request.PowerRating;
        if (request.Specifications.IsDifferentFrom(entity.Specifications))
            entity.Specifications = request.Specifications;
        if (request.PurchaseDate.IsDifferentFrom(entity.PurchaseDate))
            entity.PurchaseDate = request.PurchaseDate;
        if (request.PurchaseCost.IsDifferentFrom(entity.PurchaseCost))
            entity.PurchaseCost = request.PurchaseCost;
        if (request.CurrentValue.IsDifferentFrom(entity.CurrentValue))
            entity.CurrentValue = request.CurrentValue;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
        if (request.OperatingHours.IsDifferentFrom(entity.OperatingHours))
            entity.OperatingHours = request.OperatingHours;
        if (request.LastMaintenanceDate.IsDifferentFrom(entity.LastMaintenanceDate))
            entity.LastMaintenanceDate = request.LastMaintenanceDate;
        if (request.NextMaintenanceDate.IsDifferentFrom(entity.NextMaintenanceDate))
            entity.NextMaintenanceDate = request.NextMaintenanceDate;
        if (request.StorageLocation.IsDifferentFrom(entity.StorageLocation))
            entity.StorageLocation = request.StorageLocation;
        if (request.Notes.IsDifferentFrom(entity.Notes))
                entity.Notes = request.Notes;
    }
}


public class UpdateEquipmentCommandValidator : AbstractValidator<UpdateEquipmentCommand>
{
    public UpdateEquipmentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id thiết bị"));
        RuleFor(x => x.Name)
            .MaximumLength(200)
            .When(x => !string.IsNullOrEmpty(x.Name))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên thiết bị", 200));
        RuleFor(x => x.Manufacturer)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.Manufacturer))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên nhà sản xuất", 100));
        RuleFor(x => x.Model)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.Model))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số model", 100));
        RuleFor(x => x.SerialNumber)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.SerialNumber))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số serial", 100));
        RuleFor(x => x.Specifications)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Specifications))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Thông số kỹ thuật", 500));
        RuleFor(x => x.StorageLocation)
            .MaximumLength(200)
            .When(x => !string.IsNullOrEmpty(x.StorageLocation))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Vị trí lưu trữ", 200));
        RuleFor(x => x.Notes)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}