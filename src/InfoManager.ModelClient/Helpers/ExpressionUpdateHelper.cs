using System.Reflection;

namespace InfoManager.ModelClient.Helpers;

public static class ExpressionUpdateHelper
{
    /// <summary>
    /// Tạo DTO chỉ chứa các trường thực sự thay đổi.
    /// Hỗ trợ tốt việc set null cho các trường nullable (DateTime?, int?, ...).
    /// </summary>
    public static TUpdate CreateUpdateDto<TEdit, TUpdate>(TEdit edit, TUpdate original)
        where TEdit : class
        where TUpdate : class
    {
        var result = Activator.CreateInstance<TUpdate>()!;

        var editProperties = typeof(TEdit).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in editProperties)
        {
            // Bỏ qua các property không có setter
            if (!prop.CanRead) continue;

            var newValue = prop.GetValue(edit);
            var oldValue = GetPropertyValue(original, prop.Name);

            // Luôn giữ Id
            if (prop.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
            {
                SetPropertyValue(result, prop.Name, newValue);
                continue;
            }

            if (HasChanges(newValue, oldValue))
            {
                SetPropertyValue(result, prop.Name, newValue);
            }
        }

        return result;
    }

    private static bool HasChanges(object? newValue, object? oldValue)
    {
        // Xử lý string không phân biệt hoa thường
        if (newValue is string newStr && oldValue is string oldStr)
            return !string.Equals(newStr, oldStr, StringComparison.OrdinalIgnoreCase);

        // So sánh null an toàn
        if (newValue is null && oldValue is null) return false;
        if (newValue is null || oldValue is null) return true;

        return !Equals(newValue, oldValue);
    }

    private static void SetPropertyValue(object target, string propertyName, object? value)
    {
        var property = target.GetType().GetProperty(propertyName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

        if (property != null && property.CanWrite)
        {
            // Hỗ trợ ép kiểu an toàn cho Nullable<T>
            if (value is null && Nullable.GetUnderlyingType(property.PropertyType) != null)
            {
                property.SetValue(target, null);
            }
            else
            {
                property.SetValue(target, value);
            }
        }
    }
    private static object? GetPropertyValue(object target, string propertyName)
    {
        var property = target.GetType().GetProperty(propertyName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

        return property?.GetValue(target);
    }
}
