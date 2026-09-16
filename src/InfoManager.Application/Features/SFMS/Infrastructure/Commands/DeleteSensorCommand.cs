namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

public record DeleteSensorCommand(string Id) : IRequest<Result>;

public class DeleteSensorCommandHandler : BaseDeleteCommandHandler<DeleteSensorCommand, Sensor>
{
    public DeleteSensorCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteSensorCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Sensor?> GetEntityAsync(DeleteSensorCommand request, CancellationToken ct)
        => await Context.Sensors.FindAsync([request.Id], ct);
}