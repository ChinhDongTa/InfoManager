namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

/// <summary>
/// Command cập nhật nông trại.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// </summary>
public record UpdateFarmCommand : IRequest<Result>
{
    /// <summary>
    /// ID nông trại. Bắt buộc. Truyền từ client (route).
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Tên nông trại. Tùy chọn. MaxLength: 200.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Mô tả nông trại. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Tổng diện tích nông trại (hecta). Tùy chọn.
    /// </summary>
    public decimal? TotalArea { get; init; }

    /// <summary>
    /// Diện tích có thể canh tác (hecta). Tùy chọn.
    /// </summary>
    public decimal? CultivableArea { get; init; }

    /// <summary>
    /// Địa điểm / địa chỉ nông trại. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Location { get; init; }

    /// <summary>
    /// Tọa độ vĩ độ. Tùy chọn.
    /// </summary>
    public decimal? Latitude { get; init; }

    /// <summary>
    /// Tọa độ kinh độ. Tùy chọn.
    /// </summary>
    public decimal? Longitude { get; init; }

    /// <summary>
    /// Chủ hộ sở hữu nông trại. Tùy chọn.
    /// </summary>
    public string? FarmerId { get; init; }

    /// <summary>
    /// Số đăng ký / giấy phép nông trại. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? LicenseNumber { get; init; }

    /// <summary>
    /// Trạng thái nông trại. Tùy chọn.
    /// </summary>
    public FarmStatus? Status { get; init; }

    /// <summary>
    /// Ngày bắt đầu hoạt động. Tùy chọn.
    /// </summary>
    public DateTimeOffset? EstablishedDate { get; init; }
}

public class UpdateFarmCommandHandler : BaseUpdateCommandHandler<UpdateFarmCommand, Farm>
{
    public UpdateFarmCommandHandler(IApplicationDbContext context,
                                    IValidator<UpdateFarmCommand> validator,
                                    ILogger<UpdateFarmCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task<Farm?> GetEntityAsync(UpdateFarmCommand request, CancellationToken ct)
        => await Context.Farms.FindAsync([request.Id], ct);

    protected override async Task UpdateEntityProperties(Farm entity, UpdateFarmCommand request)
    {
        if (request.Name.HasValueAndIsDifferentFrom(entity.Name))
            entity.Name = request.Name!;
        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description;
        if (request.TotalArea.HasValueAndIsDifferentFrom(entity.TotalArea))
            entity.TotalArea = request.TotalArea!.Value;
        if (request.CultivableArea.HasValueAndIsDifferentFrom(entity.CultivableArea))
            entity.CultivableArea = request.CultivableArea!.Value;
        if (request.Location.IsDifferentFrom(entity.Location))
            entity.Location = request.Location!;
        if (request.Latitude.IsDifferentFrom(entity.Latitude))
            entity.Latitude = request.Latitude!;
        if (request.Longitude.IsDifferentFrom(entity.Longitude))
            entity.Longitude = request.Longitude!;
        if (request.FarmerId.HasValueAndIsDifferentFrom(entity.FarmerId))
            entity.FarmerId = request.FarmerId!;
        if (request.LicenseNumber.IsDifferentFrom(entity.LicenseNumber))
            entity.LicenseNumber = request.LicenseNumber!;
        if (request.Status.HasValueAndIsDifferentFrom(entity.Status))
            entity.Status = request.Status!.Value;
        if (request.EstablishedDate.IsDifferentFrom(entity.EstablishedDate))
            entity.EstablishedDate = request.EstablishedDate;
    }
}

public class UpdateFarmCommandValidator : AbstractValidator<UpdateFarmCommand>
{
    public UpdateFarmCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id nông trại"));
        RuleFor(x => x.Name)
            .MaximumLength(200)
            .When(x => !string.IsNullOrEmpty(x.Name))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên nông trại", 200));
        RuleFor(x => x.Description)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Description))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả nông trại", 500));
        RuleFor(x => x.TotalArea)
            .GreaterThanOrEqualTo(0)
            .When(x => x.TotalArea.HasValue).WithMessage(ErrorHelpers.GetErrorMinValue("Tổng diện tích nông trại", 0));
        RuleFor(x => x.CultivableArea)
            .GreaterThanOrEqualTo(0)
            .When(x => x.CultivableArea.HasValue).WithMessage(ErrorHelpers.GetErrorMinValue("Diện tích có thể canh tác", 0));
        RuleFor(x => x.Location)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Location))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Địa điểm / địa chỉ nông trại", 500));
        RuleFor(x => x.LicenseNumber)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.LicenseNumber))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số đăng ký / giấy phép nông trại", 100));
    }
}