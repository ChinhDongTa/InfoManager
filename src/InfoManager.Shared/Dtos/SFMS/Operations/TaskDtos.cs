namespace InfoManager.Shared.Dtos.SFMS.Operations;

using InfoManager.Enum.SFMS;

/// <summary>
/// DTO chi tiết công việc / hoạt động trên nông trại
/// </summary>
public record TaskDto(
    string Id,

    /// <summary>
    /// Tên công việc. [MaxLength(200)]
    /// </summary>
    string TaskName,

    /// <summary>
    /// Mô tả công việc. [MaxLength(1000)]
    /// </summary>
    string? Description,

    /// <summary>
    /// ID thửa ruộng / ô ruộng liên quan
    /// </summary>
    string FieldId,

    /// <summary>
    /// Tên thửa ruộng / ô ruộng liên quan
    /// </summary>
    string? FieldName,

    /// <summary>
    /// ID lần trồng (CropPlanting) liên quan (tùy chọn)
    /// </summary>
    string? CropPlantingId,

    /// <summary>
    /// Tên lần trồng liên quan
    /// </summary>
    string? CropPlantingName,

    /// <summary>
    /// Loại công việc (Planting, Weeding, Spraying, Harvesting, ...)
    /// </summary>
    TaskType TaskType,

    /// <summary>
    /// Tên loại công việc
    /// </summary>
    string TaskTypeName,

    /// <summary>
    /// ID thiết bị liên quan (tùy chọn)
    /// </summary>
    string? EquipmentId,

    /// <summary>
    /// Tên thiết bị liên quan
    /// </summary>
    string? EquipmentName,

    /// <summary>
    /// Trạng thái công việc
    /// </summary>
    TaskStatus Status,

    /// <summary>
    /// Tên trạng thái công việc
    /// </summary>
    string StatusName,

    /// <summary>
    /// Ngày bắt đầu dự kiến
    /// </summary>
    DateTimeOffset ScheduledStartDate,

    /// <summary>
    /// Ngày kết thúc dự kiến
    /// </summary>
    DateTimeOffset? ScheduledEndDate,

    /// <summary>
    /// Ngày bắt đầu thực tế
    /// </summary>
    DateTimeOffset? ActualStartDate,

    /// <summary>
    /// Ngày kết thúc thực tế
    /// </summary>
    DateTimeOffset? ActualEndDate,

    /// <summary>
    /// Thời lượng công việc (giờ)
    /// </summary>
    decimal? DurationHours,

    /// <summary>
    /// Diện tích làm việc (hecta)
    /// </summary>
    decimal? WorkArea,

    /// <summary>
    /// Người được phân công / chịu trách nhiệm. [MaxLength(100)]
    /// </summary>
    string? AssignedTo,

    /// <summary>
    /// Mức độ ưu tiên
    /// </summary>
    TaskPriority Priority,

    /// <summary>
    /// Tên mức độ ưu tiên
    /// </summary>
    string PriorityName,

    /// <summary>
    /// Tỷ lệ hoàn thành (0-100)
    /// </summary>
    decimal? CompletionPercentage,

    /// <summary>
    /// Ghi chú / bình luận về công việc. [MaxLength(1000)]
    /// </summary>
    string? Notes
);

/// <summary>
/// DTO tóm tắt công việc / hoạt động trên nông trại
/// </summary>
public record TaskSummaryDto(
    string Id,

    /// <summary>
    /// Tên công việc. [MaxLength(200)]
    /// </summary>
    string TaskName,

    /// <summary>
    /// Tên thửa ruộng / ô ruộng liên quan
    /// </summary>
    string? FieldName,

    /// <summary>
    /// Tên loại công việc
    /// </summary>
    string TaskTypeName,

    /// <summary>
    /// Tên trạng thái công việc
    /// </summary>
    string StatusName,

    /// <summary>
    /// Ngày bắt đầu dự kiến
    /// </summary>
    DateTimeOffset ScheduledStartDate,

    /// <summary>
    /// Ngày kết thúc dự kiến
    /// </summary>
    DateTimeOffset? ScheduledEndDate,

    /// <summary>
    /// Người được phân công / chịu trách nhiệm. [MaxLength(100)]
    /// </summary>
    string? AssignedTo,

    /// <summary>
    /// Tên mức độ ưu tiên
    /// </summary>
    string PriorityName,

    /// <summary>
    /// Tỷ lệ hoàn thành (0-100)
    /// </summary>
    decimal? CompletionPercentage
);

/// <summary>
/// Request tìm kiếm công việc / hoạt động trên nông trại
/// </summary>
/// <param name="Term"></param>
/// <param name="TaskType"></param>
/// <param name="ScheduledtDate"></param>
/// <param name="Priority"></param>
/// <param name="PageNumber"></param>
/// <param name="PageSize"></param>
public record SearchTaskDtoRequest(string? Term,
                                   TaskType? TaskType,
                                   DateTimeOffset? ScheduledtDate,
                                   TaskPriority? Priority,
                                   int PageNumber,
                                   int PageSize);

/// <summary>
/// Request tạo công việc / hoạt động trên nông trại
/// </summary>
public record CreateTaskDtoRequest(
    /// <summary>
    /// Tên công việc. [MaxLength(200)]
    /// </summary>
    string TaskName,

    /// <summary>
    /// Mô tả công việc. [MaxLength(1000)]
    /// </summary>
    string? Description,

    /// <summary>
    /// ID thửa ruộng / ô ruộng liên quan
    /// </summary>
    string FieldId,

    /// <summary>
    /// ID lần trồng (CropPlanting) liên quan (tùy chọn)
    /// </summary>
    string? CropPlantingId,

    /// <summary>
    /// Loại công việc (Planting, Weeding, Spraying, Harvesting, ...)
    /// </summary>
    TaskType TaskType,

    /// <summary>
    /// ID thiết bị liên quan (tùy chọn)
    /// </summary>
    string? EquipmentId,

    /// <summary>
    /// Trạng thái công việc
    /// </summary>
    TaskStatus? Status,

    /// <summary>
    /// Ngày bắt đầu dự kiến
    /// </summary>
    DateTimeOffset ScheduledStartDate,

    /// <summary>
    /// Ngày kết thúc dự kiến
    /// </summary>
    DateTimeOffset? ScheduledEndDate,

    /// <summary>
    /// Ngày bắt đầu thực tế
    /// </summary>
    DateTimeOffset? ActualStartDate,

    /// <summary>
    /// Ngày kết thúc thực tế
    /// </summary>
    DateTimeOffset? ActualEndDate,

    /// <summary>
    /// Thời lượng công việc (giờ)
    /// </summary>
    decimal? DurationHours,

    /// <summary>
    /// Diện tích làm việc (hecta)
    /// </summary>
    decimal? WorkArea,

    /// <summary>
    /// Người được phân công / chịu trách nhiệm. [MaxLength(100)]
    /// </summary>
    string? AssignedTo,

    /// <summary>
    /// Mức độ ưu tiên
    /// </summary>
    TaskPriority? Priority,

    /// <summary>
    /// Tỷ lệ hoàn thành (0-100)
    /// </summary>
    decimal? CompletionPercentage,

    /// <summary>
    /// Ghi chú / bình luận về công việc. [MaxLength(1000)]
    /// </summary>
    string? Notes
);

/// <summary>
/// Request cập nhật công việc / hoạt động trên nông trại
/// </summary>
public record UpdateTaskDtoRequest(
    string Id,

    /// <summary>
    /// Tên công việc. [MaxLength(200)]
    /// </summary>
    string TaskName,

    /// <summary>
    /// Mô tả công việc. [MaxLength(1000)]
    /// </summary>
    string? Description,

    /// <summary>
    /// ID thửa ruộng / ô ruộng liên quan
    /// </summary>
    string FieldId,

    /// <summary>
    /// ID lần trồng (CropPlanting) liên quan (tùy chọn)
    /// </summary>
    string? CropPlantingId,

    /// <summary>
    /// Loại công việc (Planting, Weeding, Spraying, Harvesting, ...)
    /// </summary>
    TaskType TaskType,

    /// <summary>
    /// ID thiết bị liên quan (tùy chọn)
    /// </summary>
    string? EquipmentId,

    /// <summary>
    /// Trạng thái công việc
    /// </summary>
    TaskStatus Status,

    /// <summary>
    /// Ngày bắt đầu dự kiến
    /// </summary>
    DateTimeOffset ScheduledStartDate,

    /// <summary>
    /// Ngày kết thúc dự kiến
    /// </summary>
    DateTimeOffset? ScheduledEndDate,

    /// <summary>
    /// Ngày bắt đầu thực tế
    /// </summary>
    DateTimeOffset? ActualStartDate,

    /// <summary>
    /// Ngày kết thúc thực tế
    /// </summary>
    DateTimeOffset? ActualEndDate,

    /// <summary>
    /// Thời lượng công việc (giờ)
    /// </summary>
    decimal? DurationHours,

    /// <summary>
    /// Diện tích làm việc (hecta)
    /// </summary>
    decimal? WorkArea,

    /// <summary>
    /// Người được phân công / chịu trách nhiệm. [MaxLength(100)]
    /// </summary>
    string? AssignedTo,

    /// <summary>
    /// Mức độ ưu tiên
    /// </summary>
    TaskPriority Priority,

    /// <summary>
    /// Tỷ lệ hoàn thành (0-100)
    /// </summary>
    decimal? CompletionPercentage,

    /// <summary>
    /// Ghi chú / bình luận về công việc. [MaxLength(1000)]
    /// </summary>
    string? Notes
);