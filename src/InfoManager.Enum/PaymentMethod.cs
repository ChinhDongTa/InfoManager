namespace InfoManager.Enum;

/// <summary>
/// Phương thức thanh toán cho các giao dịch tài chính.
/// </summary>
public enum PaymentMethod
{
    [Display(Name = "Tiền mặt")]
    Cash = 0,

    [Display(Name = "Chuyển khoản")]
    BankTransfer = 1,

    [Display(Name = "Ví điện tử (ZaloPay, Momo, ViettelPay)")]
    EWallet = 2,

    [Display(Name = "Thẻ tín dụng")]
    CreditCard = 3,

    [Display(Name = "Thẻ ghi nợ")]
    DebitCard = 4,

    [Display(Name = "Khác")]
    Other = 99
}