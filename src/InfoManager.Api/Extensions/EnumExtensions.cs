using InfoManager.Enum;
using InfoManager.Shared.Dtos.Common;

namespace InfoManager.Api.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// Chuyển bất kỳ enum nào thành IEnumerable<EnumResponse> – chuẩn trả về client
    /// Sắp xếp theo giá trị enum (Id)
    /// </summary>
    public static IEnumerable<SelectListItemDto> ToEnumResponse<T>() where T : struct, System.Enum
    {
        return
        [
            ..System.Enum.GetValues<T>()
                  .Select(e => new SelectListItemDto(
                      Id: e.ToString(),
                      Name: e.ToDisplayName()
                  ))
                  .OrderBy(x => x.Name)
        ];
    }
}
