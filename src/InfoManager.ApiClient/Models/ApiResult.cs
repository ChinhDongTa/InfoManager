namespace InfoManager.ApiClient.Models;

public record ApiResult
{
    public bool Success { get; init; }
    public IEnumerable<string>? ErrorMessage { get; init; }
    public ResultStatus StatusCode { get; init; }
    public static ApiResult Ok(ResultStatus statusCode = ResultStatus.Ok) =>
        new() { Success = true, StatusCode = statusCode };
    public static ApiResult Fail(IEnumerable<string> errors, ResultStatus statusCode) =>
        new() { Success = false, ErrorMessage = errors, StatusCode = statusCode };
}
public record ApiResult<T> : ApiResult
{
    public T? Data { get; init; }

    public static ApiResult<T> Ok(T data, ResultStatus statusCode = ResultStatus.Ok) =>
        new() { Success = true, Data = data, StatusCode = statusCode };

    public static new ApiResult<T> Fail(IEnumerable<string> errors, ResultStatus statusCode=ResultStatus.Error) =>
        new() { Success = false, ErrorMessage = errors, StatusCode = statusCode };
}