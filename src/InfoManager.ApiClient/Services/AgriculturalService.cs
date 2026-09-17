namespace InfoManager.ApiClient.Services;

internal class AgriculturalService(IAgriculturalApi api) : IAgriculturalService
{
    public async Task<ApiResult<string>> CreateCropAsync(CreateCropRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateCropAsync(request, ct));

    public async Task<ApiResult<string>> CreateCropPlantingAsync(CreateCropPlantingRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateCropPlantingAsync(request, ct));

    public async Task<ApiResult<string>> CreateCropScheduleAsync(CreateCropScheduleRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateCropScheduleAsync(request, ct));

    public async Task<ApiResult<string>> CreateCropVarietyAsync(CreateCropVarietyRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateCropVarietyAsync(request, ct));

    public async Task<ApiResult<string>> CreateGrowthStageAlertAsync(CreateGrowthStageAlertRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateGrowthStageAlertAsync(request, ct));

    public async Task<ApiResult<string>> CreateGrowthStageAsync(CreateGrowthStageRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.CreateGrowthStageAsync(request, ct));

    public async Task<ApiResult> DeleteCropAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.DeleteCropAsync(id, ct));

    public async Task<ApiResult> DeleteCropPlantingAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.DeleteCropPlantingAsync(id, ct));

    public async Task<ApiResult> DeleteCropScheduleAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.DeleteCropScheduleAsync(id, ct));

    public async Task<ApiResult> DeleteCropVarietyAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.DeleteCropVarietyAsync(id, ct));

    public async Task<ApiResult> DeleteGrowthStageAlertAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.DeleteGrowthStageAlertAsync(id, ct));

    public async Task<ApiResult> DeleteGrowthStageAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.DeleteGrowthStageAsync(id, ct));

    public async Task<ApiResult<CropDto?>> GetCropByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetCropByIdQueryAsync(id, ct));

    public async Task<ApiResult<CropPlantingDto?>> GetCropPlantingByIdAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetCropPlantingByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<CropPlantingSummaryDto>>> GetCropPlantingsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetCropPlantingsAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<CropSummaryDto>>> GetCropsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetCropsQueryAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<CropScheduleDto?>> GetCropScheduleByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetCropScheduleByIdAsync(id, ct));

    public async Task<ApiResult<PaginatedList<CropScheduleSummaryDto>>> GetCropSchedulesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
     => await ApiResponseHandler.HandleAsync(await api.GetCropSchedulesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<CropVarietySummaryDto>>> GetCropVarietiesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetCropVarietiesAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<CropVarietyDto?>> GetCropVarietyByIdAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetCropVarietyByIdAsync(id, ct));

    public async Task<ApiResult<GrowthStageAlertDto?>> GetGrowthStageAlertByIdAsync(string id, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetGrowthStageAlertByIdQueryAsync(id, ct));

    public async Task<ApiResult<PaginatedList<GrowthStageAlertSummaryDto>>> GetGrowthStageAlertsAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetGrowthStageAlertsQueryAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<GrowthStageDto?>> GetGrowthStageByIdAsync(string id, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.GetGrowthStageByIdQueryAsync(id, ct));

    public async Task<ApiResult<PaginatedList<GrowthStageSummaryDto>>> GetGrowthStagesAsync(int pageNumber, int pageSize, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.GetGrowthStagesQueryAsync(pageNumber, pageSize, ct));

    public async Task<ApiResult<PaginatedList<CropPlantingSummaryDto>>> SearchCropPlantingsAsync(SearchCropPlantingRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.SearchCropPlantingsAsync(request.Term,
                                                                               request.StartPlantingDate,
                                                                               request.EndPlantingDate,
                                                                               request.MinPlantedArea,
                                                                               request.MaxPlantedArea,
                                                                               request.Status,
                                                                               request.PageNumber,
                                                                               request.PageSize,
                                                                               ct));

    public async Task<ApiResult<PaginatedList<CropSummaryDto>>> SearchCropsAsync(SearchCropRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.SearchCropsQueryAsync(request.Term,
                                                                             request.MinDaysToMaturity,
                                                                             request.MaxDaysToMaturity,
                                                                             request.Temperature,
                                                                             request.Humidity,
                                                                             request.SoilPh,
                                                                             request.IsActive,
                                                                             request.PageNumber,
                                                                             request.PageSize,
                                                                             ct));

    public async Task<ApiResult<PaginatedList<CropScheduleSummaryDto>>> SearchCropSchedulesAsync(SearchCropSchedulesRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchCropSchedulesAsync(request.Term,
                                                                              request.MinDaysToHarvest,
                                                                              request.MaxDaysToHarvest,
                                                                              request.MinExpectedYield,
                                                                              request.MaxExpectedYield,
                                                                              request.IsActive,
                                                                              request.PageNumber,
                                                                              request.PageSize,
                                                                              ct));

    public async Task<ApiResult<PaginatedList<CropVarietySummaryDto>>> SearchCropVarietiesAsync(SearchCropVarietyRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchCropVarietiesAsync(request.Term,
                                                                                 request.CropId,
                                                                                 request.DaysToMaturity,
                                                                                 request.MinExpectedYield,
                                                                                 request.MaxExpectedYield,
                                                                                 request.IsActive,
                                                                                 request.PageNumber,
                                                                                 request.PageSize,
                                                                                 ct));

    public async Task<ApiResult<PaginatedList<GrowthStageAlertSummaryDto>>> SearchGrowthStageAlertsAsync(SearchGrowthStageAlertRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.SearchGrowthStageAlertsQueryAsync(request.CropPlantingId,
                                                                                           request.GrowthStageId,
                                                                                           request.AlertType,
                                                                                           request.Severity,
                                                                                           request.IsResolved,
                                                                                           request.PageNumber,
                                                                                           request.PageSize,
                                                                                           ct));

    public async Task<ApiResult<PaginatedList<GrowthStageSummaryDto>>> SearchGrowthStagesAsync(SearchGrowthStageRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.SearchGrowthStagesQueryAsync(request.Term,
                                                                                     request.MinStageSequence,
                                                                                     request.MaxStageSequence,
                                                                                     request.MinStageSequence,
                                                                                     request.MaxDaysAfterPlanting,
                                                                                     request.Temperature,
                                                                                     request.Humidity,
                                                                                     request.PageNumber,
                                                                                     request.PageSize,
                                                                                     ct));

    public async Task<ApiResult> UpdateCropAsync(string id, UpdateCropRequest request, CancellationToken ct = default)
  => await ApiResponseHandler.HandleAsync(await api.UpdateCropAsync(id, request, ct));

    public async Task<ApiResult> UpdateCropPlantingAsync(string id, UpdateCropPlantingRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.UpdateCropPlantingAsync(id, request, ct));

    public async Task<ApiResult> UpdateCropScheduleAsync(string id, UpdateCropScheduleRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.UpdateCropScheduleAsync(id, request, ct));

    public async Task<ApiResult> UpdateCropVarietyAsync(string id, UpdateCropVarietyRequest request, CancellationToken ct = default)
    => await ApiResponseHandler.HandleAsync(await api.UpdateCropVarietyAsync(id, request, ct));

    public async Task<ApiResult> UpdateGrowthStageAlertAsync(string id, UpdateGrowthStageAlertRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateGrowthStageAlertAsync(id, request, ct));

    public async Task<ApiResult> UpdateGrowthStageAsync(string id, UpdateGrowthStageRequest request, CancellationToken ct = default)
   => await ApiResponseHandler.HandleAsync(await api.UpdateGrowthStageAsync(id, request, ct));
}