using InfoManager.Application.Features.Categories.Commands;
using InfoManager.Application.Features.Categories.Queries.GetCategories;
using InfoManager.Shared.Dtos.Categories;

namespace InfoManager.Api.Endpoints.Personal;

/// <summary>
/// Represents the API endpoints for managing categories.
/// </summary>
public class Categories : EndpointGroupBase
{
    public override string GroupName => "Categories";

    public override void Map(RouteGroupBuilder group)
    {
        var api = group.MapGroup("").RequireAuthorization();

        //=============Data Retrieval Endpoints================
        group.MapGet(GetSelectListCategoriesAsync, "select-list");
        api.MapGet(GetCategoryByIdAsync, "{id}");//
        api.MapGet(GetCategoriesAsync);

        //=============Data Manipulation Endpoints================
        api.MapPost(CreateCategoryAsync);
        api.MapPut(UpdateCategoryAsync, "{id}");
        api.MapDelete(DeleteCategoryAsync, "{id}");
    }

    /// <summary>
    /// Get a category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category.</param>
    /// <param name="sender">The mediator instance.</param>
    /// <param name="user">The current user.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="200">Returns the requested category.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the category is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetCategoryByIdAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var query = new GetCategoryByIdQuery(id);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get a list of categories, optionally filtered by group and keyname.
    /// </summary>
    /// <param name="group">The group to filter categories by.</param>
    /// <param name="keyname">The keyname to filter categories by.</param>
    /// <param name="sender">The mediator instance.</param>
    /// <param name="user">The current user.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="200">Returns the list of categories.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If no categories are found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> GetCategoriesAsync(string? group,
                                                  string? keyname,
                                                  int pageNumber,
                                                  int pageSize,
                                                  [FromServices] ISender sender,
                                                  CancellationToken ct)
    {
        var query = new GetCategoriesQuery(group, keyname, pageNumber, pageSize);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Get a list of categories for a select list, optionally filtered by group and keyname.
    /// </summary>
    /// <param name="sender">The mediator instance</param>
    /// <param name="ct">The cancellation token</param>
    /// <param name="group">The group to filter categories by</param>
    /// <param name="keyname">The keyname to filter categories by</param>
    /// <returns>HTTP 200 on success, or HTTP 400/404/500 on error.</returns>
    public async Task<IResult> GetSelectListCategoriesAsync([FromServices] ISender sender,
                                                            CancellationToken ct,
                                                            string? group = null,
                                                            string? keyname = null)
    {
        var query = new GetSelectListCategoriesQuery(group, keyname);
        var result = await sender.Send(query, ct);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="command">The command containing the category details.</param>
    /// <param name="sender">The mediator instance.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>HTTP 201 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="201">Returns the created category.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the category is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> CreateCategoryAsync([FromBody] CreateCategoryRequest request,
                                                   [FromServices] ISender sender,
                                                   CancellationToken ct)
    {
        var command = new CreateCategoryCommand()
        {
            Group = request.Group,
            KeyName = request.KeyName,
            Name = request.Name,
        };

        var result = await sender.Send(command, ct);
        return result.ToCreatedHttpResult(GroupName);
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="id">The ID of the category to update.</param>
    /// <param name="command">The command containing the updated category details.</param>
    /// <param name="sender">The mediator instance.</param>
    /// <param name="user">The current user.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>HTTP 204 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="204">Indicates the category was successfully updated.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the category is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> UpdateCategoryAsync(string id,
                                                   UpdateCategoryRequest request,
                                                   [FromServices] ISender sender,
                                                   CancellationToken ct)
    {
        if (id != request.Id)
            return Results.BadRequest("Id in the URL does not match Id in the request body.");
        var command = new UpdateCategoryCommand()
        {
            Id = request.Id,
            Group = request.Group,
            KeyName = request.KeyName,
            Name = request.Name,
        };
        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }

    /// <summary>
    /// Deletes an existing category.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    /// <param name="sender">The mediator instance.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>HTTP 204 on success, or HTTP 400/404/500 on error.</returns>
    /// <response code="204">Indicates the category was successfully deleted.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the category is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    public async Task<IResult> DeleteCategoryAsync(string id, [FromServices] ISender sender, CancellationToken ct)
    {
        var command = new DeleteCategoryCommand(id);
        var result = await sender.Send(command, ct);
        return result.ToHttpResult();
    }
}