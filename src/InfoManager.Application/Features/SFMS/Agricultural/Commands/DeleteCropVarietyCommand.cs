namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record DeleteCropVarietyCommand(string Id) : IRequest<Result>;
public class DeleteCropVarietyCommandHandler : BaseDeleteCommandHandler<DeleteCropVarietyCommand, CropVariety>
{
    public DeleteCropVarietyCommandHandler(IApplicationDbContext context, ILogger<DeleteCropVarietyCommandHandler> logger) : base(context, logger)
    {
    }
    protected override async Task<CropVariety?> GetEntityAsync(DeleteCropVarietyCommand request, CancellationToken cancellationToken)
    {
        return await Context.CropVarieties.FindAsync([request.Id], cancellationToken);
    }
}