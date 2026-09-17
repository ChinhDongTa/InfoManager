namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record UpdatePesticideCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? Name { get; init; }
    public string? ActiveIngredient { get; init; }
    public PesticideType? PesticideType { get; init; }
    public ToxicityLevel? ToxicityLevel { get; init; }
    public int? PreHarvestIntervalDays { get; init; }
    public string? Unit { get; init; }
    public string? Manufacturer { get; init; }
    public string? RegistrationNumber { get; init; }
    public bool? IsActive { get; init; }
    public string? Notes { get; init; }
}

public class UpdatePesticideCommandHandler : BaseUpdateCommandHandler<UpdatePesticideCommand, Pesticide>
{
    public UpdatePesticideCommandHandler(IApplicationDbContext context,
                                         IValidator<UpdatePesticideCommand> validator,
                                         ILogger<UpdatePesticideCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<Pesticide?> GetEntityAsync(UpdatePesticideCommand request, CancellationToken cancellationToken)
        => await Context.Pesticides.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(Pesticide entity, UpdatePesticideCommand request)
    {
        if (request.Name.HasValueAndIsDifferentFrom(entity.Name)) entity.Name = request.Name!;
        if (request.ActiveIngredient.IsDifferentFrom(entity.ActiveIngredient)) entity.ActiveIngredient = request.ActiveIngredient;
        if (request.PesticideType.HasValueAndIsDifferentFrom(entity.PesticideType)) entity.PesticideType = request.PesticideType!.Value;
        if (request.ToxicityLevel.HasValueAndIsDifferentFrom(entity.ToxicityLevel)) entity.ToxicityLevel = request.ToxicityLevel!.Value;
        if (request.PreHarvestIntervalDays.IsDifferentFrom(entity.PreHarvestIntervalDays)) entity.PreHarvestIntervalDays = request.PreHarvestIntervalDays;
        if (request.Unit.HasValueAndIsDifferentFrom(entity.Unit)) entity.Unit = request.Unit!;
        if (request.Manufacturer.IsDifferentFrom(entity.Manufacturer)) entity.Manufacturer = request.Manufacturer;
        if (request.RegistrationNumber.IsDifferentFrom(entity.RegistrationNumber)) entity.RegistrationNumber = request.RegistrationNumber;
        if (request.IsActive.HasValueAndIsDifferentFrom(entity.IsActive)) entity.IsActive = request.IsActive!.Value;
        if (request.Notes.IsDifferentFrom(entity.Notes)) entity.Notes = request.Notes;
        return Task.CompletedTask;
    }
}

public class UpdatePesticideCommandValidator : AbstractValidator<UpdatePesticideCommand>
{
    public UpdatePesticideCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID thuốc"));
        RuleFor(x => x.Name).NotEmpty().When(x => x.Name != null).WithMessage(ErrorHelpers.GetErrorRequired("Tên thuốc"))
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.Name)).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên thuốc", 200));
        RuleFor(x => x.ActiveIngredient).MaximumLength(200).When(x => x.ActiveIngredient != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Hoạt chất", 200));
        RuleFor(x => x.PreHarvestIntervalDays).GreaterThanOrEqualTo(0).When(x => x.PreHarvestIntervalDays.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Thời gian cách ly", 0));
        RuleFor(x => x.Unit).NotEmpty().When(x => x.Unit != null).WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(20).When(x => !string.IsNullOrEmpty(x.Unit)).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 20));
        RuleFor(x => x.Manufacturer).MaximumLength(200).When(x => x.Manufacturer != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nhà sản xuất", 200));
        RuleFor(x => x.RegistrationNumber).MaximumLength(100).When(x => x.RegistrationNumber != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số đăng ký", 100));
        RuleFor(x => x.Notes).MaximumLength(1000).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
    }
}