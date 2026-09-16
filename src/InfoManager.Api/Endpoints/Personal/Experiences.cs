using InfoManager.Application.Features.Experiences.Commands;
using InfoManager.Application.Features.Experiences.Queries.GetExperiences;
using InfoManager.Shared.Dtos.Experiences;

namespace InfoManager.Api.Endpoints.Personal;

/// <summary>
/// Represents the API endpoints for managing experiences.
/// </summary>
public class Experiences : EndpointGroupBase
{
    public override string GroupName => "Experiences";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();
        //=============Data Retrieval Endpoints================
        api.MapGet(GetExperienceByIdAsync, "{id}");
        api.MapGet(GetExperiencesAsync);
        api.MapGet(SearchExperiencesAsync, "search");

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateExperienceAsync);
        api.MapPut(UpdateExperienceAsync, "{id}");
        api.MapDelete(DeleteExperienceAsync, "{id}");
    }

    /// <summary>
    /// Get an experience by its ID.
    /// </summary>
    /// <param name="id">The ID of the experience.</param>
    /// <param name="sender">The mediator instance.</param>
    /// <param name="user">The current user.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="200">Returns the requested experience.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the experience is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetExperienceByIdAsync(string id,
                                                      [FromServices] ISender sender,
                                                      [FromServices] IUser user,
                                                      CancellationToken ct)
    {
        var query = new GetExperienceByIdQuery(id);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get a list of experiences with pagination.
    /// </summary>
    /// <param name="sender">The mediator instance.</param>
    /// <param name="user">The current user.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="200">Returns the list of experiences.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If no experiences are found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetExperiencesAsync([FromServices] ISender sender,
                                                   [FromServices] IUser user,
                                                   CancellationToken ct,
                                                   int pageNumber,
                                                   int pageSize)
    {
        var query = new GetExperiencesQuery(pageNumber, pageSize);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Create a new experience.
    /// </summary>
    /// <param name="command">The command containing the experience details.</param>
    /// <param name="sender">The mediator instance.</param>
    /// <param name="user">The current user.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>HTTP 201 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="201">Returns the created experience.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the experience is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> CreateExperienceAsync([FromBody] CreateExperienceRequest request,
                                                     [FromServices] ISender sender,
                                                     [FromServices] IUser user,
                                                     CancellationToken ct)
    {
        var command = new CreateExperienceCommand()
        {
            // Map properties from request to command
            CategoryId = request.CategoryId,
            Content = request.Content,
            Description = request.Description,
            ExperienceDate = request.ExperienceDate,
        };
        var result = await sender.Send(command, ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    /// <summary>
    /// Update an existing experience.
    /// </summary>
    /// <param name="id">The ID of the experience to update.</param>
    /// <param name="command">The command containing the updated experience details.</param>
    /// <param name="sender">The mediator instance.</param>
    /// <param name="user">The current user.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>HTTP 204 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="204">Returns the updated experience.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the experience is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> UpdateExperienceAsync(string id,
                                                     [FromBody] UpdateExperienceRequest request,
                                                     [FromServices] ISender sender,
                                                     [FromServices] IUser user,
                                                     CancellationToken ct)
    {
        if (id != request.Id)
        {
            return Results.BadRequest("ID in URL does not match ID in request body.");
        }
        var command = new UpdateExperienceCommand()
        {
            Id = request.Id,
            CategoryId = request.CategoryId,
            Content = request.Content,
            Description = request.Description,
            ExperienceDate = request.ExperienceDate,
        };
        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Delete an experience by its ID.
    /// </summary>
    /// <param name="id">The ID of the experience to delete.</param>
    /// <param name="sender">The mediator instance.</param>
    /// <param name="user">The current user.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>HTTP 204 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="204">If the experience was successfully deleted.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the experience is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> DeleteExperienceAsync(string id,
                                                     [FromServices] ISender sender,
                                                     [FromServices] IUser user,
                                                     CancellationToken ct)
    {
        var command = new DeleteExperienceCommand(id);
        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Search experiences based on keyword and category with pagination.
    /// </summary>
    /// <param name="sender">The mediator instance.</param>
    /// <param name="user">The current user.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <param name="request">The search request containing keyword, category, page number, and page size.</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="200">Returns the list of experiences matching the search criteria.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If no experiences are found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> SearchExperiencesAsync([FromServices] ISender sender,
                                                      [FromServices] IUser user,
                                                      CancellationToken ct,
                                                      [AsParameters] SearchExperiencesRequest request)
    {
        var searchQuery = new SearchExperiencesQuery
        {
            Keyword = request.Keyword,
            CategoryId = request.CategoryId,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
        var result = await sender.Send(searchQuery, ct);
        return result.ToHttpResult();
    }
}