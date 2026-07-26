namespace InfoManager.Application.Features.Categories.Commands;

public record DeleteCategoryCommand (string Id) : IRequest<Result>;

public class DeleteCategoryCommandHandler : BaseDeleteCommandHandler<DeleteCategoryCommand, Category>
{
    public DeleteCategoryCommandHandler(IApplicationDbContext context,
                                        ILogger<DeleteCategoryCommandHandler> logger)
        : base(context, logger)
    {
    }

    protected override void DeleteEntity(Category entity, CancellationToken cancellationToken)
    {
        Context.Categories.Remove(entity);
    }

    protected override async Task<Category?> GetEntityAsync(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        return await Context.Categories.FindAsync([request.Id], cancellationToken);
    }
}