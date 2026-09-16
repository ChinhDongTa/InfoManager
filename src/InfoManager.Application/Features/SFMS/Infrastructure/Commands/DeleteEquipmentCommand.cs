namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

public record DeleteEquipmentCommand(string Id) : IRequest<Result>;

public class DeleteEquipmentCommandHandler : BaseDeleteCommandHandler<DeleteEquipmentCommand, Equipment>
{
    public DeleteEquipmentCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteEquipmentCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Equipment?> GetEntityAsync(DeleteEquipmentCommand request, CancellationToken ct)
        => await Context.Equipments.FindAsync([request.Id], ct);
}