using InfoManager.Enum.SFMS;

namespace InfoManager.ModelClient.SFMS.Infrastructure;

public record UpdateFarmModel
{
    [Required]
    public string Id { get; set; }= string.Empty;
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? TotalArea { get; set; }
    public decimal? CultivableArea { get; set; }
    public string? Location { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public string? FarmerId { get; set; }
    public string? LicenseNumber { get; set; }
    public FarmStatus? Status { get; set; }
    public DateTimeOffset? EstablishedDate { get; set; }

    public UpdateFarmModel(string id, FarmDto dto)
    {
        Id = id;
        Name = dto.Name;
        Description= dto.Description;
        TotalArea = dto.TotalArea;
        CultivableArea= dto.CultivableArea;
        Location = dto.Location;
        Latitude = dto.Latitude;
        Longitude = dto.Longitude;
        FarmerId = dto.FarmerId;
        LicenseNumber = dto.LicenseNumber;
        Status = dto.Status;
        EstablishedDate = dto.EstablishedDate;
    }

    public UpdateFarmRequest CreateRequest()
        => new(
            Id: this.Id,
            Name: this.Name,
            Description: this.Description,
            TotalArea: this.TotalArea,
            CultivableArea:this.CultivableArea,
            Location:this.Location,
            Latitude:this.Latitude,
            Longitude:this.Longitude,
            FarmerId:this.FarmerId,
            LicenseNumber:this.LicenseNumber,
            Status:this.Status,
            EstablishedDate:this.EstablishedDate
            );
    public bool HasChanges(UpdateFarmModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}