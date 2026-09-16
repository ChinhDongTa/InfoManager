namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record DeleteCropCommand(string Id) : IRequest<Result>;

public class DeleteCropCommandHandler : BaseDeleteCommandHandler<DeleteCropCommand, Crop>
{
    public DeleteCropCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteCropCommandHandler> logger)
        : base(context, logger)
    {
    }

    protected override async Task<Crop?> GetEntityAsync(DeleteCropCommand request, CancellationToken ct)
    {
        return await Context.Crops.FindAsync([request.Id], ct);
    }
}