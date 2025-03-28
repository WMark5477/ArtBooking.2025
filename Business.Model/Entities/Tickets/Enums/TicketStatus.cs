namespace Business.Model.Entities.Tickets.Enums
{
    /// <summary>
    /// Represents the current status of a ticket in the booking/purchase process
    /// </summary>
    public enum TicketStatus
    {
        /// <summary>
        /// Ticket is available for purchase
        /// </summary>
        Available = 1,

        /// <summary>
        /// Ticket has been temporarily reserved but not yet purchased
        /// </summary>
        Reserved = 2,

        /// <summary>
        /// Ticket reservation has expired
        /// </summary>
        ReservationExpired = 3,

        /// <summary>
        /// Payment for the ticket is in progress
        /// </summary>
        PaymentInProgress = 4,

        /// <summary>
        /// Ticket has been purchased and payment completed
        /// </summary>
        Purchased = 5,

        /// <summary>
        /// Ticket has been checked in at the event
        /// </summary>
        CheckedIn = 6,

        /// <summary>
        /// Ticket has been cancelled
        /// </summary>
        Cancelled = 7,

        /// <summary>
        /// Ticket has been refunded
        /// </summary>
        Refunded = 8
    }
}