namespace InfoManager.Application.Features.SFMS.HR.Commands;
public record UpdateJobPositionCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public decimal? MinSalary { get; init; }
    public decimal? MaxSalary { get; init; }
    public string? DepartmentId { get; init; }
    public string? RequiredQualifications { get; init; }
    public bool? IsActive { get; init; }
    public int? NumberOfPositions { get; init; }
    public string? Notes { get; init; }
}

public class UpdateJobPositionCommandHandler : BaseUpdateCommandHandler<UpdateJobPositionCommand, JobPosition>
{
    public UpdateJobPositionCommandHandler(IApplicationDbContext context,
                                           IValidator<UpdateJobPositionCommand> validator,
                                           ILogger<UpdateJobPositionCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<JobPosition?> GetEntityAsync(UpdateJobPositionCommand request, CancellationToken cancellationToken)
        => await Context.JobPositions.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(JobPosition entity, UpdateJobPositionCommand request)
    {
        if (request.Title.HasValueAndIsDifferentFrom(entity.Title))
            entity.Title = request.Title!;
        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description;
        if (request.MinSalary.IsDifferentFrom(entity.MinSalary))
            entity.MinSalary = request.MinSalary;
        if (request.MaxSalary.IsDifferentFrom(entity.MaxSalary))
            entity.MaxSalary = request.MaxSalary;
        if (request.DepartmentId.IsDifferentFrom(entity.DepartmentId))
            entity.DepartmentId = request.DepartmentId;
        if (request.RequiredQualifications.IsDifferentFrom(entity.RequiredQualifications))
            entity.RequiredQualifications = request.RequiredQualifications;
        if (request.IsActive.HasValueAndIsDifferentFrom(entity.IsActive))
            entity.IsActive = request.IsActive!.Value;
        if (request.NumberOfPositions.IsDifferentFrom(entity.NumberOfPositions))
            entity.NumberOfPositions = request.NumberOfPositions;
        if (request.Notes.IsDifferentFrom(entity.Notes))
            entity.Notes = request.Notes;
        return Task.CompletedTask;
    }
}

public class UpdateJobPositionCommandValidator : AbstractValidator<UpdateJobPositionCommand>
{
    public UpdateJobPositionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID vị trí"));
        RuleFor(x => x.Title)
            .NotEmpty().When(x => x.Title != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Tên vị trí"))
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.Title))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên vị trí", 100));
        RuleFor(x => x.Description)
            .MaximumLength(1000).When(x => x.Description != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả", 1000));
        RuleFor(x => x.MinSalary)
            .GreaterThanOrEqualTo(0).When(x => x.MinSalary.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Lương tối thiểu", 0));
        RuleFor(x => x.MaxSalary)
            .GreaterThanOrEqualTo(x => x.MinSalary)
            .When(x => x.MinSalary.HasValue && x.MaxSalary.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Lương tối đa phải ≥ lương tối thiểu"));
        RuleFor(x => x.RequiredQualifications)
            .MaximumLength(500).When(x => x.RequiredQualifications != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Yêu cầu trình độ", 500));
        RuleFor(x => x.NumberOfPositions)
            .GreaterThanOrEqualTo(0).When(x => x.NumberOfPositions.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số vị trí", 0));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => x.Notes != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}