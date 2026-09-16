namespace InfoManager.Application.Features.FamilyRelations.Commands;

public record DeleteFamilyRelationCommand(string Id) : IRequest<Result>;

public class DeleteFamilyRelationCommandHandler : BaseDeleteCommandHandler<DeleteFamilyRelationCommand, FamilyRelation>
{
    public DeleteFamilyRelationCommandHandler(IApplicationDbContext context,
                                              ILogger<DeleteFamilyRelationCommandHandler> logger)
        : base(context, logger)
    {
    }

    protected override async Task<FamilyRelation?> GetEntityAsync(DeleteFamilyRelationCommand request, CancellationToken ct)
    {
        return await Context.FamilyRelations.FindAsync([request.Id], ct);
    }
}