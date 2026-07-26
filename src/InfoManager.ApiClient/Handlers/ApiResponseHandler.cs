using InfoManager.Helper;

namespace InfoManager.ApiClient.Handlers;

public static class ApiResponseHandler
{
    public static async Task<ApiResult<T>> HandleAsync<T>(ApiResponse<T> response)
    {
        if (response.IsSuccessStatusCode)
        {
            // Nếu có content thì trả về Ok với dữ liệu
            if (response.Content != null)
                return ApiResult<T>.Ok(response.Content);

            return ApiResult<T>.Ok(default!);
        }

        IEnumerable<string> errorMessages = await GetErrors(response);
        
        return ApiResult<T>.Fail(errorMessages,ResultStatus.Error);
    }

    private static async Task<IEnumerable<string>> GetErrors<T>(ApiResponse<T> response)
    {
        IEnumerable<string> errorMessages = ["Đã xảy ra lỗi."];
        if (response.Error is ApiException apiEx)
        {
            var problem = await apiEx.GetContentAsAsync<ProblemDetails>();
            errorMessages = errorMessages.Append(problem?.Detail ?? problem?.Title ?? apiEx.Message ?? errorMessages.ToLine());

        }
        else
        {
            errorMessages = errorMessages.Append(response.Error?.Message ?? errorMessages.ToLine());
        }
        errorMessages = errorMessages.Append($"Status Code:  {response.StatusCode}");
        return errorMessages;
    }

    // Phiên bản không có dữ liệu trả về (ví dụ: Logout)
    //public static async Task<ApiResult> HandleAsync(ApiResponse<MessageResponse> response)
    //{
    //    if (response.IsSuccessStatusCode)
    //    {
    //        return ApiResult.Ok();
    //    }

    //    IEnumerable<string> errorMessages = await GetErrors(response);

    //    return ApiResult.Fail(errorMessages, (int)response.StatusCode);
    //}

}