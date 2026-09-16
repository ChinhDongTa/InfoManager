namespace InfoManager.Application.Features.SFMS.Issues.Commands;

public record DeleteDiseaseCommand(string Id) : IRequest<Result>;

public class DeleteDiseaseCommandHandler : BaseDeleteCommandHandler<DeleteDiseaseCommand, Disease>
{
    public DeleteDiseaseCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteDiseaseCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Disease?> GetEntityAsync(DeleteDiseaseCommand request, CancellationToken ct)
  => await Context.Diseases.FindAsync(request, ct);
}