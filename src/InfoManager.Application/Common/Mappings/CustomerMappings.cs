using InfoManager.Application.Features.SFMS.Customer.Commands;
using InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

public static class CustomerMappings
{
    public static CreateCustomerCommand ToCreateCommand(CreateCustomerRequest request)
        => new()
        {
            FarmId = request.FarmId,
            Name = request.Name,
            CustomerCode = request.CustomerCode,
            CustomerType = request.CustomerType,
            Phone = request.Phone,
            Email = request.Email,
            Address = request.Address,
            TaxCode = request.TaxCode,
            ContactPerson = request.ContactPerson,
            CreditLimit = request.CreditLimit,
            Status = request.Status,
            Notes = request.Notes
        };

    public static UpdateCustomerCommand ToUpdateCommand(string id, UpdateCustomerRequest request)
        => new()
        {
            Id = id,
            FarmId = request.FarmId,
            CustomerCode = request.CustomerCode,
            Name = request.Name,
            CustomerType = request.CustomerType,
            Phone = request.Phone,
            Email = request.Email,
            Address = request.Address,
            TaxCode = request.TaxCode,
            ContactPerson = request.ContactPerson,
            CreditLimit = request.CreditLimit,
            Status = request.Status,
            Notes = request.Notes
        };

    public static SearchCustomersQuery ToSearchQuery(SearchCustomerRequest request)
    => new(
        Term: request.Term,
        CustomerType: request.CustomerType,
        MinCreditLimit: request.MinCreditLimit,
        MaxCreditLimit: request.MaxCreditLimit,
        Status: request.Status,
        PageNumber: request.PageNumber,
        PageSize: request.PageSize);
}