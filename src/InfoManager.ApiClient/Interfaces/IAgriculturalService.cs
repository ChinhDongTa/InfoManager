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

    Task<ApiResult<CropDto?>> GetCropByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateCropAsync(string id, UpdateCropRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteCropAsync(string id, CancellationToken ct = default);
    Task<ApiResult<string>> CreateCropAsync(CreateCropRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CropSummaryDto>>> GetCropsAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CropSummaryDto>>> SearchCropsAsync(SearchCropRequest request, CancellationToken ct = default);

    //==================================== CropVariety ==============================================
    Task<ApiResult<CropVarietyDto?>> GetCropVarietyByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateCropVarietyAsync(string id, UpdateCropVarietyRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteCropVarietyAsync(string id, CancellationToken ct = default);
    Task<ApiResult<string>> CreateCropVarietyAsync(CreateCropVarietyRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CropVarietySummaryDto>>> GetCropVarietiesAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CropVarietySummaryDto>>> SearchCropVarietiesAsync(SearchCropVarietyRequest request, CancellationToken ct = default);

    //==================================== Crop schedule ==============================================

    Task<ApiResult<CropScheduleDto?>> GetCropScheduleByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateCropScheduleAsync(string id, UpdateCropScheduleRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteCropScheduleAsync(string id, CancellationToken ct = default);
    Task<ApiResult<string>> CreateCropScheduleAsync(CreateCropScheduleRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CropScheduleSummaryDto>>> GetCropSchedulesAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<CropScheduleSummaryDto>>> SearchCropSchedulesAsync(SearchCropSchedulesRequest request, CancellationToken ct = default);

    //==================================== GrowthStageAlert ==============================================

    Task<ApiResult<GrowthStageAlertDto?>> GetGrowthStageAlertByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult> UpdateGrowthStageAlertAsync(string id, UpdateGrowthStageAlertRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteGrowthStageAlertAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<GrowthStageAlertSummaryDto>>> GetGrowthStageAlertsAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateGrowthStageAlertAsync(CreateGrowthStageAlertRequest request, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<GrowthStageAlertSummaryDto>>> SearchGrowthStageAlertsAsync(SearchGrowthStageAlertRequest request, CancellationToken ct = default);

    //==================================== GrowthStage ==============================================

    Task<ApiResult> UpdateGrowthStageAsync(string id, UpdateGrowthStageRequest request, CancellationToken ct = default);
    Task<ApiResult> DeleteGrowthStageAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<GrowthStageSummaryDto>>> GetGrowthStagesAsync(int pageNumber, int pageSize, CancellationToken ct = default);
    Task<ApiResult<string>> CreateGrowthStageAsync(CreateGrowthStageRequest request, CancellationToken ct = default);
    Task<ApiResult<GrowthStageDto?>> GetGrowthStageByIdAsync(string id, CancellationToken ct = default);
    Task<ApiResult<PaginatedList<GrowthStageSummaryDto>>> SearchGrowthStagesAsync(SearchGrowthStageRequest request, CancellationToken ct = default);
}
