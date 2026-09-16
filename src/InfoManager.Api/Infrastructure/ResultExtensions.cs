using InfoManager.Api.Extensions;
using InfoManager.Application.Common.Models;
using InfoManager.Enum;
using System.Text.RegularExpressions;

namespace InfoManager.Api.Infrastructure;

/// <summary>
/// Hỗ trợ từ Grok
/// </summary>
public static class ResultExtensions
{
    private static readonly Regex ValidResourceNamePattern = new(@"^[a-zA-Z0-9\-_]+$", RegexOptions.Compiled);

    /// <summary>
    /// Chuyển đổi Result thành IResult cho Minimal API.
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public static IResult ToHttpResult(this Result result)
    {
        if (!result.Succeeded)
            return CreateProblemResult(result);

        return CreateSuccessResult(result, GetData(result));
    }

    /// <summary>
    /// Chuyển đổi Result<T> thành IResult cho Minimal API.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="result"></param>
    /// <returns></returns>
    public static IResult ToHttpResult<T>(this Result<T> result)
    {
        if (!result.Succeeded)
            return CreateProblemResult(result);

        return CreateSuccessResult(result, result.Value);
    }

    /// <summary>
    /// Chuyển đổi Result<string> thành IResult cho Minimal API, đặc biệt xử lý trường hợp Created với Location.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="resourceName"></param>
    /// <returns></returns>
    public static IResult ToCreatedHttpResult(this Result<string> result, string resourceName)
    {
        // Chỉ khi thật sự Created thành công mới tạo Result mới có Location
        if (result.Succeeded
            && result.Status == ResultStatus.Created
            && !string.IsNullOrWhiteSpace(result.Value))
        {
            var location = resourceName.ToLocationUrl(result.Value);
            ValidateLocation(location);

            // Dùng factory method có sẵn → Location được set hợp lệ
            return Result<string>.Created(result.Value, location).ToHttpResult();
        }

        // Các trường hợp còn lại (lỗi hoặc không phải Created)
        return result.ToHttpResult();
    }

    // ==================== Success ====================

    private static IResult CreateSuccessResult(Result result, object? data)
    {
        var hasMessage = !string.IsNullOrWhiteSpace(result.SuccessMessage);

        // Helper: tạo body có message nếu cần
        object? CreateBody()
        {
            if (!hasMessage)
                return data; // không có message → trả data thuần (tương thích ngược)

            return data is not null
                ? new { message = result.SuccessMessage, data }          // có cả message + data
                : new { message = result.SuccessMessage };               // chỉ có message
        }
        return result.Status switch
        {
            // === Created ===
            ResultStatus.Created =>
          !string.IsNullOrWhiteSpace(result.Location)
              ? Results.Created(result.Location, CreateBody())
              : Results.Json(CreateBody(), statusCode: StatusCodes.Status201Created),

            // === No Content ===
            ResultStatus.NoContent => Results.NoContent(),

            // === Ok ===
            ResultStatus.Ok => data is not null
                ? Results.Ok(data)
                : Results.Ok(),          // 200 OK kể cả khi không có body

            // === Các trường hợp success khác (phòng hờ) ===
            _ => data is not null
                ? Results.Ok(data)
                : Results.NoContent()
        };
    }

    // ==================== Validation Location ====================

    /// <summary>
    /// Kiểm tra hợp lệ của Location URL. Location phải bắt đầu bằng "/api/" và chỉ chứa các ký tự an toàn.
    /// </summary>
    /// <param name="location"></param>
    /// <exception cref="ArgumentException"></exception>
    private static void ValidateLocation(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            throw new ArgumentException("Location cannot be null or empty.", nameof(location));
        }

        if (location.Length > 200)
        {
            throw new ArgumentException("Location cannot exceed 200 characters.", nameof(location));
        }

        // Chỉ cho phép các ký tự an toàn trong URL path (tránh header injection)
        // Ví dụ hợp lệ: /api/categories/abc-123  hoặc  /api/users/42
        if (!location.StartsWith("/api/", StringComparison.OrdinalIgnoreCase) ||
            location.Contains("..") ||
            location.Contains("//") ||
            !ValidResourceNamePattern.IsMatch(location.Replace("/api/", "").Replace("/", "")))
        {
            throw new ArgumentException(
                "Location is invalid. It must start with /api/ and only contain alphanumeric characters, hyphens, underscores and slashes.",
                nameof(location));
        }
    }

    // ==================== Error (Problem Details) ====================

    private static IResult CreateProblemResult(Result result)
    {
        var statusCode = GetStatusCodeFromErrorType(result.Status);
        var errorDetail = GetErrorDetail(result);

        var extensions = new Dictionary<string, object?>
        {
            ["errorType"] = result.Status.ToString(),
            ["timestamp"] = DateTime.UtcNow.ToString("O")
        };

        // Tự động lấy CorrelationId nếu có (Result<T>)
        if (result.GetType().GetProperty("CorrelationId")?.GetValue(result) is string correlationId
            && !string.IsNullOrWhiteSpace(correlationId))
        {
            extensions["correlationId"] = correlationId;
        }

        return Results.Problem(
            detail: errorDetail,
            statusCode: statusCode,
            title: GetProblemTitle(result.Status),
            type: $"https://httpstatuses.com/{statusCode}",
            extensions: extensions
        );
    }

    private static string GetErrorDetail(Result result)
    {
        if (result.Errors == null || !result.Errors.Any())
        {
            return "An error occurred.";
        }

        var errorMessage = string.Join(" | ", result.Errors);

        var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
        if (!isDevelopment && result.Status == ResultStatus.CriticalError)
        {
            return "An internal server error occurred. Please contact support.";
        }

        return errorMessage;
    }

    private static object? GetData(Result result)
    {
        return result switch
        {
            Result<object> r => r.Value,
            _ => result.GetType().GetProperty("Value")?.GetValue(result)
        };
    }

    // ==================== Mapping ====================

    private static int GetStatusCodeFromErrorType(ResultStatus resultStatus)
    {
        return resultStatus switch
        {
            ResultStatus.Ok => StatusCodes.Status200OK,
            ResultStatus.Created => StatusCodes.Status201Created,
            ResultStatus.NoContent => StatusCodes.Status204NoContent,
            ResultStatus.Invalid => StatusCodes.Status400BadRequest,
            ResultStatus.NotFound => StatusCodes.Status404NotFound,
            ResultStatus.Unauthorized => StatusCodes.Status401Unauthorized,
            ResultStatus.Forbidden => StatusCodes.Status403Forbidden,
            ResultStatus.Conflict => StatusCodes.Status409Conflict,
            ResultStatus.Error => StatusCodes.Status400BadRequest,
            ResultStatus.CriticalError => StatusCodes.Status500InternalServerError,
            ResultStatus.Unavailable => StatusCodes.Status503ServiceUnavailable,
            _ => StatusCodes.Status500InternalServerError
        };
    }

    private static string GetProblemTitle(ResultStatus resultStatus)
    {
        return resultStatus switch
        {
            ResultStatus.Ok => "Success",
            ResultStatus.Created => "Resource created",
            ResultStatus.NoContent => "No content",
            ResultStatus.Invalid => "Invalid request",
            ResultStatus.NotFound => "Resource not found",
            ResultStatus.Unauthorized => "Unauthorized access",
            ResultStatus.Forbidden => "Forbidden",
            ResultStatus.Conflict => "Conflict detected",
            ResultStatus.Error => "Error occurred",
            ResultStatus.CriticalError => "Critical server error",
            ResultStatus.Unavailable => "Service unavailable",
            _ => "Unknown status"
        };
    }
}

//public static class ResultExtensions
//{
//    private static readonly Regex ValidResourceNamePattern = new(@"^[a-zA-Z0-9\-_]+$", RegexOptions.Compiled);

//    /// <summary>
//    /// Chuyển đổi Result thành IResult cho Minimal API.
//    /// Phiên bản tối ưu sau khi loại bỏ ActionType và StatusCode khỏi Result.
//    /// </summary>
//    public static IResult ToHttpResult(this Result result, string? resourceName = null)
//    {
//        if (!result.Succeeded)
//        {
//            return CreateProblemResult(result);
//        }

//        // === Xử lý thành công ===
//        var data = GetData(result);

//        // Trường hợp có dữ liệu trả về → 200 OK, hoặc 201 Created nếu có resourceName
//        if (data is not null)
//        {
//            // Nếu có resourceName → coi như Create → trả 201 Created + Location
//            if (!string.IsNullOrEmpty(resourceName))
//            {
//                ValidateResourceName(resourceName);
//                var id = GetIdFromData(data);
//                var location = id != null ? $"/api/{resourceName}/{id}" : $"/api/{resourceName}";
//                return Results.Created(location, data);
//            }

//            return Results.Ok(data);
//        }

//        // Không có dữ liệu → trả 204 No Content (phù hợp với Update, Delete, một số Create)
//        return Results.NoContent();
//    }

//    /// <summary>
//    /// Phiên bản dành cho Result<T> (generic)
//    /// </summary>
//    public static IResult ToHttpResult<T>(this Result<T> result, string? resourceName = null)
//    {
//        if (!result.Succeeded)
//        {
//            return CreateProblemResult(result);
//        }

//        var data = result.Value;

//        if (data is not null)
//        {
//            if (!string.IsNullOrEmpty(resourceName))
//            {
//                ValidateResourceName(resourceName);
//                var id = GetIdFromData(data);
//                return Results.Created($"/api/{resourceName}/{id}", data);
//            }

//            return Results.Ok(data);
//        }

//        return Results.NoContent();
//    }

//    // ==================== Helper Methods ====================

//    private static IResult CreateProblemResult(Result result)
//    {
//        var statusCode = GetStatusCodeFromErrorType(result.Status);
//        var errorDetail = GetErrorDetail(result);

//        return Results.Problem(
//            detail: errorDetail,
//            statusCode: statusCode,
//            title: GetProblemTitle(result.Status),
//            type: $"https://httpstatuses.com/{statusCode}",
//            extensions: new Dictionary<string, object?>
//            {
//                ["errorType"] = result.Status.ToString(),
//                ["timestamp"] = DateTime.UtcNow.ToString("O")
//            }
//        );
//    }

//    private static string GetErrorDetail(Result result)
//    {
//        if (!result.Errors?.Any() == true)
//        {
//            return "An error occurred.";
//        }

//        var errorMessage = string.Join(" | ", result.Errors ?? ["An error occurred."]);

//        // Chỉ hiển thị chi tiết lỗi nếu không phải production
//        var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
//        if (!isDevelopment && result.Status == ResultStatus.CriticalError)
//        {
//            return "An internal server error occurred. Please contact support.";
//        }

//        return errorMessage;
//    }

//    private static object? GetData(Result result)
//    {
//        // Hỗ trợ cả Result và Result<T>
//        return result switch
//        {
//            Result<object> r => r.Value,
//            _ => result.GetType().GetProperty("Value")?.GetValue(result)
//        };
//    }

//    private static object GetIdFromData(object data)
//    {
//        if (data == null)
//        {
//            throw new InvalidOperationException("Data cannot be null.");
//        }

//        var dataType = data.GetType();

//        // Xử lý primitive types (string, int, Guid, long, etc.)
//        if (IsPrimitiveType(dataType))
//        {
//            return data;
//        }

//        // Xử lý object types - tìm property 'Id'
//        var idProp = dataType.GetProperty("Id") ?? throw new InvalidOperationException(
//                $"Type '{dataType.Name}' must have an 'Id' property. " +
//                $"Available properties: {string.Join(", ", dataType.GetProperties().Select(p => p.Name))}");

//        var idValue = idProp.GetValue(data);
//        return idValue ?? throw new InvalidOperationException(
//                $"The 'Id' property of '{dataType.Name}' cannot be null.");
//    }

//    private static bool IsPrimitiveType(Type type)
//    {
//        // Xử lý Nullable<T>
//        type = Nullable.GetUnderlyingType(type) ?? type;

//        return type.IsPrimitive          // int, long, short, byte,...
//            || type == typeof(string)
//            || type == typeof(Guid);      // phòng trường hợp còn truyền Guid thô
//    }

//    private static void ValidateResourceName(string resourceName)
//    {
//        if (string.IsNullOrWhiteSpace(resourceName))
//        {
//            throw new ArgumentException("Resource name cannot be null or empty.", nameof(resourceName));
//        }

//        if (resourceName.Length > 50)
//        {
//            throw new ArgumentException("Resource name cannot exceed 50 characters.", nameof(resourceName));
//        }

//        if (!ValidResourceNamePattern.IsMatch(resourceName))
//        {
//            throw new ArgumentException(
//                "Resource name can only contain alphanumeric characters, hyphens, and underscores.",
//                nameof(resourceName));
//        }
//    }

//    private static int GetStatusCodeFromErrorType(ResultStatus resultStatus)
//    {
//        return resultStatus switch
//        {
//            ResultStatus.Ok => StatusCodes.Status200OK,
//            ResultStatus.Created => StatusCodes.Status201Created,
//            ResultStatus.NoContent => StatusCodes.Status204NoContent,
//            ResultStatus.Invalid => StatusCodes.Status400BadRequest,
//            ResultStatus.NotFound => StatusCodes.Status404NotFound,
//            ResultStatus.Unauthorized => StatusCodes.Status401Unauthorized,
//            ResultStatus.Forbidden => StatusCodes.Status403Forbidden,
//            ResultStatus.Conflict => StatusCodes.Status409Conflict,
//            ResultStatus.Error => StatusCodes.Status400BadRequest,
//            ResultStatus.CriticalError => StatusCodes.Status500InternalServerError,
//            ResultStatus.Unavailable => StatusCodes.Status503ServiceUnavailable,
//            _ => StatusCodes.Status500InternalServerError
//        };
//    }

//    private static string GetProblemTitle(ResultStatus resultStatus)
//    {
//        return resultStatus switch
//        {
//            ResultStatus.Ok => "Success",
//            ResultStatus.Created => "Resource created",
//            ResultStatus.NoContent => "No content",
//            ResultStatus.Invalid => "Invalid request",
//            ResultStatus.NotFound => "Resource not found",
//            ResultStatus.Unauthorized => "Unauthorized access",
//            ResultStatus.Forbidden => "Forbidden",
//            ResultStatus.Conflict => "Conflict detected",
//            ResultStatus.Error => "Error occurred",
//            ResultStatus.CriticalError => "Critical server error",
//            ResultStatus.Unavailable => "Service unavailable",
//            _ => "Unknown status"
//        };
//    }
//}