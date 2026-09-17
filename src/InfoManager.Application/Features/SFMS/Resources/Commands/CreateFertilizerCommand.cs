namespace InfoManager.Application.Features.SFMS.Resources.Commands;

public record CreateFertilizerCommand : IRequest<Result<string>>
{
    public required string Name { get; init; }
    public required FertilizerType FertilizerType { get; init; }
    public decimal? NitrogenPercent { get; init; }
    public decimal? PhosphorusPercent { get; init; }
    public decimal? PotassiumPercent { get; init; }
    public required string Unit { get; init; }
    public string? Manufacturer { get; init; }
    public required bool IsActive { get; init; }
    public string? Notes { get; init; }
}

public class CreateFertilizerCommandHandler : BaseCreateCommandHandler<CreateFertilizerCommand, Fertilizer>
{
    public CreateFertilizerCommandHandler(IApplicationDbContext context,
                                          IValidator<CreateFertilizerCommand> validator,
                                          ILogger<CreateFertilizerCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(Fertilizer entity, CancellationToken cancellationToken)
        => await Context.Fertilizers.AddAsync(entity, cancellationToken);

    protected override Task<Fertilizer> CreateEntity(CreateFertilizerCommand request)
        => Task.FromResult(new Fertilizer
        {
            Name = request.Name,
            FertilizerType = request.FertilizerType,
            NitrogenPercent = request.NitrogenPercent,
            PhosphorusPercent = request.PhosphorusPercent,
            PotassiumPercent = request.PotassiumPercent,
            Unit = request.Unit,
            Manufacturer = request.Manufacturer,
            IsActive = request.IsActive,
            Notes = request.Notes
        });
}

public class CreateFertilizerCommandValidator : AbstractValidator<CreateFertilizerCommand>
{
    public CreateFertilizerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên phân bón"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên phân bón", 200));
        RuleFor(x => x.Unit).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(20).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 20));
        RuleFor(x => x.NitrogenPercent).InclusiveBetween(0, 100).When(x => x.NitrogenPercent.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Hàm lượng N", 0, 100));
        RuleFor(x => x.PhosphorusPercent).InclusiveBetween(0, 100).When(x => x.PhosphorusPercent.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Hàm lượng P", 0, 100));
        RuleFor(x => x.PotassiumPercent).InclusiveBetween(0, 100).When(x => x.PotassiumPercent.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Hàm lượng K", 0, 100));
        RuleFor(x => x.Manufacturer).MaximumLength(200).When(x => !string.IsNullOrEmpty(x.Manufacturer))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nhà sản xuất", 200));
        RuleFor(x => x.Notes).MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}

public record UpdateFertilizerCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? Name { get; init; }
    public FertilizerType? FertilizerType { get; init; }
    public decimal? NitrogenPercent { get; init; }
    public decimal? PhosphorusPercent { get; init; }
    public decimal? PotassiumPercent { get; init; }
    public string? Unit { get; init; }
    public string? Manufacturer { get; init; }
    public bool? IsActive { get; init; }
    public string? Notes { get; init; }
}

public class UpdateFertilizerCommandHandler : BaseUpdateCommandHandler<UpdateFertilizerCommand, Fertilizer>
{
    public UpdateFertilizerCommandHandler(IApplicationDbContext context,
                                          IValidator<UpdateFertilizerCommand> validator,
                                          ILogger<UpdateFertilizerCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<Fertilizer?> GetEntityAsync(UpdateFertilizerCommand request, CancellationToken cancellationToken)
        => await Context.Fertilizers.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(Fertilizer entity, UpdateFertilizerCommand request)
    {
        if (request.Name.HasValueAndIsDifferentFrom(entity.Name)) entity.Name = request.Name!;
        if (request.FertilizerType.HasValueAndIsDifferentFrom(entity.FertilizerType)) entity.FertilizerType = request.FertilizerType!.Value;
        if (request.NitrogenPercent.IsDifferentFrom(entity.NitrogenPercent)) entity.NitrogenPercent = request.NitrogenPercent;
        if (request.PhosphorusPercent.IsDifferentFrom(entity.PhosphorusPercent)) entity.PhosphorusPercent = request.PhosphorusPercent;
        if (request.PotassiumPercent.IsDifferentFrom(entity.PotassiumPercent)) entity.PotassiumPercent = request.PotassiumPercent;
        if (request.Unit.HasValueAndIsDifferentFrom(entity.Unit)) entity.Unit = request.Unit!;
        if (request.Manufacturer.IsDifferentFrom(entity.Manufacturer)) entity.Manufacturer = request.Manufacturer;
        if (request.IsActive.HasValueAndIsDifferentFrom(entity.IsActive)) entity.IsActive = request.IsActive!.Value;
        if (request.Notes.IsDifferentFrom(entity.Notes)) entity.Notes = request.Notes;
        return Task.CompletedTask;
    }
}

public class UpdateFertilizerCommandValidator : AbstractValidator<UpdateFertilizerCommand>
{
    public UpdateFertilizerCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID phân bón"));
        RuleFor(x => x.Name).NotEmpty().When(x => x.Name != null).WithMessage(ErrorHelpers.GetErrorRequired("Tên phân bón"))
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.Name)).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên phân bón", 200));
        RuleFor(x => x.Unit).NotEmpty().When(x => x.Unit != null).WithMessage(ErrorHelpers.GetErrorRequired("Đơn vị"))
            .MaximumLength(20).When(x => !string.IsNullOrEmpty(x.Unit)).WithMessage(ErrorHelpers.GetErrorMaxLength("Đơn vị", 20));
        RuleFor(x => x.NitrogenPercent).InclusiveBetween(0, 100).When(x => x.NitrogenPercent.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Hàm lượng N", 0, 100));
        RuleFor(x => x.PhosphorusPercent).InclusiveBetween(0, 100).When(x => x.PhosphorusPercent.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Hàm lượng P", 0, 100));
        RuleFor(x => x.PotassiumPercent).InclusiveBetween(0, 100).When(x => x.PotassiumPercent.HasValue)
            .WithMessage(ErrorHelpers.GetErrorOutOfRange("Hàm lượng K", 0, 100));
        RuleFor(x => x.Manufacturer).MaximumLength(200).When(x => x.Manufacturer != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Nhà sản xuất", 200));
        RuleFor(x => x.Notes).MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}