using InfoManager.Application.Features.SFMS.Infrastructure.Commands;
using InfoManager.Application.Features.SFMS.Infrastructure.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

/// <summary>
/// Mapping từ Request sang Command của DeviceAlert.
/// </summary>
public static class DeviceAlertMappings
{
    public static CreateDeviceAlertCommand ToCreateCommand(CreateDeviceAlertRequest request)
        => new()
        {
            DeviceId = request.DeviceId,
            AlertType = request.AlertType,
            Message = request.Message,
            Severity = request.Severity,
            AlertTime = request.AlertTime,
            IsResolved = request.IsResolved,
            ResolutionNotes = request.ResolutionNotes
        };

    public static UpdateDeviceAlertCommand ToUpdateCommand(UpdateDeviceAlertRequest request, string id)
        => new()
        {
            Id = id,
            AlertType = request.AlertType,
            Message = request.Message,
            Severity = request.Severity,
            ResolvedTime = request.ResolvedTime,
            IsResolved = request.IsResolved,
            ResolutionNotes = request.ResolutionNotes
        };

    public static SearchDeviceAlertsQuery ToSearchQuery(SearchDeviceAlertsRequest request)
        => new(request.Term,
               request.AlertType,
               request.Severity,
               request.IsResolved,
               request.StartAlertTime,
               request.EndAlertTime,
               request.PageNumber,
               request.PageSize);
}