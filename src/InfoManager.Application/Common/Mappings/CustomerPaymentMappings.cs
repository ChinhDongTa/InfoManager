using InfoManager.Application.Features.SFMS.Customer.Commands;
using InfoManager.Application.Features.SFMS.Customer.Queries.Gets;

namespace InfoManager.Application.Common.Mappings;

/// <summary>
/// Mapping từ Request sang Command của CustomerPayment.
/// </summary>
public static class CustomerPaymentMappings
{
    public static CreateCustomerPaymentCommand ToCreateCommand(CreateCustomerPaymentRequest request)
        => new()
        {
            CustomerId = request.CustomerId,
            FarmId = request.FarmId,
            SaleId = request.SaleId,
            FarmRevenueId = request.FarmRevenueId,
            Amount = request.Amount,
            PaymentDate = request.PaymentDate,
            PaymentMethod = request.PaymentMethod,
            PaymentStatus = request.PaymentStatus,
            ReferenceNumber = request.ReferenceNumber,
            Notes = request.Notes
        };

    public static UpdateCustomerPaymentCommand ToUpdateCommand(string id, UpdateCustomerPaymentRequest request)
        => new()
        {
            Id = id,
            SaleId = request.SaleId,
            FarmRevenueId = request.FarmRevenueId,
            Amount = request.Amount,
            PaymentDate = request.PaymentDate,
            PaymentMethod = request.PaymentMethod,
            PaymentStatus = request.PaymentStatus,
            ReferenceNumber = request.ReferenceNumber,
            Notes = request.Notes
        };

    public static SearchCustomerPaymentsQuery ToSearchQuery(SearchCustomerPaymentRequest request)
        => new(
            Term: request.Term,
            StartPaymentDate: request.StartPaymentDate,
            EndPaymentDate: request.EndPaymentDate,
            PageNumber: request.PageNumber,
            PageSize: request.PageSize
        );
}