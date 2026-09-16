namespace InfoManager.Application.Features.FamilyEvents.Commands;

public record DeleteFamilyEventCommand(string Id) : IRequest<Result>;

public class DeleteFamilyEventCommandHandler : BaseDeleteCommandHandler<DeleteFamilyEventCommand, FamilyEvent>
{
    public DeleteFamilyEventCommandHandler(IApplicationDbContext context,
                                            ILogger<DeleteFamilyEventCommandHandler> logger)
        : base(context, logger)
    {
    }

    protected override async Task<FamilyEvent?> GetEntityAsync(DeleteFamilyEventCommand request, CancellationToken ct)
    {
        return await Context.FamilyEvents.FindAsync([request.Id], ct);
    }
}