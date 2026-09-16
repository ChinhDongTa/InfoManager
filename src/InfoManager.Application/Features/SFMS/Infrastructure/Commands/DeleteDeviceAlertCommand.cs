namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

public record DeleteDeviceAlertCommand(string Id) : IRequest<Result>;

public class DeleteDeviceAlertCommandHandler : BaseDeleteCommandHandler<DeleteDeviceAlertCommand, DeviceAlert>
{
    public DeleteDeviceAlertCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteDeviceAlertCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<DeviceAlert?> GetEntityAsync(DeleteDeviceAlertCommand request, CancellationToken ct)
        => await Context.DeviceAlerts.FindAsync([request.Id], ct);
}