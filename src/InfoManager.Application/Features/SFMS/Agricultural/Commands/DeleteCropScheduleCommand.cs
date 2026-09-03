namespace InfoManager.Application.Features.SFMS.Agricultural.Commands;

public record DeleteCropScheduleCommand(string Id) : IRequest<Result>;
public class DeleteCropScheduleCommandHandler : BaseDeleteCommandHandler<DeleteCropScheduleCommand, CropSchedule>
{
    public DeleteCropScheduleCommandHandler(IApplicationDbContext context, ILogger<DeleteCropScheduleCommandHandler> logger)
        : base(context, logger)
    {
    }
    protected override async Task<CropSchedule?> GetEntityAsync(DeleteCropScheduleCommand request, CancellationToken cancellationToken)
    {
        return await Context.CropSchedules.FindAsync([request.Id], cancellationToken);
    }
    
}