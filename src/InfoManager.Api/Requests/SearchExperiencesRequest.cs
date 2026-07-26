namespace InfoManager.Api.Requests;

/// <summary>
/// Request model for searching experiences with query parameters.
/// </summary>
//public record SearchExperiencesRequest(
//    string? Keyword = null,
//    string? CategoryId = null,
//    int PageNumber = 1,
//    int PageSize = 20)
//{
//    /// <summary>
//    /// Parses a SearchExperiencesRequest from a query string.
//    /// Required by ASP.NET Core minimal APIs for query parameter binding.
//    /// </summary>
//    public static bool TryParse(string? value, out SearchExperiencesRequest? result)
//    {
//        result = null;

//        // This is used when binding from complex types in query strings
//        // For [FromQuery] binding, the individual properties are bound automatically
//        // This method is kept for completeness but won't be called in typical usage
//        if (string.IsNullOrEmpty(value))
//        {
//            result = new SearchExperiencesRequest();
//            return true;
//        }

//        return false;
//    }
//}
