namespace InfoManager.Application.Features.SFMS.Customer.Queries;

internal static class QueryExtensions
{
    //===================================Customer Queryable Extensions===================================================
    public static IQueryable<CustomerDto> ToCustomerDto(this IQueryable<Domain.Entities.SFMS.Customers.Customer> query)
    {
        return query.Select(c => new CustomerDto(
             Id: c.Id,
             FarmId: c.FarmId,
             FarmName: c.Farm != null ? c.Farm.Name : null,
             CustomerCode: c.CustomerCode,
             Name: c.Name,
             CustomerTypeName: c.CustomerType.ToDisplayName(),
             Phone: c.Phone,
             Email: c.Email,
             Address: c.Address,
             TaxCode: c.TaxCode,
             ContactPerson: c.ContactPerson,
             CreditLimit: c.CreditLimit,
             StatusName: c.Status.ToDisplayName(),
             Notes: c.Notes,
             Created: c.Created
            ));
    }

    public static IQueryable<CustomerSummaryDto> ToCustomerSummaryDto(this IQueryable<Domain.Entities.SFMS.Customers.Customer> query)
    {
        return query.Select(c => new CustomerSummaryDto(
             Id: c.Id,
             CustomerCode: c.CustomerCode,
             Name: c.Name,
             CustomerTypeName: c.CustomerType.ToDisplayName(),
             Phone: c.Phone,
             StatusName: c.Status.ToDisplayName()
            ));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">name, customertype</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<Domain.Entities.SFMS.Customers.Customer> ApplySorting(this IQueryable<Domain.Entities.SFMS.Customers.Customer> query,
                                                                                   string? sortBy = null,
                                                                                   bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created);
        }
        return sortBy.ToLower() switch
        {
            "name" => ascending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name),
            "customertype" => ascending ? query.OrderBy(a => a.CustomerType) : query.OrderByDescending(a => a.CustomerType),
            _ => query
        };
    }

    //===================================CustomerCare Queryable Extensions===================================================

    public static IQueryable<CustomerCareDto> ToCustomerCareDto(this IQueryable<CustomerCare> query)
    {
        return query.Select(x => new CustomerCareDto(
            Id: x.Id,
            CustomerId: x.CustomerId,
            CustomerName: x.Customer != null ? x.Customer.Name : null,
            FarmId: x.FarmId,
            FarmName: x.Farm != null ? x.Farm.Name : null,
            CareTypeName: x.CareType.ToDisplayName(),
            Subject: x.Subject,
            Content: x.Content,
            CareDate: x.CareDate,
            NextFollowUpDate: x.NextFollowUpDate,
            StatusName: x.Status.ToDisplayName(),
            HandledBy: x.HandledBy,
            Result: x.Result,
            Created: x.Created
            ));
    }
    public static IQueryable<CustomerCareSummaryDto> ToCustomerCareSummaryDto(this IQueryable<CustomerCare> query)
    {
        return query.Select(x => new CustomerCareSummaryDto(
            Id: x.Id,
            CustomerName: x.Customer != null ? x.Customer.Name : null,
            CareTypeName: x.CareType.ToDisplayName(),
            Subject: x.Subject,
            CareDate: x.CareDate,
            NextFollowUpDate: x.NextFollowUpDate,
            StatusName: x.Status.ToDisplayName()
            ));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">subject, caredate</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<CustomerCare> ApplySorting(this IQueryable<CustomerCare> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created).ThenByDescending(a => a.CareDate);
        }
        return sortBy.ToLower() switch
        {
            "subject" => ascending ? query.OrderBy(a => a.Status) : query.OrderByDescending(a => a.Status),
            "caredate" => ascending ? query.OrderBy(a => a.CareDate) : query.OrderByDescending(a => a.CareDate),
            _ => query
        };
    }
    //===================================CustomerPayment Queryable Extensions================================================
    public static IQueryable<CustomerPaymentSummaryDto> ToCustomerPaymentSummaryDto(this IQueryable<CustomerPayment> query)
    {
        return query.Select(x => new CustomerPaymentSummaryDto(
            Id: x.Id,
            CustomerName: x.Customer != null ? x.Customer.Name : null,
            Amount: x.Amount,
            PaymentDate: x.PaymentDate,
            PaymentMethod: x.PaymentMethod,
            PaymentStatusName:x.PaymentStatus.ToDisplayName()
            ));
    }

    public static IQueryable<CustomerPaymentDto> ToCustomerPaymentDto(this IQueryable<CustomerPayment> query)
    {
        return query.Select(x => new CustomerPaymentDto(
            Id: x.Id,
            CustomerId: x.CustomerId,
            CustomerName: x.Customer != null ? x.Customer.Name : null,
            FarmId: x.FarmId,
            FarmName: x.Farm != null ? x.Farm.Name : null,
            SaleId: x.SaleId,
            FarmRevenueId: x.FarmRevenueId,
            Amount: x.Amount,
            PaymentDate: x.PaymentDate,
            PaymentMethod: x.PaymentMethod,
            PaymentStatusName: x.PaymentStatus.ToDisplayName(),
            ReferenceNumber: x.ReferenceNumber,
            Notes: x.Notes,
            Created: x.Created
            ));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="sortBy">amount, paymentmethod</param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IQueryable<CustomerPayment> ApplySorting(this IQueryable<CustomerPayment> query, string? sortBy = null, bool ascending = true)
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            return query.OrderByDescending(a => a.Created).ThenByDescending(a => a.PaymentDate);
        }
        return sortBy.ToLower() switch
        {
            "amount" => ascending ? query.OrderBy(a => a.Amount) : query.OrderByDescending(a => a.Amount),
            "paymentmethod" => ascending ? query.OrderBy(a => a.PaymentMethod) : query.OrderByDescending(a => a.PaymentMethod),
            _ => query
        };
    }
}