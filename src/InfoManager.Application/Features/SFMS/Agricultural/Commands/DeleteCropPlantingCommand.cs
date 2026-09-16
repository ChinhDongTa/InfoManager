namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record DeleteCropPlantingCommand(string Id) : IRequest<Result>;

public class DeleteCropPlantingCommandHandler : BaseDeleteCommandHandler<DeleteCropPlantingCommand, CropPlanting>
{
    public DeleteCropPlantingCommandHandler(IApplicationDbContext context, ILogger<DeleteCropPlantingCommandHandler> logger) : base(context, logger)
    { }

    protected override async Task<CropPlanting?> GetEntityAsync(DeleteCropPlantingCommand request, CancellationToken ct)
    {
        return await Context.CropPlantings.FindAsync([request.Id], ct);
    }
}