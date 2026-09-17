namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record CreatePesticideCommand : IRequest<Result<string>>
{
    public required string Name { get; init; }
    public string? ActiveIngredient { get; init; }
    public required PesticideType PesticideType { get; init; }
    public required ToxicityLevel ToxicityLevel { get; init; }
    public int? PreHarvestIntervalDays { get; init; }
    public required string Unit { get; init; }
    public string? Manufacturer { get; init; }
    public string? RegistrationNumber { get; init; }
    public required bool IsActive { get; init; }
    public string? Notes { get; init; }
}

public class CreatePesticideCommandHandler : BaseCreateCommandHandler<CreatePesticideCommand, Pesticide>
{
    public CreatePesticideCommandHandler(IApplicationDbContext context,
                                         IValidator<CreatePesticideCommand> validator,
                                         ILogger<CreatePesticideCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(Pesticide entity, CancellationToken cancellationToken)
        => await Context.Pesticides.AddAsync(entity, cancellationToken);

    protected override Task<Pesticide> CreateEntity(CreatePesticideCommand request)
        => Task.FromResult(new Pesticide
        {
            Name = request.Name,
            ActiveIngredient = request.ActiveIngredient,
            PesticideType = request.PesticideType,
            ToxicityLevel = request.ToxicityLevel,
            PreHarvestIntervalDays = request.PreHarvestIntervalDays,
            Unit = request.Unit,
            Manufacturer = request.Manufacturer,
            RegistrationNumber = request.RegistrationNumber,
            IsActive = request.IsActive,
            Notes = request.Notes
        });
}

public class CreatePesticideCommandValidator : AbstractValidator<CreatePesticideCommand>
{
    public CreatePesticideCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên thuốc"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên thuốc", 200));
        RuleFor(x => x.ActiveIngredient).MaximumLength(200).When(x => !string.IsNullOrEmpty(x.ActiveIngredient))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Hoạt chất", 200));
        RuleFor(x => x.PreHarvestIntervalDays).GreaterThanOrEqualTo(0).When(x => x.PreHarvestIntervalDays.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Thời gian cách ly", 0));
        RuleFor(x => x.Unit).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(20).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 20));
        RuleFor(x => x.Manufacturer).MaximumLength(200).When(x => !string.IsNullOrEmpty(x.Manufacturer))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nhà sản xuất", 200));
        RuleFor(x => x.RegistrationNumber).MaximumLength(100).When(x => !string.IsNullOrEmpty(x.RegistrationNumber))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Số đăng ký", 100));
        RuleFor(x => x.Notes).MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 1000));
    }
}