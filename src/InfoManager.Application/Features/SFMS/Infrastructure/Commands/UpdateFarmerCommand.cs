namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

/// <summary>
/// Command cập nhật hồ sơ chủ hộ.
/// Chỉ Id là bắt buộc; các trường còn lại nullable (chỉ cập nhật khi có giá trị).
/// UserId không cho đổi qua update.
/// </summary>
public record UpdateFarmerCommand : IRequest<Result>
{
    /// <summary>
    /// ID hồ sơ chủ hộ. Bắt buộc. Truyền từ client (route).
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// ID thành viên gia đình. Tùy chọn.
    /// </summary>
    public string? FamilyMemberId { get; init; }

    /// <summary>
    /// Mã chủ hộ / mã nông dân. Tùy chọn. MaxLength: 50.
    /// </summary>
    public string? FarmerCode { get; init; }

    /// <summary>
    /// Họ tên chủ hộ. Tùy chọn. MaxLength: 200.
    /// </summary>
    public string? FullName { get; init; }

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

public class UpdateFarmerCommandHandler : BaseUpdateCommandHandler<UpdateFarmerCommand, Farmer>
{
    public UpdateFarmerCommandHandler(IApplicationDbContext context,
                                      IValidator<UpdateFarmerCommand> validator,
                                      ILogger<UpdateFarmerCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task<Farmer?> GetEntityAsync(UpdateFarmerCommand request, CancellationToken ct)
        => await Context.Farmers.FindAsync([request.Id], ct);

    protected override async Task UpdateEntityProperties(Farmer entity, UpdateFarmerCommand request)
    {
        if (request.FullName.HasValueAndIsDifferentFrom(entity.FullName))
        {
            entity.FullName = request.FullName!;
        }
        if (request.FamilyMemberId.IsDifferentFrom(entity.FamilyMemberId))
        {
            entity.FamilyMemberId = request.FamilyMemberId;
        }
        if (request.FarmerCode.IsDifferentFrom(entity.FarmerCode))
        {
            entity.FarmerCode = request.FarmerCode;
        }
        if (request.Phone.IsDifferentFrom(entity.Phone))
        {
            entity.Phone = request.Phone;
        }
        if (request.Email.IsDifferentFrom(entity.Email))
        {
            entity.Email = request.Email;
        }
        if (request.IdentityNumber.IsDifferentFrom(entity.IdentityNumber))
        {
            entity.IdentityNumber = request.IdentityNumber;
        }
        if (request.Address.IsDifferentFrom(entity.Address))
        {
            entity.Address = request.Address;
        }
        if (request.Notes.IsDifferentFrom(entity.Notes))
        {
            entity.Notes = request.Notes;
        }
    }
}

public class UpdateFarmerCommandValidator : AbstractValidator<UpdateFarmerCommand>
{
    public UpdateFarmerCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty()
                          .WithMessage(ErrorHelpers.GetErrorRequired("Id"));
        RuleFor(x => x.FullName).MaximumLength(200)
                                .When(x => !string.IsNullOrEmpty(x.FullName))
                                .WithMessage(ErrorHelpers.GetErrorMaxLength("FullName", 200));
        RuleFor(x => x.FarmerCode).MaximumLength(50)
                                  .When(x => !string.IsNullOrEmpty(x.FarmerCode))
                                  .WithMessage(ErrorHelpers.GetErrorMaxLength("FarmerCode", 50));
        RuleFor(x => x.Phone).MaximumLength(20)
                             .When(x => !string.IsNullOrEmpty(x.Phone))
                             .WithMessage(ErrorHelpers.GetErrorMaxLength("Phone", 20));
        RuleFor(x => x.Email).MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Email", 200))
                             .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email)).WithMessage(ErrorHelpers.GetErrorInvalid("Email"));
        RuleFor(x => x.IdentityNumber).MaximumLength(50)
                                      .When(x => !string.IsNullOrEmpty(x.IdentityNumber))
                                      .WithMessage(ErrorHelpers.GetErrorMaxLength("IdentityNumber", 50));
        RuleFor(x => x.Address).MaximumLength(500)
                               .When(x => !string.IsNullOrEmpty(x.Address))
                               .WithMessage(ErrorHelpers.GetErrorMaxLength("Address", 500));
        RuleFor(x => x.Notes).MaximumLength(500)
                             .When(x => !string.IsNullOrEmpty(x.Notes))
                                .WithMessage(ErrorHelpers.GetErrorMaxLength("Notes", 500));
    }
}