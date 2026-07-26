namespace InfoManager.Application.Features.FamilyRelations.Commands;

public record CreateFamilyRelationCommand(string Name, string? Description) : IRequest<Result<string>>;
public class CreateFamilyRelationCommandHandler :BaseCreateCommandHandler<CreateFamilyRelationCommand, FamilyRelation>
{
    public CreateFamilyRelationCommandHandler(IApplicationDbContext context, IValidator<CreateFamilyRelationCommand> validator, ILogger<CreateFamilyRelationCommandHandler> logger) : base(context, validator, logger   )
    {
    }
     protected override FamilyRelation CreateEntity(CreateFamilyRelationCommand request)
    {
         return new FamilyRelation
         {
             Name = request.Name.Trim(),
             Description = request.Description?.Trim()
         };
    }

    protected override async Task AddEntityAsync(FamilyRelation entity, CancellationToken cancellationToken)
    {
        await Context.FamilyRelations.AddAsync(entity, cancellationToken);
    }

}
public class CreateFamilyRelationCommandValidator : AbstractValidator<CreateFamilyRelationCommand>
{
    public CreateFamilyRelationCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
    }
}