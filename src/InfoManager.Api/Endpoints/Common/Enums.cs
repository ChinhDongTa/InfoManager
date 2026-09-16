using InfoManager.Enum;
using InfoManager.Shared.Dtos.Common;
using Microsoft.AspNetCore.Http.HttpResults;

namespace InfoManager.Api.Endpoints.Common;

public class Enums : EndpointGroupBase
{
    public override string GroupName => "Enums";

    public override void Map(RouteGroupBuilder group)
    {
        group.MapGet(GetEnumValues, "{enumName}");
    }

    public async Task<Results<Ok<IEnumerable<SelectListItemDto>>, NotFound>> GetEnumValues([FromRoute] string enumName)
    {
        // Dùng reflection để lấy enum theo tên
        var enumType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.IsEnum && t.Name.Equals(enumName, StringComparison.OrdinalIgnoreCase));
        if (enumType == null)
            return TypedResults.NotFound();
        // Lấy tất cả giá trị của enum
        var values = System.Enum.GetValues(enumType);

        // Map: Id = giá trị int của enum (dạng string), Name = DisplayName (ưu tiên [Display] → [Description] → tên enum)
        var result = values.Cast<System.Enum>()
            .Select(v => new SelectListItemDto(
                v.ToInt().ToString(),      // Id = giá trị int
                v.ToDisplayName()          // Name = tên hiển thị đẹp
            ));

        return TypedResults.Ok(result);
    }
}