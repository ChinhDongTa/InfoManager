using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Application.Features.FamilyEventOccurrences.Commands;

public record DeleteFamilyEventOccurrenceCommand(string Id) : IRequest<Result>;
public class DeleteFamilyEventOccurrenceCommandHandler : BaseDeleteCommandHandler<DeleteFamilyEventOccurrenceCommand, FamilyEventOccurrence>
{
    public DeleteFamilyEventOccurrenceCommandHandler(IApplicationDbContext context,
                                                     ILogger<DeleteFamilyEventOccurrenceCommandHandler> logger)
        : base(context, logger)
    {
    }
    
    protected override async Task<FamilyEventOccurrence?> GetEntityAsync(DeleteFamilyEventOccurrenceCommand request, CancellationToken cancellationToken)
    {
        return await Context.FamilyEventOccurrences.FindAsync([request.Id], cancellationToken);
    }
}