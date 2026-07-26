namespace InfoManager.Helper;

public static class StringHelpers
{
    /// <summary>
    /// Chuyển danh sách chuỗi thành một dòng các item sẽ được phân biệt bằng separator.
    /// </summary>
    /// <param name="strings">Danh sách chuỗi</param>
    /// <param name="separator">Ký tự phân cách mặc định là ", "</param>
    public static string ToLine(this IEnumerable<string> strings, string separator = ", ")
        => string.Join(separator, strings);

    // <summary>
    /// Kiểm tra xem giá trị mới có khác với giá trị hiện tại không (đã trim và xử lý null).
    /// </summary>
    public static bool IsDifferentFrom(this string? newValue, string? currentValue)
    {
        var normalizedNew = Normalize(newValue);
        var normalizedCurrent = Normalize(currentValue);

        return normalizedNew != normalizedCurrent;
    }

    /// <summary>
    /// Dành cho string không nullable. 
    /// Chỉ trả về true nếu giá trị mới có nội dung và khác giá trị hiện tại.
    /// </summary>
    public static bool HasValueAndIsDifferentFrom(this string? newValue, string currentValue)
    {
        var normalizedNew = Normalize(newValue);
        var normalizedCurrent = Normalize(currentValue) ?? string.Empty;

        return !string.IsNullOrEmpty(normalizedNew) && normalizedNew != normalizedCurrent;
    }

    /// <summary>
    /// Chuẩn hóa chuỗi: nếu null hoặc rỗng thì trả về null, nếu có giá trị thì loại bỏ khoảng trắng đầu và cuối.
    /// </summary>
    /// <param name="value">Giá trị cần chuẩn hóa</param>
    /// <returns>Giá trị đã chuẩn hóa hoặc null nếu rỗng</returns>
    public static string? Normalize(string? value) 
        => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}