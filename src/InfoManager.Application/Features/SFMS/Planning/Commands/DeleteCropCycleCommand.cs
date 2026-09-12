namespace InfoManager.Application.Features.SFMS.Planning.Commands;

public record DeleteCropCycleCommand(string Id) : IRequest<Result>;
public class DeleteCropCycleCommandHandler : BaseDeleteCommandHandler<DeleteCropCycleCommand, CropCycle>
{
    public DeleteCropCycleCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteCropCycleCommandHandler> logger) : base(context, logger)
    {
    }
    protected override async Task<CropCycle?> GetEntityAsync(DeleteCropCycleCommand request, CancellationToken cancellationToken)
  => await Context.CropCycles.FindAsync(request, cancellationToken);
}
