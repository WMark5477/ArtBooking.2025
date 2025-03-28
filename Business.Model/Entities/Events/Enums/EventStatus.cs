namespace Business.Model.Entities.Events.Enums
{
    /// <summary>
    /// Represents the current status of an art event
    /// </summary>
    public enum EventStatus
    {
        /// <summary>
        /// Event is in draft mode, not yet published
        /// </summary>
        Draft = 1,

        /// <summary>
        /// Event is published and visible to the public
        /// </summary>
        Published = 2,

        /// <summary>
        /// Event is open for ticket sales
        /// </summary>
        TicketSalesOpen = 3,

        /// <summary>
        /// Event ticket sales are closed
        /// </summary>
        TicketSalesClosed = 4,

        /// <summary>
        /// Event is currently in progress
        /// </summary>
        InProgress = 5,

        /// <summary>
        /// Event has completed
        /// </summary>
        Completed = 6,

        /// <summary>
        /// Event has been cancelled
        /// </summary>
        Cancelled = 7
    }
}