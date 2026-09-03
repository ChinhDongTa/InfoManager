namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

/// <summary>
/// Command tạo mới nông trại.
/// </summary>
public record CreateFarmCommand : IRequest<Result<string>>
{
    /// <summary>
    /// Tên nông trại. Bắt buộc. MaxLength: 200.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Mô tả nông trại. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Tổng diện tích nông trại (hecta). Bắt buộc.
    /// </summary>
    public required decimal TotalArea { get; init; }

    /// <summary>
    /// Diện tích có thể canh tác (hecta). Bắt buộc.
    /// </summary>
    public required decimal CultivableArea { get; init; }

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
    /// Chủ hộ sở hữu nông trại. Bắt buộc.
    /// </summary>
    public required string FarmerId { get; init; }

    /// <summary>
    /// Số đăng ký / giấy phép nông trại. Tùy chọn. MaxLength: 100.
    /// </summary>
    public string? LicenseNumber { get; init; }

    /// <summary>
    /// Trạng thái nông trại. Bắt buộc.
    /// </summary>
    public required FarmStatus Status { get; init; }

    /// <summary>
    /// Ngày bắt đầu hoạt động. Tùy chọn.
    /// </summary>
    public DateTimeOffset? EstablishedDate { get; init; }
}
public class CreateFarmCommandHandler : BaseCreateCommandHandler<CreateFarmCommand, Farm>
{
    public CreateFarmCommandHandler(IApplicationDbContext context, IValidator<CreateFarmCommand> validator, ILogger<CreateFarmCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task AddEntityAsync(Farm entity, CancellationToken cancellationToken)
        => await Context.Farms.AddAsync(entity, cancellationToken);

    protected override async Task<Farm> CreateEntity(CreateFarmCommand request) => new()
    {
        Name = request.Name,
        FarmerId = request.FarmerId,
        Description = request.Description,
        TotalArea = request.TotalArea,
        CultivableArea = request.CultivableArea,
        Location = request.Location,
        Latitude = request.Latitude,
        Longitude = request.Longitude,
        LicenseNumber = request.LicenseNumber,
        Status = request.Status,
        EstablishedDate = request.EstablishedDate
    };
}
public class CreateFarmCommandValidator : AbstractValidator<CreateFarmCommand>
{
    public CreateFarmCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .When(x => x.Description is not null);

        RuleFor(x => x.TotalArea)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.CultivableArea)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(x => x.TotalArea);

        RuleFor(x => x.Location)
            .MaximumLength(500)
            .When(x => x.Location is not null);

        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90)
            .When(x => x.Latitude.HasValue);

        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180)
            .When(x => x.Longitude.HasValue);

        RuleFor(x => x.FarmerId)
            .NotEmpty();

        RuleFor(x => x.LicenseNumber)
            .MaximumLength(100)
            .When(x => x.LicenseNumber is not null);

        RuleFor(x => x.Status)
            .IsInEnum();
    }
}