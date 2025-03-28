using Business.Model.Entities.Common;
using Business.Model.Entities.Events;
using Business.Model.Entities.Tickets.Enums;
using Business.Model.Entities.Users;
using Business.Model.Entities.Venues;
using System.Text.Json.Serialization;

namespace Business.Model.Entities.Tickets
{
    /// <summary>
    /// Represents a ticket for a specific event
    /// </summary>
    public class Ticket : BaseEntity
    {
        /// <summary>
        /// Unique identifier for the ticket
        /// </summary>
        public int TicketId { get; set; }

        /// <summary>
        /// ID of the event this ticket is for
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// ID of the schedule item this ticket is for
        /// </summary>
        public int ScheduleItemId { get; set; }

        /// <summary>
        /// ID of the seat this ticket is assigned to (if applicable)
        /// </summary>
        public int? SeatId { get; set; }

        /// <summary>
        /// ID of the area this ticket is for (if not assigned to a specific seat)
        /// </summary>
        public int? AreaId { get; set; }

        /// <summary>
        /// Current status of the ticket
        /// </summary>
        public TicketStatus Status { get; set; }

        /// <summary>
        /// Price of the ticket
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Unique code for the ticket
        /// </summary>
        public string TicketCode { get; set; } = null!;

        /// <summary>
        /// Date and time when the ticket was reserved
        /// </summary>
        public DateTime? ReservationDate { get; set; }

        /// <summary>
        /// Date and time when the reservation expires
        /// </summary>
        public DateTime? ReservationExpiryDate { get; set; }

        /// <summary>
        /// Date and time when the ticket was purchased
        /// </summary>
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// Date and time when the ticket was checked in
        /// </summary>
        public DateTime? CheckInDate { get; set; }

        /// <summary>
        /// Navigation property for the event this ticket is for
        /// </summary>
        [JsonIgnore]
        public virtual ArtEvent Event { get; set; } = null!;

        /// <summary>
        /// Navigation property for the schedule item this ticket is for
        /// </summary>
        [JsonIgnore]
        public virtual ScheduleItem ScheduleItem { get; set; } = null!;

        /// <summary>
        /// Navigation property for the user who purchased or reserved this ticket
        /// </summary>
        [JsonIgnore]
        public virtual User? User { get; set; }

        /// <summary>
        /// Navigation property for the seat this ticket is assigned to (if applicable)
        /// </summary>
        [JsonIgnore]
        public virtual Seat? Seat { get; set; }

        /// <summary>
        /// Navigation property for the area this ticket is for (if not assigned to a specific seat)
        /// </summary>
        [JsonIgnore]
        public virtual Area? Area { get; set; }

        /// <summary>
        /// Navigation property for the payment for this ticket
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<TicketPayment>? Payments { get; set; }
    }
}