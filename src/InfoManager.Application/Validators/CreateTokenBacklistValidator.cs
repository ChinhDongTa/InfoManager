using InfoManager.Shared.Dtos.TokenBlacklists;

namespace InfoManager.Application.Validators;

public class CreateTokenBacklistValidator : AbstractValidator<CreateTokenBlacklistDto>
{
    public CreateTokenBacklistValidator()
    {
        RuleFor(x => x.Jti).NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Jti"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Jti", 200));
        RuleFor(x => x.UserIdOfToken).NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("UserIdOfToken"))
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("UserIdOfToken", 100));
    }
}