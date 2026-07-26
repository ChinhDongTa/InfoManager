namespace InfoManager.Application.Features.FamilyMembers.Commands;
public record UpdateFamilyMemberCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public  string? FullName { get; init; }
    public string? FamilyRelationId { get; init; }
    public DateTime? BirthDate { get; init; }
    public DateTime? DeathDate { get; init; }
    public Gender? Gender { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Note { get; init; }
}
public class UpdateFamilyMemberCommandHandler:BaseUpdateCommandHandler<UpdateFamilyMemberCommand, FamilyMember>
{
    public UpdateFamilyMemberCommandHandler(IApplicationDbContext context,
                                            IValidator<UpdateFamilyMemberCommand> validator,
                                            ILogger<UpdateFamilyMemberCommandHandler> logger) : base(context, validator, logger)
    {
    }
    protected override async Task<FamilyMember?> GetEntityAsync(UpdateFamilyMemberCommand request, CancellationToken cancellationToken)
    {
        return await Context.FamilyMembers.FindAsync([request.Id], cancellationToken);
    }
    protected override void UpdateEntityProperties(FamilyMember entity, UpdateFamilyMemberCommand request)
    {
        if (request.FullName .HasValueAndIsDifferentFrom(entity.FullName))
            entity.FullName = request.FullName!;

        if (request.FamilyRelationId.IsDifferentFrom(entity.FamilyRelationId))
            entity.FamilyRelationId = request.FamilyRelationId;

        if (request.BirthDate.ToDateOnly().HasValueAndIsDifferentFrom(entity.BirthDate))
            entity.BirthDate = request.BirthDate.ToDateOnly()!.Value;

        if ((request.DeathDate.ToDateOnly()).IsDifferentFrom(entity.DeathDate))
            entity.DeathDate = (request.DeathDate.ToDateOnly())!.Value;

        if (request.Gender.HasValueAndIsDifferentFrom(entity.Gender))
            entity.Gender = request.Gender!.Value;

        if (request.Email.IsDifferentFrom(entity.Email))
            entity.Email = request.Email;

        if (request.PhoneNumber.IsDifferentFrom(entity.PhoneNumber))
            entity.PhoneNumber = request.PhoneNumber;

        if (request.Note.IsDifferentFrom(entity.Note))
            entity.Note = request.Note;
    }
}   
public class UpdateFamilyMemberCommandValidator : AbstractValidator<UpdateFamilyMemberCommand>
{
    public UpdateFamilyMemberCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));
       
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage(ErrorHelpers.GetErrorInvalid("Email"))
            .MaximumLength(200).WithMessage(ErrorHelpers.GetErrorMaxLength("Email", 200))
            .When(x => !string.IsNullOrEmpty(x.Email));
        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?\d{10,15}$").WithMessage(ErrorHelpers.GetErrorInvalid("PhoneNumber"))
            .MaximumLength(50).WithMessage(ErrorHelpers.GetErrorMaxLength("PhoneNumber", 50))
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber));
    }
}