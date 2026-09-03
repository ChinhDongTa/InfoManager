namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record CreateGrowthStageCommand : IRequest<Result<string>>
{
    public required string StageName { get; init; }
    public required string CropId { get; init; }
    public string? CropScheduleId { get; init; }
    public required int StageSequence { get; init; }
    public required int DaysAfterPlanting { get; init; }
    public int? StageDuration { get; init; }
    public string? Description { get; init; }
    public decimal? MinTemperature { get; init; }
    public decimal? MaxTemperature { get; init; }
    public decimal? MinHumidity { get; init; }
    public decimal? MaxHumidity { get; init; }
    public decimal? WaterRequirement { get; init; }
    public decimal? NitrogenRequirement { get; init; }
    public decimal? PhosphorusRequirement { get; init; }
    public decimal? PotassiumRequirement { get; init; }
    public string? CommonPests { get; init; }
    public string? CommonDiseases { get; init; }
    public string? ManagementActivities { get; init; }
}
public class CreateGrowthStageCommandHandler : BaseCreateCommandHandler<CreateGrowthStageCommand, GrowthStage>
{
    public CreateGrowthStageCommandHandler(IApplicationDbContext context,
                                           IValidator<CreateGrowthStageCommand> validator,
                                           ILogger<CreateGrowthStageCommandHandler> logger) :base(context, validator, logger)
    {
        
    }
    protected override async Task AddEntityAsync(GrowthStage entity, CancellationToken cancellationToken)
    {
        await Context.GrowthStages.AddAsync(entity, cancellationToken);
    }

    protected override async Task<GrowthStage> CreateEntity(CreateGrowthStageCommand request)
    {
        return new GrowthStage
        {
            StageName = request.StageName,
            CropId=request.CropId,
            CropScheduleId=request.CropScheduleId,
            StageSequence=request.StageSequence,
            DaysAfterPlanting=request.DaysAfterPlanting,
            StageDuration=request.StageDuration,
            Description=request.Description,
            MinTemperature=request.MinTemperature,
            MaxTemperature=request.MaxTemperature,
            MinHumidity=request.MinHumidity,
            MaxHumidity=request.MaxHumidity,
            WaterRequirement=request.WaterRequirement,
            NitrogenRequirement=request.NitrogenRequirement,
            PhosphorusRequirement=request.PhosphorusRequirement,
            PotassiumRequirement=request.PotassiumRequirement,
            CommonPests=request.CommonPests,
            CommonDiseases=request.CommonDiseases,
            ManagementActivities=request.ManagementActivities
        };
    }
}
public class CreateGrowthStageCommandValidator: AbstractValidator<CreateGrowthStageCommand>
{
    public CreateGrowthStageCommandValidator()
    {
        
    }
}