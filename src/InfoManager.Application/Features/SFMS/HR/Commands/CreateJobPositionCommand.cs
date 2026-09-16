namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record CreateJobPositionCommand : IRequest<Result<string>>
{
    public required string Title { get; init; }
    public string? Description { get; init; }
    public decimal? MinSalary { get; init; }
    public decimal? MaxSalary { get; init; }
    public string? DepartmentId { get; init; }
    public string? RequiredQualifications { get; init; }
    public required bool IsActive { get; init; }
    public int? NumberOfPositions { get; init; }
    public string? Notes { get; init; }
}

public class CreateJobPositionCommandHandler : BaseCreateCommandHandler<CreateJobPositionCommand, JobPosition>
{
    public CreateJobPositionCommandHandler(IApplicationDbContext context,
                                           IValidator<CreateJobPositionCommand> validator,
                                           ILogger<CreateJobPositionCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(JobPosition entity, CancellationToken ct)
        => await Context.JobPositions.AddAsync(entity, ct);

    protected override Task<JobPosition> CreateEntity(CreateJobPositionCommand request)
        => Task.FromResult(new JobPosition
        {
            Title = request.Title,
            Description = request.Description,
            MinSalary = request.MinSalary,
            MaxSalary = request.MaxSalary,
            DepartmentId = request.DepartmentId,
            RequiredQualifications = request.RequiredQualifications,
            IsActive = request.IsActive,
            NumberOfPositions = request.NumberOfPositions,
            Notes = request.Notes
        });
}

public class CreateJobPositionCommandValidator : AbstractValidator<CreateJobPositionCommand>
{
    public CreateJobPositionCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên vị trí"))
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên vị trí", 100));
        RuleFor(x => x.Description)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Description))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả", 1000));
        RuleFor(x => x.MinSalary)
            .GreaterThanOrEqualTo(0).When(x => x.MinSalary.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Lương tối thiểu", 0));
        RuleFor(x => x.MaxSalary)
            .GreaterThanOrEqualTo(x => x.MinSalary)
            .When(x => x.MinSalary.HasValue && x.MaxSalary.HasValue)
            .WithMessage(ErrorHelpers.GetErrorCustom("Lương tối đa phải ≥ lương tối thiểu"));
        RuleFor(x => x.RequiredQualifications)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.RequiredQualifications))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Yêu cầu trình độ", 500));
        RuleFor(x => x.NumberOfPositions)
            .GreaterThanOrEqualTo(0).When(x => x.NumberOfPositions.HasValue)
            .WithMessage(ErrorHelpers.GetErrorMinValue("Số vị trí", 0));
        RuleFor(x => x.Notes)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Ghi chú", 500));
    }
}