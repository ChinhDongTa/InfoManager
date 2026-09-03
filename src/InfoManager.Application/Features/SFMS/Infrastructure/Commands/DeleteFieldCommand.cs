namespace InfoManager.Application.Features.SFMS.Infrastructure.Commands;

public record DeleteFieldCommand(string Id) : IRequest<Result>;
public class DeleteFieldCommandHandler : BaseDeleteCommandHandler<DeleteFieldCommand, Field>
{
    public DeleteFieldCommandHandler(IApplicationDbContext context,
                                     ILogger<DeleteFieldCommandHandler> logger) : base(context, logger)
    {
    }

    protected override async Task<Field?> GetEntityAsync(DeleteFieldCommand request, CancellationToken cancellationToken)
        => await Context.Fields.FindAsync([request.Id], cancellationToken);
}