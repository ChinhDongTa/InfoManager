namespace InfoManager.Shared.Dtos.SFMS.Economics;

// ======================== FarmExpense ========================

public record FarmExpenseDto(
    string Id,
    string FarmId,
    string? FarmName,
    string? CropPlantingId,
    string? CropPlantingName,
    string ExpenseTypeName,
    string Description,
    decimal Amount,
    string? Category,
    DateTimeOffset ExpenseDate,
    string? Vendor,
    string? InvoiceNumber,
    string? PaymentMethod,
    string PaymentStatusName,
    string ApprovalStatusName,
    string? ApprovedBy,
    string? AttachmentUrl,
    string? Notes,
    DateTimeOffset Created
);

public record FarmExpenseSummaryDto(
    string Id,
    string? FarmName,
    string? CropPlantingName,
    string ExpenseTypeName,
    string Description,
    decimal Amount,
    DateTimeOffset ExpenseDate,
    string PaymentStatusName,
    string ApprovalStatusName
);

public record CreateFarmExpenseRequest(
    string FarmId,
    string? CropPlantingId,
    ExpenseType ExpenseType,
    string Description,
    decimal Amount ,
    string? Category,
    DateTimeOffset ExpenseDatet,
    string? Vendor,
    string? InvoiceNumber,
    string? PaymentMethod,
    PaymentStatus PaymentStatus ,
    ApprovalStatus ApprovalStatus,
    string? ApprovedBy,
    string? AttachmentUrl,
    string? Notes
);

public record UpdateFarmExpenseRequest(
    string Id,
    string? FarmId,
    string? CropPlantingId,
    ExpenseType? ExpenseType,
    string? Description,
    decimal? Amount,
    string? Category,
    DateTimeOffset? ExpenseDate,
    string? Vendor,
    string? InvoiceNumber,
    string? PaymentMethod,
    PaymentStatus? PaymentStatus,
    ApprovalStatus? ApprovalStatus,
    string? ApprovedBy,
    string? AttachmentUrl,
    string? Notes
);