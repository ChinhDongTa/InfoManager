namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record CreateGrowthStageAlertCommand : IRequest<Result<string>>
{
    public required string CropPlantingId { get; init; }
    public required string GrowthStageId { get; init; }
    public required GrowthAlertType AlertType { get; init; }
    public required string Message { get; init; }
    public required AlertSeverity Severity { get; init; }
    public required DateTimeOffset AlertTime { get; init; }
    public DateTimeOffset? ExpectedAchievementDate { get; init; }
    public DateTimeOffset? ActualAchievementDate { get; init; }
    public bool IsResolved { get; init; }
    public string? ActionTaken { get; init; }
}

public class CreateGrowthStageAlertCommandHandler : BaseCreateCommandHandler<CreateGrowthStageAlertCommand, GrowthStageAlert>
{
    public CreateGrowthStageAlertCommandHandler(IApplicationDbContext context,
                                                IValidator<CreateGrowthStageAlertCommand> validator,
                                                ILogger<CreateGrowthStageAlertCommandHandler> logger) : base(context, validator, logger)
    {
    }

    protected override async Task AddEntityAsync(GrowthStageAlert entity, CancellationToken ct)
    {
        await Context.GrowthStageAlerts.AddAsync(entity, ct);
    }

    protected override async Task<GrowthStageAlert> CreateEntity(CreateGrowthStageAlertCommand request)
    {
        return new GrowthStageAlert
        {
            CropPlantingId = request.CropPlantingId,
            GrowthStageId = request.GrowthStageId,
            AlertType = request.AlertType,
            Message = request.Message,
            Severity = request.Severity,
            AlertTime = request.AlertTime,
            ExpectedAchievementDate = request.ExpectedAchievementDate,
            ActualAchievementDate = request.ActualAchievementDate,
            IsResolved = request.IsResolved,
            ActionTaken = request.ActionTaken
        };
    }
}

public class CreateGrowthStageAlertCommandValidator : AbstractValidator<CreateGrowthStageAlertCommand>
{
    public CreateGrowthStageAlertCommandValidator()
    {
        RuleFor(x => x.CropPlantingId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã lần trồng cây"));
        RuleFor(x => x.GrowthStageId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã giai đoạn sinh trưởng"));
        RuleFor(x => x.Message)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Nội dung cảnh báo"))
            .MaximumLength(500).WithMessage(ErrorHelpers.GetErrorMaxLength("Nội dung cảnh báo", 500));
        RuleFor(x => x.AlertTime)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Thời điểm cảnh báo"));
    }
}