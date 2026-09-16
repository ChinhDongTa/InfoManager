namespace InfoManager.Api.Extensions;

/// <summary>
/// Các extension method tiện ích cho các kiểu dữ liệu nguyên thủy (primitive types) như int, string, bool, v.v.
/// </summary>
public static class PrimitiveExtensions
{
    public static bool IsMonthValid(this int num) => num > 0 && num <= 12;

    public static string ToLocationUrl(this string location, string id)
    {
        return $"/api/{location}/{id}";
    }
}