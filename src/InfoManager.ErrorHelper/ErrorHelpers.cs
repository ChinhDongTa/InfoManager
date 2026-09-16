using InfoManager.Enum;
using InfoManager.Helper.Properties;

namespace InfoManager.Helper;

/// <summary>
/// Các helper xử lý chuỗi và lấy thông báo từ Resource (.resx)
/// </summary>
public static class ErrorHelpers
{
    #region Error Messages

    /// <summary>
    /// Lấy thông báo lỗi:Error, {0} không tồn tại
    /// </summary>
    public static string GetErrorNotExists(string name)
        => string.Format(Resources.ErrorNotExists, name);

    /// <summary>
    /// Lấy thông báo lỗi:Error,{0} đã tồn tại
    /// </summary>
    public static string GetErrorAlreadyExists(string name)
        => string.Format(Resources.ErrorAlreadyExists, name);

    /// <summary>
    /// Lấy thông báo lỗi:Error, không hợp lệ
    /// </summary>
    public static string GetErrorInvalid(string name)
        => string.Format(Resources.ErrorInvalid, name);

    /// <summary>
    /// Lấy thông báo lỗi:Error, {0} không được để trống
    /// </summary>
    public static string GetErrorNotEmpty(string name)
        => string.Format(Resources.ErrorNotEmpty, name);

    /// <summary>
    /// Lấy thông báo lỗi: Error, {0} vô giá trị !
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GetErrorNull(string name)
        => string.Format(Resources.ErrorNull, name);

    /// <summary>
    /// Lấy thông báo lỗi:{0} không tìm thấy
    /// </summary>
    public static string GetErrorNotFound(string name)
        => string.Format(Resources.ErrorNotFound, name);   // Giữ key cũ nếu chưa sửa trong .resx

    public static string GetErrorNotFoundWithId(string name, object id)
       => string.Format(Resources.ErrorNotFoundWithId, name, id);

    /// <summary>
    /// Lấy thông báo lỗi:Error, không thể thực hiện {0} {1} này
    /// </summary>
    public static string GetErrorCannotAction(ActionType action, string name)
        => string.Format(Resources.ErrorCanNotAction, action.ToDisplayName(), name);

    public static string GetErrorMaxLength(string objectName, int maxLen)
        => string.Format(Resources.ErrorMaxLength, objectName, maxLen);

    /// <summary>
    /// Lấy thông báo lỗi:Error, không thể lấy dữ liệu của {0}
    public static string GetErrorCannotRetrieveData(string name)
        => string.Format(Resources.ErrorCannotRetrieveData, name);

    public static string GetErrorServer(string? error = null)
    {
        if (error == null)
            return Resources.ErrorServer;
        return error;
    }

    public static string GetErrorUnknown => Resources.ErrorUnknown;
    public static string GetErrorBusinessRule => Resources.ErrorBusinessRule;

    /// <summary>
    /// Lấy thông báo lỗi tùy chọn
    /// </summary>
    public static string GetErrorCustom(string? message = null)
    {
        if (string.IsNullOrWhiteSpace(message))
            return "Error, Đã xảy ra lỗi.";

        return string.Format(Resources.ErrorCustom, message.Trim());
    }

    public static string GetErrorOutOfRange(string objectName, object from, object to)
        => string.Format(Resources.ErrorOutOfRange, objectName, from, to);

    /// <summary>
    /// Lấy thông báo lỗi: Xung đột dữ liệu (409 Conflict)
    /// </summary>
    public static string GetErrorConflict()
        => Resources.ErrorConflict;

    /// <summary>
    /// Lấy thông báo lỗi: Xung đột dữ liệu (409 Conflict)
    /// </summary>
    public static string GetErrorConflictWithDetails(string details)
        => string.Format(Resources.ErrorConflictWithDetails, details);

    /// <summary>
    /// Lấy thông báo lỗi: Không được phép truy cập (401 Unauthorized)
    /// </summary>
    public static string GetErrorUnauthorized(string? message = null)
        => message ?? Resources.ErrorUnauthorized;

    /// <summary>
    /// Lấy thông báo lỗi: Bị cấm truy cập (403 Forbidden)
    /// </summary>
    public static string GetErrorForbidden(string? message = null)
        => message ?? Resources.ErrorForbidden;

    /// <summary>
    /// Lấy thông báo lỗi: Không thể xóa
    /// </summary>
    public static string GetErrorCannotDelete(string reason = "")
        => string.IsNullOrEmpty(reason)
            ? Resources.ErrorCannotDelete
            : string.Format(Resources.ErrorCannotDeleteWithReason, reason);

    /// <summary>
    /// Lấy thông báo lỗi: {0} là bắt buộc
    /// </summary>
    public static string GetErrorRequired(string fieldName)
        => string.Format(Resources.ErrorRequired, fieldName);

    /// <summary>
    /// Lấy thông báo lỗi: {0} không khớp
    /// </summary>
    public static string GetErrorMismatch(string fieldName)
        => string.Format(Resources.ErrorMismatch, fieldName);

    /// <summary>
    /// Lấy thông báo lỗi: Thao tác không thành công
    /// </summary>
    public static string GetErrorOperationFailed(string operationType = "Operation")
        => $"{operationType} failed";

    #endregion Error Messages

    #region Success Messages

    /// <summary>
    /// Lấy thông báo thành công với ActionType
    /// </summary>
    public static string GetSuccessAction(ActionType action, string name)
        => string.Format(Resources.SuccessAction, action.ToDisplayName(), name);

    /// <summary>
    /// Lấy thông báo thành công tùy chọn
    /// </summary>
    public static string GetSuccessCustom(string? message = null)
    {
        if (string.IsNullOrWhiteSpace(message))
            return "Success, Thao tác thành công.";

        return string.Format(Resources.SuccessCustom, message.Trim());
    }

    /// <summary>
    /// Lấy thông báo thành công: Đã đăng xuất thành công
    /// </summary>
    public static string GetSuccessLoggedOut()
        => "Logged out successfully";

    public static string GetInfoCustom(string? message = null)
    {
        if (string.IsNullOrWhiteSpace(message))
            return Resources.InfoNoChanges;
        return $"Info, {message.Trim()}";
    }

    #endregion Success Messages

    #region Generic Helpers (Khuyến nghị dùng)

    /// <summary>
    /// Lấy thông báo theo Resource Key (dùng cho các trường hợp linh hoạt)
    /// </summary>
    public static string Get(string resourceKey, params object[] args)
    {
        var template = Resources.ResourceManager.GetString(resourceKey);
        return string.IsNullOrEmpty(template)
            ? $"[Missing resource: {resourceKey}]"
            : string.Format(template, args);
    }

    /// <summary>
    /// Lấy thông báo lỗi theo Resource Key
    /// </summary>
    public static string GetError(string resourceKey, params object[] args)
        => Get(resourceKey, args);

    /// <summary>
    /// fieldName phải lớn hơn hoặc bằng minValue
    /// </summary>
    /// <param name="fieldName"></param>
    /// <param name="minValue"></param>
    /// <returns></returns>
    public static string GetErrorMinValue(string fieldName, object minValue)
        => string.Format(Resources.ErrorMinValue, fieldName, minValue);

    /// <summary>
    /// v1 tối đa là v2
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    public static string GetErrorMaxValue(string v1, string v2)
        => string.Format(Resources.ErrorMaxValue, v1, v2);

    #endregion Generic Helpers (Khuyến nghị dùng)
}