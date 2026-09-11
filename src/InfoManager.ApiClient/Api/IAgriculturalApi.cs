namespace InfoManager.ApiClient.Api;

public interface IAgriculturalApi
{
    /// <param name="pageIndex">pageIndex parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/CropPlantings")]
    Task<ApiResponse<PaginatedList<CropPlantingSummaryDto>>> GetCropPlantingsAsync([Query] int pageIndex, [Query] int pageSize, CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Post("/api/CropPlantings")]
    Task<ApiResponse<string>> CreateCropPlantingAsync([Body] CreateCropPlantingRequest request, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/CropPlantings/{id}")]
    Task<ApiResponse<CropPlantingDto?>> GetCropPlantingByIdAsync(string id, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Put("/api/CropPlantings/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateCropPlantingAsync(string id, [Body] UpdateCropPlantingRequest request, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Delete("/api/CropPlantings/{id}")]
    Task<IApiResponse> DeleteCropPlantingAsync(string id, CancellationToken ct = default);

    /// <param name="term">term parameter</param>
    /// <param name="startPlantingDate">startPlantingDate parameter</param>
    /// <param name="endPlantingDate">endPlantingDate parameter</param>
    /// <param name="minPlantedArea">minPlantedArea parameter</param>
    /// <param name="maxPlantedArea">maxPlantedArea parameter</param>
    /// <param name="status">status parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/CropPlantings/search")]
    Task<ApiResponse<PaginatedList<CropPlantingSummaryDto>>> SearchCropPlantingsAsync([Query, AliasAs("Term")] string? term,
                                                                                      [Query, AliasAs("StartPlantingDate")] System.DateTimeOffset? startPlantingDate,
                                                                                      [Query, AliasAs("EndPlantingDate")] System.DateTimeOffset? endPlantingDate,
                                                                                      [Query, AliasAs("MinPlantedArea")] decimal? minPlantedArea,
                                                                                      [Query, AliasAs("MaxPlantedArea")] decimal? maxPlantedArea,
                                                                                      [Query, AliasAs("Status")] PlantingStatus? status,
                                                                                      [Query, AliasAs("PageNumber")] int pageNumber,
                                                                                      [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/Crops/{id}")]
    Task<ApiResponse<CropDto?>> GetCropByIdQueryAsync(string id, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Put("/api/Crops/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateCropAsync(string id, [Body] UpdateCropRequest request, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Delete("/api/Crops/{id}")]
    Task<IApiResponse> DeleteCropAsync(string id, CancellationToken ct = default);

    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/Crops")]
    Task<ApiResponse<PaginatedList<CropSummaryDto>>> GetCropsQueryAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Post("/api/Crops")]
    Task<ApiResponse<string>> CreateCropAsync([Body] CreateCropRequest request, CancellationToken ct = default);

    /// <param name="term">term parameter</param>
    /// <param name="minDaysToMaturity">minDaysToMaturity parameter</param>
    /// <param name="maxDaysToMaturity">maxDaysToMaturity parameter</param>
    /// <param name="temperature">temperature parameter</param>
    /// <param name="humidity">humidity parameter</param>
    /// <param name="soilPh">soilPh parameter</param>
    /// <param name="isActive">isActive parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/Crops/search")]
    Task<ApiResponse<PaginatedList<CropSummaryDto>>> SearchCropsQueryAsync([Query, AliasAs("Term")] string? term,
                                             [Query, AliasAs("MinDaysToMaturity")] int? minDaysToMaturity,
                                             [Query, AliasAs("MaxDaysToMaturity")] int? maxDaysToMaturity,
                                             [Query, AliasAs("Temperature")] decimal? temperature,
                                             [Query, AliasAs("Humidity")] decimal? humidity,
                                             [Query, AliasAs("SoilPh")] decimal? soilPh,
                                             [Query, AliasAs("IsActive")] bool? isActive,
                                             [Query, AliasAs("PageNumber")] int pageNumber,
                                             [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);


    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/CropSchedules")]
    Task<ApiResponse<PaginatedList<CropScheduleSummaryDto>>> GetCropSchedulesAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Post("/api/CropSchedules")]
    Task<ApiResponse<string>> CreateCropScheduleAsync([Body] CreateCropScheduleRequest request, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/CropSchedules/{id}")]
    Task<ApiResponse<CropScheduleDto?>> GetCropScheduleByIdAsync(string id, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Put("/api/CropSchedules/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateCropScheduleAsync(string id, [Body] UpdateCropScheduleRequest request, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Delete("/api/CropSchedules/{id}")]
    Task<IApiResponse> DeleteCropScheduleAsync(string id, CancellationToken ct = default);

    /// <param name="term">term parameter</param>
    /// <param name="minDaysToHarvest">minDaysToHarvest parameter</param>
    /// <param name="maxDaysToHarvest">maxDaysToHarvest parameter</param>
    /// <param name="minExpectedYield">minExpectedYield parameter</param>
    /// <param name="maxExpectedYield">maxExpectedYield parameter</param>
    /// <param name="isActive">isActive parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/CropSchedules/search")]
    Task<ApiResponse<PaginatedList<CropScheduleSummaryDto>>> SearchCropSchedulesAsync([Query, AliasAs("Term")] string? term,
                                                [Query, AliasAs("MinDaysToHarvest")] int? minDaysToHarvest,
                                                [Query, AliasAs("MaxDaysToHarvest")] int? maxDaysToHarvest,
                                                [Query, AliasAs("MinExpectedYield")] decimal? minExpectedYield,
                                                [Query, AliasAs("MaxExpectedYield")] decimal? maxExpectedYield,
                                                [Query, AliasAs("IsActive")] bool? isActive,
                                                [Query, AliasAs("PageNumber")] int pageNumber,
                                                [Query, AliasAs("PageSize")] int pageSize,
                                                CancellationToken ct = default);


    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/CropVarieties")]
    Task<ApiResponse<PaginatedList<CropVarietySummaryDto>>> GetCropVarietiesAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Post("/api/CropVarieties")]
    Task<ApiResponse<string>> CreateCropVarietyAsync([Body] CreateCropVarietyRequest request, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/CropVarieties/{id}")]
    Task<ApiResponse<CropVarietyDto?>> GetCropVarietyByIdAsync(string id, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Put("/api/CropVarieties/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateCropVarietyAsync(string id, [Body] UpdateCropVarietyRequest request, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Delete("/api/CropVarieties/{id}")]
    Task<IApiResponse> DeleteCropVarietyAsync(string id, CancellationToken ct = default);

    /// <param name="term">term parameter</param>
    /// <param name="cropId">cropId parameter</param>
    /// <param name="daysToMaturity">daysToMaturity parameter</param>
    /// <param name="minExpectedYield">minExpectedYield parameter</param>
    /// <param name="maxExpectedYield">maxExpectedYield parameter</param>
    /// <param name="isActive">isActive parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/CropVarieties/search")]
    Task<ApiResponse<PaginatedList<CropVarietySummaryDto>>> SearchCropVarietiesAsync([Query, AliasAs("Term")] string? term,
                                                                                     [Query, AliasAs("CropId")] string? cropId,
                                                                                     [Query, AliasAs("DaysToMaturity")] int? daysToMaturity,
                                                                                     [Query, AliasAs("MinExpectedYield")] decimal? minExpectedYield,
                                                                                     [Query, AliasAs("MaxExpectedYield")] decimal? maxExpectedYield,
                                                                                     [Query, AliasAs("IsActive")] bool? isActive,
                                                                                     [Query, AliasAs("PageNumber")] int pageNumber,
                                                                                     [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/GrowthStageAlerts/{id}")]
    Task<ApiResponse<GrowthStageAlertDto?>> GetGrowthStageAlertByIdQueryAsync(string id, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Put("/api/GrowthStageAlerts/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateGrowthStageAlertAsync(string id, [Body] UpdateGrowthStageAlertRequest request, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Delete("/api/GrowthStageAlerts/{id}")]
    Task<IApiResponse> DeleteGrowthStageAlertAsync(string id, CancellationToken ct = default);

    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/GrowthStageAlerts")]
    Task<ApiResponse<PaginatedList<GrowthStageAlertSummaryDto>>> GetGrowthStageAlertsQueryAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Post("/api/GrowthStageAlerts")]
    Task<ApiResponse<string>> CreateGrowthStageAlertAsync([Body] CreateGrowthStageAlertRequest request, CancellationToken ct = default);

    /// <param name="cropPlantingId">cropPlantingId parameter</param>
    /// <param name="growthStageId">growthStageId parameter</param>
    /// <param name="alertType">alertType parameter</param>
    /// <param name="severity">severity parameter</param>
    /// <param name="isResolved">isResolved parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/GrowthStageAlerts/search")]
    Task<ApiResponse<PaginatedList<GrowthStageAlertSummaryDto>>> SearchGrowthStageAlertsQueryAsync([Query, AliasAs("CropPlantingId")] string? cropPlantingId,
                                                         [Query, AliasAs("GrowthStageId")] string? growthStageId,
                                                         [Query, AliasAs("AlertType")] GrowthAlertType? alertType,
                                                         [Query, AliasAs("Severity")] AlertSeverity? severity,
                                                         [Query, AliasAs("IsResolved")] bool? isResolved,
                                                         [Query, AliasAs("PageNumber")] int pageNumber,
                                                         [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/GrowthStages/{id}")]
    Task<ApiResponse<GrowthStageDto?>> GetGrowthStageByIdQueryAsync(string id, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Put("/api/GrowthStages/{id}")]
    Task<ApiResponse<MessageResponse>> UpdateGrowthStageAsync(string id, [Body] UpdateGrowthStageRequest request, CancellationToken ct = default);

    /// <param name="id">id parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Delete("/api/GrowthStages/{id}")]
    Task<IApiResponse> DeleteGrowthStageAsync(string id, CancellationToken ct = default);

    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/GrowthStages")]
    Task<ApiResponse<PaginatedList<GrowthStageSummaryDto>>> GetGrowthStagesQueryAsync([Query] int pageNumber, [Query] int pageSize, CancellationToken ct = default);

    /// <param name="request">request parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Headers("Content-Type: application/json")]
    [Post("/api/GrowthStages")]
    Task<ApiResponse<string>> CreateGrowthStageAsync([Body] CreateGrowthStageRequest request, CancellationToken ct = default);

    /// <param name="term">term parameter</param>
    /// <param name="minStageSequence">minStageSequence parameter</param>
    /// <param name="maxStageSequence">maxStageSequence parameter</param>
    /// <param name="minDaysAfterPlanting">minDaysAfterPlanting parameter</param>
    /// <param name="maxDaysAfterPlanting">maxDaysAfterPlanting parameter</param>
    /// <param name="temperature">temperature parameter</param>
    /// <param name="humidity">humidity parameter</param>
    /// <param name="pageNumber">pageNumber parameter</param>
    /// <param name="pageSize">pageSize parameter</param>
    /// <returns>
    /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
    /// <list type="table">
    /// <listheader>
    /// <term>Status</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>200</term>
    /// <description>A server side error occurred.</description>
    /// </item>
    /// </list>
    /// </returns>
    [Get("/api/GrowthStages/search")]
    Task<ApiResponse<PaginatedList<GrowthStageSummaryDto>>> SearchGrowthStagesQueryAsync([Query, AliasAs("Term")] string? term,
                                                                                         [Query, AliasAs("MinStageSequence")] int? minStageSequence,
                                                                                         [Query, AliasAs("MaxStageSequence")] int? maxStageSequence,
                                                                                         [Query, AliasAs("MinDaysAfterPlanting")] int? minDaysAfterPlanting,
                                                                                         [Query, AliasAs("MaxDaysAfterPlanting")] int? maxDaysAfterPlanting,
                                                                                         [Query, AliasAs("Temperature")] decimal? temperature,
                                                                                         [Query, AliasAs("Humidity")] decimal? humidity,
                                                                                         [Query, AliasAs("PageNumber")] int pageNumber,
                                                                                         [Query, AliasAs("PageSize")] int pageSize, CancellationToken ct = default);

}