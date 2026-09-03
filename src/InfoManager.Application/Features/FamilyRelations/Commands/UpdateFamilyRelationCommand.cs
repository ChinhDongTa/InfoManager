using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Application.Features.FamilyRelations.Commands;
public record UpdateFamilyRelationCommand(string Id,string? Name, string? Description) : IRequest<Result>;
public class UpdateFamilyRelationCommandHandler : BaseUpdateCommandHandler<UpdateFamilyRelationCommand, FamilyRelation>
{
    public UpdateFamilyRelationCommandHandler(IApplicationDbContext context,IValidator<UpdateFamilyRelationCommand>     validator, ILogger<UpdateFamilyRelationCommand> logger)
        : base(context, validator, logger)
    {
        
    }
    protected override async Task<FamilyRelation?> GetEntityAsync(UpdateFamilyRelationCommand request, CancellationToken ct)
    {
        return await Context.FamilyRelations.FindAsync([request.Id], ct);
    }

    protected override async Task UpdateEntityProperties(FamilyRelation entity, UpdateFamilyRelationCommand request)
    {
        if(request.Name.HasValueAndIsDifferentFrom(entity.Name))
            entity.Name = request.Name!;
        
        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description;
    }
}
public class UpdateFamilyRelationCommandValidator : AbstractValidator<UpdateFamilyRelationCommand>
{
    public UpdateFamilyRelationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));
       
        RuleFor(x => x.Name)
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Name", 100))
            .When(x => !string.IsNullOrEmpty(x.Name));
    }
}