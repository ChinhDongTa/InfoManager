using InfoManager.Application.Features.SFMS.Economics.Commands;

namespace InfoManager.Application.Common.Mappings;

public static class FarmExpenseMappings
{
    public static CreateFarmExpenseCommand ToCreateCommand(CreateFarmExpenseRequest request)
    => new()
    {
        FarmId = request.FarmId,
        CropPlantingId = request.CropPlantingId,
        ExpenseType = request.ExpenseType,
        Description = request.Description,
        Amount = request.Amount,
        Category = request.Category,
        ExpenseDate = request.ExpenseDate,
        Vendor = request.Vendor,
        InvoiceNumber = request.InvoiceNumber,
        PaymentMethod = request.PaymentMethod,
        PaymentStatus = request.PaymentStatus,
        ApprovalStatus = request.ApprovalStatus,
        ApprovedBy = request.ApprovedBy,
        AttachmentUrl = request.AttachmentUrl,
        Notes = request.Notes
    };

    public static UpdateFarmExpenseCommand ToUpdateCommand(UpdateFarmExpenseRequest request, string id)
        => new()
        {
            Id = id,
            FarmId = request.FarmId,
            CropPlantingId = request.CropPlantingId,
            ExpenseType = request.ExpenseType,
            Description = request.Description,
            Amount = request.Amount,
            Category = request.Category,
            ExpenseDate = request.ExpenseDate,
            Vendor = request.Vendor,
            InvoiceNumber = request.InvoiceNumber,
            PaymentMethod = request.PaymentMethod,
            PaymentStatus = request.PaymentStatus,
            ApprovalStatus = request.ApprovalStatus,
            ApprovedBy = request.ApprovedBy,
            AttachmentUrl = request.AttachmentUrl,
            Notes = request.Notes
        };
}
