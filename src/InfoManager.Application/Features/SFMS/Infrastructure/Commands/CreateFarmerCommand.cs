namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

/// <summary>
/// Command tạo hồ sơ chủ hộ / chủ trang trại.
/// </summary>
public record CreateFarmerCommand : IRequest<Result<string>>
{
    /// <summary>
    /// ID tài khoản đăng nhập. Bắt buộc. Unique: 1 User tối đa 1 Farmer.
    /// </summary>
    public required string UserId { get; init; }

    /// <summary>
    /// Họ tên chủ hộ. Bắt buộc. MaxLength: 200.
    /// </summary>
    public required string FullName { get; init; }

    /// <summary>
    /// ID thành viên gia đình. Tùy chọn.
    /// </summary>
    public string? FamilyMemberId { get; init; }

    /// <summary>
    /// Mã chủ hộ / mã nông dân. Tùy chọn. MaxLength: 50. Để trống thì server tự sinh.
    /// </summary>
    public string? FarmerCode { get; init; }

    /// <summary>
    /// Số điện thoại. Tùy chọn. MaxLength: 20.
    /// </summary>
    public string? Phone { get; init; }

    /// <summary>
    /// Email liên hệ nghiệp vụ. Tùy chọn. MaxLength: 200. Format: Email.
    /// </summary>
    public string? Email { get; init; }

    /// <summary>
    /// CCCD / CMND. Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? IdentityNumber { get; init; }

    /// <summary>
    /// Địa chỉ thường trú / liên hệ. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Address { get; init; }

    /// <summary>
    /// Ghi chú. Tùy chọn. MaxLength: 500.
    /// </summary>
    public string? Notes { get; init; }
}

public class CreateFarmerCommandHandler : BaseCreateCommandHandler<CreateFarmerCommand, Farmer>
{
    public CreateFarmerCommandHandler(IApplicationDbContext context,
                                      IValidator<CreateFarmerCommand> validator,
                                      ILogger<CreateFarmerCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task AddEntityAsync(Farmer entity, CancellationToken cancellationToken)
        => await Context.Farmers.AddAsync(entity, cancellationToken);

    protected override async Task<Farmer> CreateEntity(CreateFarmerCommand request)
    {
        return new Farmer
        {
            UserId = request.UserId,
            FullName = request.FullName,
            FamilyMemberId = request.FamilyMemberId,
            FarmerCode = request.FarmerCode,
            Phone = request.Phone,
            Email = request.Email,
            IdentityNumber = request.IdentityNumber,
            Address = request.Address,
            Notes = request.Notes
        };
    }
}

public class CreateFarmerCommandValidator : AbstractValidator<CreateFarmerCommand>
{
    public CreateFarmerCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("UserId"));
        RuleFor(x => x.FullName).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("FullName"))
                                .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.FullName)).WithMessage(ErrorHelpers.GetErrorMaxLength("FullName", 200));
        RuleFor(x => x.FarmerCode).MaximumLength(50).When(x => !string.IsNullOrEmpty(x.FarmerCode)).WithMessage(ErrorHelpers.GetErrorMaxLength("FarmerCode", 50));
        RuleFor(x => x.Phone).MaximumLength(20).When(x => !string.IsNullOrEmpty(x.Phone)).WithMessage(ErrorHelpers.GetErrorMaxLength("Phone", 20));
        RuleFor(x => x.Email).MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Email", 200))
                             .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email)).WithMessage(ErrorHelpers.GetErrorInvalid("Email"));
        RuleFor(x => x.IdentityNumber).MaximumLength(50).When(x => !string.IsNullOrEmpty(x.IdentityNumber)).WithMessage(ErrorHelpers.GetErrorMaxLength("IdentityNumber", 50));
        RuleFor(x => x.Address).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Address)).WithMessage(ErrorHelpers.GetErrorMaxLength("Address", 500));
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes)).WithMessage(ErrorHelpers.GetErrorMaxLength("Notes", 500));
    }
}