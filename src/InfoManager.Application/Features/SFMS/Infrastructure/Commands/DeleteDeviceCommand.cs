namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

public record DeleteDeviceCommand(string Id) : IRequest<Result>;
public class DeleteDeviceCommandHandler : BaseDeleteCommandHandler<DeleteDeviceCommand, Device>
{
    public DeleteDeviceCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteDeviceCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Device?> GetEntityAsync(DeleteDeviceCommand request, CancellationToken cancellationToken)
        => await Context.Devices.FindAsync([request.Id], cancellationToken);
}