namespace InfoManager.ApiClient.Interfaces;

public interface IAgriculturalService
{
    //==================================== CropPlanting ==============================================
    Task<ApiResult<PaginatedList<CropPlantingSummaryDto>>> GetCropPlantingsAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateCropPlantingAsync(CreateCropPlantingRequest request, CancellationToken ct = default);
    Task<ApiResult<CropPlantingDto?>> GetCropPlantingByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateCropPlantingAsync(string id, UpdateCropPlantingRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteCropPlantingAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CropPlantingSummaryDto>>> SearchCropPlantingsAsync(SearchCropPlantingRequest request, CancellationToken ct = default);

    //==================================== Crop ==============================================

    Task<ApiResult<CropDto?>> GetCropByIdQueryAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateCropAsync(string id, UpdateCropRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteCropAsync(string id, CancellationToken ct = default);
    Task<ApiResult<string>> CreateCropAsync(CreateCropRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CropSummaryDto>>> GetCropsQueryAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CropSummaryDto>>> SearchCropsQueryAsync(SearchCropRequest request, CancellationToken ct = default);

    //==================================== CropVariety ==============================================
    Task<ApiResult<CropVarietyDto?>> GetCropVarietyByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateCropVarietyAsync(string id, UpdateCropVarietyRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteCropVarietyAsync(string id, CancellationToken ct = default);
    Task<ApiResult<string>> CreateCropVarietyAsync(CreateCropVarietyRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CropVarietySummaryDto>>> GetCropVarietiesAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CropVarietySummaryDto>>> SearchCropVarietiesAsync(SearchCropVarietyRequest request, CancellationToken ct = default);

    //==================================== GrowthStageAlert ==============================================

    Task<ApiResult<GrowthStageAlertDto?>> GetGrowthStageAlertByIdQueryAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateGrowthStageAlertAsync(string id, UpdateGrowthStageAlertRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteGrowthStageAlertAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<GrowthStageAlertSummaryDto>>> GetGrowthStageAlertsQueryAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateGrowthStageAlertAsync(CreateGrowthStageAlertRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<GrowthStageAlertSummaryDto>>> SearchGrowthStageAlertsQueryAsync(SearchGrowthStageAlertRequest request, CancellationToken ct = default);

    //==================================== GrowthStage ==============================================

    Task<ApiResult> UpdateGrowthStageAsync(string id, UpdateGrowthStageRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteGrowthStageAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<GrowthStageSummaryDto>>> GetGrowthStagesQueryAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateGrowthStageAsync(CreateGrowthStageRequest request, CancellationToken ct = default);

    Task<ApiResult<PaginatedList<GrowthStageSummaryDto>>> SearchGrowthStagesQueryAsync(SearchGrowthStageRequest request, CancellationToken ct = default);
}
