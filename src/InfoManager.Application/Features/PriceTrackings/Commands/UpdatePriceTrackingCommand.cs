using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Application.Features.PriceTrackings.Commands;

public record UpdatePriceTrackingCommand : IRequest<Result>
{
    public required string Id { get; init; }
    public string? ProductName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public decimal? CurrentPrice { get; init; }
    public decimal? DesiredPrice { get; init; }
    public decimal? LowestPriceSeen { get; init; }
    public string? StoreName { get; init; }
    public string? ProductUrl { get; init; }
    public bool? IsPurchased { get; init; } 
    public DateTimeOffset? LastCheckedDate { get; init; }
}
public class UpdatePriceTrackingCommandHandler : BaseUpdateCommandHandler<UpdatePriceTrackingCommand, PriceTracking>
{
    public UpdatePriceTrackingCommandHandler(IApplicationDbContext context,
                                             IValidator<UpdatePriceTrackingCommand> validator,
                                             ILogger<UpdatePriceTrackingCommandHandler> logger) : base(context, validator, logger)
    {
    }
    protected override async Task<PriceTracking?> GetEntityAsync(UpdatePriceTrackingCommand request, CancellationToken cancellationToken)
    {
        return await Context.PriceTrackings.FindAsync([request.Id], cancellationToken);
    }
    protected override async Task UpdateEntityProperties(PriceTracking entity, UpdatePriceTrackingCommand request)
    {
        if (request.ProductName.HasValueAndIsDifferentFrom(entity.ProductName))
            entity.ProductName = request.ProductName!;

        if (request.Description.IsDifferentFrom(entity.Description))
            entity.Description = request.Description;

        if (request.CurrentPrice.HasValueAndIsDifferentFrom(entity.CurrentPrice))
            entity.CurrentPrice = request.CurrentPrice!.Value;

        if (request.DesiredPrice.IsDifferentFrom(entity.DesiredPrice))
            entity.DesiredPrice = request.DesiredPrice;

        if (request.LowestPriceSeen.IsDifferentFrom(entity.LowestPriceSeen))
            entity.LowestPriceSeen = request.LowestPriceSeen;

        if (request.StoreName.IsDifferentFrom(entity.StoreName))
            entity.StoreName = request.StoreName;

        if (request.ProductUrl.IsDifferentFrom(entity.ProductUrl))
            entity.ProductUrl = request.ProductUrl;

        if (request.IsPurchased.HasValueAndIsDifferentFrom(entity.IsPurchased))
            entity.IsPurchased = request.IsPurchased!.Value;

        if (request.LastCheckedDate.IsDifferentFrom(entity.LastCheckedDate))
            entity.LastCheckedDate = request.LastCheckedDate;
    }
}
public class UpdatePriceTrackingCommandValidator : AbstractValidator<UpdatePriceTrackingCommand>
{
    public UpdatePriceTrackingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ErrorHelpers.GetErrorNotEmpty("Id"));
        
    }
}