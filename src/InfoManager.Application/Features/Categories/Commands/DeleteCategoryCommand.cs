namespace InfoManager.Application.Features.Categories.Commands;

public record DeleteCategoryCommand(string Id) : IRequest<Result>;

public class DeleteCategoryCommandHandler : BaseDeleteCommandHandler<DeleteCategoryCommand, Category>
{
    public DeleteCategoryCommandHandler(IApplicationDbContext context,
                                        ILogger<DeleteCategoryCommandHandler> logger)
        : base(context, logger)
    {
    }

    protected override async Task<Category?> GetEntityAsync(DeleteCategoryCommand request, CancellationToken ct)
    {
        return await Context.Categories.FindAsync([request.Id], ct);
    }
}