using InfoManager.Application.Features.SFMS.Customer.Commands;
using InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

/// <summary>
/// Mapping từ Request sang Command của CustomerCare.
/// </summary>
public static class CustomerCareMappings
{
    public static CreateCustomerCareCommand ToCreateCommand( CreateCustomerCareRequest request)
        => new()
        {
            CustomerId = request.CustomerId,
            FarmId = request.FarmId,
            Subject = request.Subject,
            CareType = request.CareType,
            Content = request.Content,
            CareDate = request.CareDate,
            NextFollowUpDate = request.NextFollowUpDate,
            Status = request.Status,
            HandledBy = request.HandledBy,
            Result = request.Result
        };

    public static UpdateCustomerCareCommand ToUpdateCommand(string id, UpdateCustomerCareRequest request)
        => new()
        {
            Id = id,
            CareType = request.CareType,
            Subject = request.Subject,
            Content = request.Content,
            CareDate = request.CareDate,
            NextFollowUpDate = request.NextFollowUpDate,
            Status = request.Status,
            HandledBy = request.HandledBy,
            Result = request.Result
        };

    public static SearchCustomerCaresQuery ToSearchQuery(SearchCustomerCareRequest request)
        => new(
            Term : request.Term,
            StartCareDate : request.StartCareDate,
            EndCareDate : request.EndCareDate,
            StartNextFollowUpDate : request.StartNextFollowUpDate,
            EndNextFollowUpDate : request.EndNextFollowUpDate,
            PageNumber : request.PageNumber,
            PageSize : request.PageSize
       );
}