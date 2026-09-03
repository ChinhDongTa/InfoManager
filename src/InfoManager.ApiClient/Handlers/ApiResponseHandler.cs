namespace InfoManager.ApiClient.Handlers;

public static class ApiResponseHandler
{
    public static async Task<ApiResult<T>> HandleAsync<T>(ApiResponse<T> response)
    {
        if (response.IsSuccessStatusCode)
        {
            return response.Content is not null
                ? ApiResult<T>.Ok(response.Content)
                : ApiResult<T>.Ok(default!);
        }

        var errors = await ExtractErrors(response);
        return ApiResult<T>.Fail(errors, ResultStatus.Error);
    }

    public static async Task<ApiResult> HandleAsync(IApiResponse response)
    {
        if (response.IsSuccessStatusCode)
            return ApiResult.Ok();

        var errors = await ExtractErrors(response);
        return ApiResult.Fail(errors, ResultStatus.Error);
    }

    private static async Task<IReadOnlyList<string>> ExtractErrors(IApiResponse response)
    {
        var errors = new List<string>();

        if (response.Error is ApiException apiEx)
        {
            try
            {
                var problem = await apiEx.GetContentAsAsync<ProblemDetails>();

                if (problem is not null)
                {
                    if (!string.IsNullOrWhiteSpace(problem.Detail))
                        errors.Add(problem.Detail);
                    else if (!string.IsNullOrWhiteSpace(problem.Title))
                        errors.Add(problem.Title);
                }
            }
            catch
            {
                // Bỏ qua nếu không deserialize được ProblemDetails
            }

            // Fallback nếu chưa có message
            if (errors.Count == 0)
            {
                if (!string.IsNullOrWhiteSpace(apiEx.Content))
                    errors.Add(apiEx.Content);
                else if (!string.IsNullOrWhiteSpace(apiEx.Message))
                    errors.Add(apiEx.Message);
            }
        }

        // Nếu vẫn không có lỗi nào
        if (errors.Count == 0)
            errors.Add("Đã xảy ra lỗi không xác định.");

        // Thêm Status Code (nên giữ)
        errors.Add($"Status Code: {response.StatusCode}");

        return errors;
    }
}