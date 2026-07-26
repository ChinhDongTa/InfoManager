//using Microsoft.IdentityModel.Tokens.Experimental;
//using System.Text.Json.Serialization;

//namespace InfoManager.Application.Common.Models;

//public partial class Result<T>
//{
//    /// <summary>
//    /// Generic Repository Result with typed data.
//    /// </summary>
//    public record RepositoryResult<T> : RepositoryResult
//{
//    /// <summary>The returned data if operation succeeded.</summary>
//    public T? Data { get; init; }

//    // ✅ Simple factory methods
//    public static RepositoryResult<T> Success(T data)
//        => new() { Succeeded = true, Data = data };

//    public static new RepositoryResult<T> Failure(params string[] errors)
//        => new()
//        {
//            Succeeded = false,
//            Errors = errors.Length > 0 ? errors : ["Database operation failed"]
//        };
//}