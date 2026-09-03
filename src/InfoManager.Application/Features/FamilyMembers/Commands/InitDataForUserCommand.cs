using InfoManager.Domain.Entities.Authentication;
using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Application.Features.FamilyMembers.Commands;

public record InitDataForUserCommand : IRequest<Result<MessageResponse>>
{
    public required string FullName { get; init; }
    public required string Email { get; init; }
    public DateOnly BirthDate { get; init; }
    public Gender Gender { get; init; }
    public string? PhoneNumber { get; init  ; }
    public string? UserId { get; init; } // Optional: If you want to specify the user ID explicitly
}

public class InitDataForUserCommandHandler(IApplicationDbContext context, ILogger<InitDataForUserCommandHandler> logger) : IRequestHandler<InitDataForUserCommand, Result<MessageResponse>>
{
    public async Task<Result<MessageResponse>> Handle(InitDataForUserCommand request, CancellationToken ct)
    {
        //3. Create FamilyMember for the user
        var familyMember = new FamilyMember
        {
            FullName = request.FullName.Trim(),
            BirthDate = request.BirthDate,
            Gender = request.Gender,
            PhoneNumber = request.PhoneNumber?.Trim(),
            Email = request.Email
        };

        context.FamilyMembers.Add(familyMember);
        await context.SaveChangesAsync(ct);
        logger.LogInformation($"FamilyMember created successfully with ID: {familyMember.Id}");
        //4. Create Family immediately after creating FamilyMember
        var family = new Family
        {
            Name = $"{familyMember.FullName}'s Family",
            Email = familyMember.Email,
            RepresentativeId = familyMember.Id
        };
        context.Families.Add(family);
        await context.SaveChangesAsync(ct);
        logger.LogInformation($"Family created successfully with ID: {family.Id}");

        //5. Link FamilyMember to Family
        familyMember.FamilyId = family.Id;

        //6.Create UserProfile for the user
        var userProfile = new UserProfile
        {
            UserId = request.UserId ?? throw new ArgumentNullException(nameof(request.UserId)),
            FamilyId = family.Id,
            FamilyMemberId = familyMember.Id,
            Notes = "Tạo tự động"
        };
        context.UserProfiles.Add(userProfile);

        await context.SaveChangesAsync(ct);
        logger.LogInformation($"First-time initialization completed successfully for user ID: {request.UserId}, Family ID: {family.Id}, FamilyMember ID: {familyMember.Id}");
        return Result<MessageResponse>.Success(new MessageResponse { Message = "Khởi tạo lần đầu thành công." });
    }
}