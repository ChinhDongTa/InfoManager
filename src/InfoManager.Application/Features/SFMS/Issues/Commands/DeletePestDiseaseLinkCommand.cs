namespace InfoManager.Application.Features.SFMS.Issues.Commands;

public record DeletePestDiseaseLinkCommand(string Id) : IRequest<Result>;

public class DeletePestDiseaseLinkCommandHandler : BaseDeleteCommandHandler<DeletePestDiseaseLinkCommand, PestDiseaseLink>
{
    public DeletePestDiseaseLinkCommandHandler(IApplicationDbContext context,
                                     ILogger<DeletePestDiseaseLinkCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<PestDiseaseLink?> GetEntityAsync(DeletePestDiseaseLinkCommand request, CancellationToken ct)
  => await Context.PestDiseaseLinks.FindAsync(request, ct);
}