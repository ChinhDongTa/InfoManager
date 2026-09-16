using InfoManager.Enum.SFMS;
using InfoManager.Shared.Dtos.SFMS.Customers;

namespace InfoManager.ModelClient.SFMS.Customers;

public class UpdateCustomerCareModel
{
    /// <summary>ID chăm sóc khách hàng. Bắt buộc.</summary>
    [Required]
    public string Id { get; set; }

    /// <summary>Loại chăm sóc.</summary>
    public CustomerCareType? CareType { get; set; }

    /// <summary>Tiêu đề chăm sóc.</summary>
    public string? Subject { get; set; }

    /// <summary>Nội dung.</summary>
    public string? Content { get; set; }

    /// <summary>Ngày chăm sóc.</summary>
    public DateTimeOffset? CareDate { get; set; }

    /// <summary>Ngày theo dõi tiếp theo.</summary>
    public DateTimeOffset? NextFollowUpDate { get; set; }

    /// <summary>Trạng thái chăm sóc.</summary>
    public CustomerCareStatus? Status { get; set; }

    /// <summary>Người xử lý.</summary>
    public string? HandledBy { get; set; }

    /// <summary>Kết quả.</summary>
    public string? Result { get; set; }

    public UpdateCustomerCareModel(string id, CustomerCareDto dto)
    {
        Id = id;
        CareType = dto.CareType;
        Subject = dto.Subject;
        Content = dto.Content;
        CareDate = dto.CareDate;
        NextFollowUpDate = dto.NextFollowUpDate;
        Status = dto.Status;
        HandledBy = dto.HandledBy;
        Result = dto.Result;
    }

    public UpdateCustomerCareRequest CreateRequest()
    {
        return new UpdateCustomerCareRequest
        (
            Id: this.Id,
            CareType: this.CareType,
            Subject: this.Subject,
            Content: this.Content,
            CareDate: this.CareDate,
            NextFollowUpDate: this.NextFollowUpDate,
            Status: this.Status,
            HandledBy: this.HandledBy,
            Result: this.Result
        );
    }

    public bool HasChanges(UpdateCustomerCareModel originalModel)
        => ClientUpdateHelper.HasChanges(this, originalModel);
}