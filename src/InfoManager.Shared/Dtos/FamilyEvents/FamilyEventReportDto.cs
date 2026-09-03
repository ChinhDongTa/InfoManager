namespace InfoManager.Shared.Dtos.FamilyEvents;

/// <summary>
/// Các ngày sinh nhật, kỷ niệm, ngày lễ của các thành viên trong gia đình
/// ở bảng FamilyMembers lấy các ngày sinh nhật, ngày mất. Bảng FamilyEvent để lấy thông tin ngày cưới, ngày ra trường,...
/// </summary>
public record FamilyEventReportDto(
    string Id,
    string FullName,
    DateOnly EventDate,
    string EventName
);
