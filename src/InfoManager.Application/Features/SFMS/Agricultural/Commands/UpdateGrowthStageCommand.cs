namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record UpdateGrowthStageCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? StageName { get; init; }
    public string? CropId { get; init; }
    public string? CropScheduleId { get; init; }
    public int? StageSequence { get; init; }
    public int? DaysAfterPlanting { get; init; }
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
public class UpdateGrowthStageCommandHandler : BaseUpdateCommandHandler<UpdateGrowthStageCommand, GrowthStage>
{
    public UpdateGrowthStageCommandHandler(IApplicationDbContext context, IValidator<UpdateGrowthStageCommand> validator, ILogger<UpdateGrowthStageCommandHandler> logger) :
       base(context, validator, logger)
    { }
    protected override async Task<GrowthStage?> GetEntityAsync(UpdateGrowthStageCommand request, CancellationToken cancellationToken)
    {
        return await Context.GrowthStages.FindAsync(request.Id,cancellationToken);
    }

    protected override async Task UpdateEntityProperties(GrowthStage entity, UpdateGrowthStageCommand request)
    {
        //Đối với các trường required thì kiểm tra (HasValueAndIsDifferentFrom(entity.Property)) request có gia trị không, nếu có thì só sánh với entity trước khi thực hiện phép gán.
        //Đối với các trường nullable thì chỉ cần so sánh khác => IsDifferentFrom(entity.Property)
        if (request.StageName.HasValueAndIsDifferentFrom(entity.StageName))
            entity.StageName = request.StageName!;
        if (request.CropId.HasValueAndIsDifferentFrom(entity.CropId))
            entity.StageName = request.StageName!;
        if (request.CropScheduleId.IsDifferentFrom(entity.CropId))
            entity.CropScheduleId = request.CropScheduleId!;
        if (request.StageSequence.HasValueAndIsDifferentFrom(entity.StageSequence))
            entity.StageSequence = request.StageSequence!.Value;
        if (request.DaysAfterPlanting.HasValueAndIsDifferentFrom(entity.DaysAfterPlanting))
            entity.DaysAfterPlanting = request.DaysAfterPlanting!.Value;
        if (request.StageDuration.IsDifferentFrom(entity.StageDuration))
            entity.StageDuration = request.StageDuration!;
        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description!;
        if (request.MinTemperature.IsDifferentFrom(entity.MinTemperature))
            entity.MinTemperature = request.MinTemperature!;
        if (request.MaxTemperature.IsDifferentFrom(entity.MaxTemperature))
            entity.MaxTemperature = request.MaxTemperature!;
        if (request.MinHumidity.IsDifferentFrom(entity.MinHumidity))
            entity.MinHumidity = request.MinHumidity!;
        if (request.MaxHumidity.IsDifferentFrom(entity.MaxHumidity))
            entity.MaxHumidity = request.MaxHumidity!;
        if (request.WaterRequirement.IsDifferentFrom(entity.WaterRequirement))
            entity.WaterRequirement  = request.WaterRequirement!;
        if (request.NitrogenRequirement.IsDifferentFrom(entity.NitrogenRequirement))
            entity.NitrogenRequirement = request.NitrogenRequirement!;
        if (request.PhosphorusRequirement.IsDifferentFrom(entity.PhosphorusRequirement))
            entity.PhosphorusRequirement = request.PhosphorusRequirement!;
        if (request.PotassiumRequirement.IsDifferentFrom(entity.PotassiumRequirement))
            entity.PotassiumRequirement = request.PotassiumRequirement!;
        if (request.CommonPests.IsDifferentFrom(entity.CommonPests))
            entity.CommonPests = request.CommonPests!;
        if (request.CommonDiseases.IsDifferentFrom(entity.CommonDiseases))
            entity.CommonDiseases = request.CommonDiseases!;
        if (request.ManagementActivities.IsDifferentFrom(entity.ManagementActivities))
            entity.ManagementActivities = request.ManagementActivities!;
    }
}
public class UpdateGrowthStageCommandValidator : AbstractValidator<UpdateGrowthStageCommand>
{
    public UpdateGrowthStageCommandValidator()
    {
        
    }
}
