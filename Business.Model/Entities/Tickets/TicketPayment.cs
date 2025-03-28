using Business.Model.Entities.Common;
using Business.Model.Entities.Pricing.Enums;
using Business.Model.Entities.Common.Enums;
using System.Text.Json.Serialization;

namespace Business.Model.Entities.Tickets
{
    /// <summary>
    /// Represents a payment for a ticket
    /// </summary>
    public class TicketPayment : BaseEntity
    {
        /// <summary>
        /// Unique identifier for the ticket payment
        /// </summary>
        public int TicketPaymentId { get; set; }

        /// <summary>
        /// ID of the ticket this payment is for
        /// </summary>
        public int TicketId { get; set; }

        /// <summary>
        /// Amount of the payment
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Currency code for the payment
        /// </summary>
        public CurrencyCode CurrencyCode { get; set; } = CurrencyCode.USD;

        /// <summary>
        /// Current status of the payment
        /// </summary>
        public PaymentStatus Status { get; set; }

        /// <summary>
        /// Method used for the payment
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Transaction ID from the payment processor
        /// </summary>
        public string? TransactionId { get; set; }

        /// <summary>
        /// Date and time when the payment was initiated
        /// </summary>
        public DateTime InitiatedAt { get; set; }

        /// <summary>
        /// Date and time when the payment was completed
        /// </summary>
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// Date and time when the payment was refunded (if applicable)
        /// </summary>
        public DateTime? RefundedAt { get; set; }

        /// <summary>
        /// Additional notes about the payment
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Navigation property for the ticket this payment is for
        /// </summary>
        [JsonIgnore]
        public virtual Ticket Ticket { get; set; } = null!;
    }
}