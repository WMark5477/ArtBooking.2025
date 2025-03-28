namespace Business.Model.Entities.Pricing.Enums
{
    /// <summary>
    /// Represents the method used for payment
    /// </summary>
    public enum PaymentMethod
    {
        /// <summary>
        /// Payment by credit card
        /// </summary>
        CreditCard = 1,

        /// <summary>
        /// Payment by debit card
        /// </summary>
        DebitCard = 2,

        /// <summary>
        /// Payment by bank transfer
        /// </summary>
        BankTransfer = 3,

        /// <summary>
        /// Payment by PayPal
        /// </summary>
        PayPal = 4,

        /// <summary>
        /// Payment in cash (at box office)
        /// </summary>
        Cash = 5,

        /// <summary>
        /// Payment by mobile payment service
        /// </summary>
        MobilePayment = 6,

        /// <summary>
        /// Payment by gift card or voucher
        /// </summary>
        GiftCard = 7
    }
}