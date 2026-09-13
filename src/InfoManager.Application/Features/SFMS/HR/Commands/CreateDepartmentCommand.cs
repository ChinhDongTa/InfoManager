namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record CreateDepartmentCommand : IRequest<Result<string>>
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public string? ParentId { get; init; }
    public required string FarmId { get; init; }
}

public class CreateDepartmentCommandHandler : BaseCreateCommandHandler<CreateDepartmentCommand, Department>
{
    public CreateDepartmentCommandHandler(IApplicationDbContext context,
                                          IValidator<CreateDepartmentCommand> validator,
                                          ILogger<CreateDepartmentCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task AddEntityAsync(Department entity, CancellationToken cancellationToken)
        => await Context.Departments.AddAsync(entity, cancellationToken);

    protected override Task<Department> CreateEntity(CreateDepartmentCommand request)
        => Task.FromResult(new Department
        {
            Name = request.Name,
            Description = request.Description,
            ParentId = request.ParentId,
            FarmId = request.FarmId
        });
}

public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("Tên phòng ban"))
            .MaximumLength(100).WithMessage(ErrorHelpers.GetErrorMaxLength("Tên phòng ban", 100));
        RuleFor(x => x.Description)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Description))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả", 500));
        RuleFor(x => x.FarmId)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID nông trại"));
    }
}