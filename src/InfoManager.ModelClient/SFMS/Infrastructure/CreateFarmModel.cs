using InfoManager.Enum.SFMS;

namespace InfoManager.ModelClient.SFMS.Infrastructure;

public record CreateFarmModel
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string FarmerId { get; set; }= string.Empty;
    public string? Description { get; set; }
    public decimal TotalArea { get; set; } = 0;
    public decimal CultivableArea { get; set; } = 0;
    public string? Location { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public string? LicenseNumber { get; set; }
    public FarmStatus Status { get; set; } = FarmStatus.Active;
    public DateTimeOffset? EstablishedDate { get; set; }

    public CreateFarmRequest CreateRequest()
    {
        return new(
            Name:this.Name,
            FarmerId:this.FarmerId,
            Description:this.Description,
            TotalArea:this.TotalArea,
            CultivableArea:this.CultivableArea,
            Location:this.Location,
            Latitude:this.Latitude,
            Longitude:this.Longitude,
            LicenseNumber:this.LicenseNumber,
            Status:this.Status,
            EstablishedDate:this.EstablishedDate
            );
    }
}
