using InfoManager.Application.Common.Models;
using InfoManager.Enum;

namespace InfoManager.Api.Infrastructure;

public static class ResultExtensions
{
    /// <summary>
    /// Chuyển đổi Result thành IResult cho Minimal API.
    /// Phiên bản tối ưu sau khi loại bỏ ActionType và StatusCode khỏi Result.
    /// </summary>
    public static IResult ToHttpResult(this Result result, string? resourceName = null)
    {
        if (!result.Succeeded)
        {
            return CreateProblemResult(result);
        }

        // === Xử lý thành công ===
        var data = GetData(result);

        // Trường hợp có dữ liệu trả về → 200 OK
        if (data is not null)
        {
            // Nếu có resourceName → coi như Create → trả 201 Created + Location
            if (!string.IsNullOrEmpty(resourceName))
            {
                var id = GetIdFromData(data);
                var location = $"/api/{resourceName}/{id}";
                return Results.Created(location, data);
            }

            return Results.Ok(data);
        }

        // Không có dữ liệu → trả 204 No Content (phù hợp với Update, Delete, một số Create)
        return Results.NoContent();
    }

    /// <summary>
    /// Phiên bản dành cho Result<T> (generic)
    /// </summary>
    public static IResult ToHttpResult<T>(this Result<T> result, string? resourceName = null)
    {
        if (!result.Succeeded)
        {
            return CreateProblemResult(result);
        }

        var data = result.Value;

        if (data is not null)
        {
            if (!string.IsNullOrEmpty(resourceName))
            {
                var id = GetIdFromData(data);
                return Results.Created($"/api/{resourceName}/{id}", data);
            }

            return Results.Ok(data);
        }

        return Results.NoContent();
    }

    // ==================== Helper Methods ====================

    private static IResult CreateProblemResult(Result result)
    {
        return Results.Problem(
            detail: result.Errors?.Any() == true
                ? string.Join(" | ", result.Errors)
                : "An error occurred.",
            statusCode: GetStatusCodeFromErrorType(result.Status),
            title: GetProblemTitle(result.Status),
            type: $"https://httpstatuses.com/{GetStatusCodeFromErrorType(result.Status)}",
            extensions: new Dictionary<string, object?>
            {
                ["errorType"] = result.Status.ToString()
            }
        );
    }

    private static object? GetData(Result result)
    {
        // Hỗ trợ cả Result và Result<T>
        return result switch
        {
            Result<object> r => r.Value,
            _ => result.GetType().GetProperty("Value")?.GetValue(result)
        };
    }

    private static object? GetIdFromData(object data)
    {
        return data.GetType().GetProperty("Id")?.GetValue(data) ?? data;
    }

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
            ResultStatus.Error => StatusCodes.Status400BadRequest, // hoặc 500 tùy convention
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