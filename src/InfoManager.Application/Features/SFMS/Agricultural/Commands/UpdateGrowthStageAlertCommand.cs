namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;
public record UpdateGrowthStageAlertCommand : IRequest<Result>
{
    public  required string Id { get; init; } 
    public GrowthAlertType? AlertType { get; init; }
    public string? Message { get; init; }
    public AlertSeverity? Severity { get; init; }
    public DateTimeOffset? ExpectedAchievementDate { get; init; }
    public DateTimeOffset? ActualAchievementDate { get; init; }
    public bool? IsResolved { get; init; }
    public string? ActionTaken { get; init; }
}
public class UpdateteGrowthStageAlertCommandHandler : BaseUpdateCommandHandler<UpdateGrowthStageAlertCommand, GrowthStageAlert>
{
    public UpdateteGrowthStageAlertCommandHandler(IApplicationDbContext context, IValidator<UpdateGrowthStageAlertCommand> validator, ILogger<UpdateteGrowthStageAlertCommandHandler> logger) : base(context, validator, logger)
    {
    }
    protected override async Task<GrowthStageAlert?> GetEntityAsync(UpdateGrowthStageAlertCommand request, CancellationToken cancellationToken)
    {
        return await Context.GrowthStageAlerts.FindAsync([request.Id], cancellationToken);
    }
    protected override async Task UpdateEntityProperties(GrowthStageAlert entity, UpdateGrowthStageAlertCommand request)
    {
        if (request.AlertType.HasValue && request.AlertType != entity.AlertType)
            entity.AlertType = request.AlertType.Value;
        if (request.Message.HasValueAndIsDifferentFrom(entity.Message))
            entity.Message = request.Message!;
        if (request.Severity.HasValue && request.Severity != entity.Severity)
            entity.Severity = request.Severity.Value;
        if (request.ExpectedAchievementDate.IsDifferentFrom(entity.ExpectedAchievementDate))
            entity.ExpectedAchievementDate = request.ExpectedAchievementDate;
        if (request.ActualAchievementDate.IsDifferentFrom(entity.ActualAchievementDate))
            entity.ActualAchievementDate = request.ActualAchievementDate;
        if (request.IsResolved.HasValue && request.IsResolved != entity.IsResolved)
            entity.IsResolved = request.IsResolved.Value;
        if (request.ActionTaken.IsDifferentFrom(entity.ActionTaken))
            entity.ActionTaken = request.ActionTaken!;
    }
}
public class UpdateteGrowthStageAlertCommandValidator : AbstractValidator<UpdateGrowthStageAlertCommand>
{
    public UpdateteGrowthStageAlertCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Mã cảnh báo giai đoạn sinh trưởng"));
        RuleFor(x => x.Message)
            .MaximumLength(500).When(x => x.Message != null).WithMessage(ErrorHelpers.GetErrorMaxLength("Nội dung cảnh báo", 500));
    }
}