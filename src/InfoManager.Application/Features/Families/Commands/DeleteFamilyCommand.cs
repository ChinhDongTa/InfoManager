using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Application.Features.Families.Commands;

public record DeleteFamilyCommand(string Id) : IRequest<Result>;
public class DeleteFamilyCommandHandler : BaseDeleteCommandHandler<DeleteFamilyCommand, Family>
{
    public DeleteFamilyCommandHandler(IApplicationDbContext context,                           ILogger<DeleteFamilyCommandHandler> logger)
        : base(context,  logger)
    {
    }
    protected override async Task<Family?> GetEntityAsync(DeleteFamilyCommand request, CancellationToken cancellationToken)
    {
        return await Context.Families.FindAsync([request.Id], cancellationToken);
    }
   
}