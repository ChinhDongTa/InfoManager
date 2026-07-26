namespace InfoManager.Application.Features.FamilyMembers.Commands;

public record DeleteFamilyMemberCommand(string Id) : IRequest<Result>;
public class DeleteFamilyMemberCommandHandler : BaseDeleteCommandHandler<DeleteFamilyMemberCommand, FamilyMember>
{
    public DeleteFamilyMemberCommandHandler(IApplicationDbContext context,
                                            ILogger<DeleteFamilyMemberCommandHandler> logger)
        : base(context, logger)
    {
    }
    protected override void DeleteEntity(FamilyMember entity, CancellationToken cancellationToken)
    {
        Context.FamilyMembers.Remove(entity);
    }
    protected override async Task<FamilyMember?> GetEntityAsync(DeleteFamilyMemberCommand request, CancellationToken cancellationToken)
    {
        return await Context.FamilyMembers.FindAsync([request.Id], cancellationToken);
    }
}