namespace InfoManager.Api.Endpoints.SFMS.Agricultural;
public class Crops : EndpointGroupBase
{
    public override string GroupName => "Crops";
    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetCropByIdQueryAsync,"{id}");
        api.MapGet(GetCropsQueryAsync);
        api.MapGet(SearchCropsQueryAsync,"search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateCropAsync);
        api.MapPut(UpdateCropAsync, "{id}");
        api.MapDelete(DeleteCropAsync, "{id}");
    }

    public async Task<IResult> GetCropByIdQueryAsync(string id, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCropByIdQuery(id), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> GetCropsQueryAsync(int pageNumber, int pageSize, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCropsQuery(pageNumber,pageSize), cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> SearchCropsQueryAsync([AsParameters] SearchCropRequest request, [FromServices] ISender sender, CancellationToken cancellationToken)
    {
        var searchRequest = new SearchCropsQuery(Term: request.Term,
                                                 MinDaysToMaturity: request.MinDaysToMaturity,
                                                 MaxDaysToMaturity: request.MaxDaysToMaturity,
                                                 Temperature: request.Temperature,
                                                 Humidity: request.Humidity,
                                                 SoilPh: request.SoilPh,
                                                 IsActive: request.IsActive,
                                                 PageNumber: request.PageNumber,
                                                 PageSize: request.PageSize);
        var result = await sender.Send(searchRequest, cancellationToken);
        return result.ToHttpResult();
    }
    public async Task<IResult> CreateCropAsync([FromBody] CreateCropRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var command = new CreateCropCommand()
        {
            CommonName = request.CommonName,
            DaysToMaturity = request.DaysToMaturity,
            Description = request.Description,
            ScientificName = request.ScientificName,
            Family = request.Family,
            IsActive = request.IsActive,
            MaxHumidity = request.MaxHumidity,
            MaxSoilPh = request.MaxSoilPh,
            MaxTemperature = request.MaxTemperature,
            MinHumidity = request.MinHumidity,
            MinSoilPh = request.MinSoilPh,
            MinTemperature = request.MinTemperature,
            SunLightHours = request.SunLightHours,
            WaterRequirement = request.WaterRequirement
        };
        var result = await sender.Send(command, cancellationToken);
        return result.ToCreatedHttpResult(GroupName);
    }
    public async Task<IResult> UpdateCropAsync(string id, [FromBody] UpdateCropRequest request, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("The ID in the URL does not match the ID in the request body.");
        }
        var command=new UpdateCropCommand()
        {
            Id = id,
            CommonName = request.CommonName,
            DaysToMaturity = request.DaysToMaturity,
            Description = request.Description,
            ScientificName = request.ScientificName,
            Family = request.Family,
            IsActive = request.IsActive,
            MaxHumidity = request.MaxHumidity,
            MaxSoilPh = request.MaxSoilPh,
            MaxTemperature = request.MaxTemperature,
            MinHumidity = request.MinHumidity,
            MinSoilPh = request.MinSoilPh,
            MinTemperature = request.MinTemperature,
            SunLightHours = request.SunLightHours,
            WaterRequirement = request.WaterRequirement
        };
        var result = await sender.Send(command, cancellationToken);
        return result.ToHttpResult();
    }

    public async Task<IResult> DeleteCropAsync(string id, [FromServices] ISender sender, [FromServices] IUser user, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteCropCommand(id), cancellationToken);
        return result.ToHttpResult();
    }
}