namespace InfoManager.Application.Features.SFMS.HR.Commands;

public record UpdateDepartmentCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public string? ParentId { get; init; }
}

public class UpdateDepartmentCommandHandler : BaseUpdateCommandHandler<UpdateDepartmentCommand, Department>
{
    public UpdateDepartmentCommandHandler(IApplicationDbContext context,
                                          IValidator<UpdateDepartmentCommand> validator,
                                          ILogger<UpdateDepartmentCommandHandler> logger)
        : base(context, validator, logger) { }

    protected override async Task<Department?> GetEntityAsync(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        => await Context.Departments.FindAsync([request.Id], cancellationToken);

    protected override Task UpdateEntityProperties(Department entity, UpdateDepartmentCommand request)
    {
        if (request.Name.HasValueAndIsDifferentFrom(entity.Name))
            entity.Name = request.Name!;
        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description;
        if (request.ParentId.IsDifferentFrom(entity.ParentId))
            entity.ParentId = request.ParentId;
        return Task.CompletedTask;
    }
}

public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorHelpers.GetErrorRequired("ID phòng ban"));
        RuleFor(x => x.Name)
            .NotEmpty().When(x => x.Name != null)
            .WithMessage(ErrorHelpers.GetErrorRequired("Tên phòng ban"))
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.Name))
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Tên phòng ban", 100));
        RuleFor(x => x.Description)
            .MaximumLength(500).When(x => x.Description != null)
            .WithMessage(ErrorHelpers.GetErrorMaxLength("Mô tả", 500));
        RuleFor(x => x.ParentId)
            .NotEqual(x => x.Id).When(x => !string.IsNullOrEmpty(x.ParentId))
            .WithMessage(ErrorHelpers.GetErrorCustom("Phòng ban không thể là cấp trên của chính nó"));
    }
}