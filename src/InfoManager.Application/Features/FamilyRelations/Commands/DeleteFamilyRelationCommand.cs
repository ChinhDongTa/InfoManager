namespace InfoManager.Application.Features.FamilyRelations.Commands;

public record DeleteFamilyRelationCommand(string Id) : IRequest<Result>;
public class DeleteFamilyRelationCommandHandler : BaseDeleteCommandHandler<DeleteFamilyRelationCommand, FamilyRelation>
{
    public DeleteFamilyRelationCommandHandler(IApplicationDbContext context,
                                              ILogger<DeleteFamilyRelationCommandHandler> logger)
        : base(context, logger)
    {
    }
    protected override void DeleteEntity(FamilyRelation entity, CancellationToken cancellationToken)
    {
        Context.FamilyRelations.Remove(entity);
    }
    protected override async Task<FamilyRelation?> GetEntityAsync(DeleteFamilyRelationCommand request, CancellationToken cancellationToken)
    {
        return await Context.FamilyRelations.FindAsync([request.Id], cancellationToken);
    }
}