namespace Business.Model.Entities.Pricing.Enums
{
    /// <summary>
    /// Represents the current status of a payment
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        /// Payment has been initiated but not yet processed
        /// </summary>
        Initiated = 1,

        /// <summary>
        /// Payment is being processed
        /// </summary>
        Processing = 2,

        /// <summary>
        /// Payment has been successfully completed
        /// </summary>
        Completed = 3,

        /// <summary>
        /// Payment has failed
        /// </summary>
        Failed = 4,

        /// <summary>
        /// Payment has been refunded
        /// </summary>
        Refunded = 5,

        /// <summary>
        /// Payment refund is in progress
        /// </summary>
        RefundInProgress = 6,

        /// <summary>
        /// Payment has been cancelled
        /// </summary>
        Cancelled = 7
    }
}