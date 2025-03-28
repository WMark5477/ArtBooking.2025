using Business.Model.Entities.Common;
using Business.Model.Entities.Tickets;
using System.Text.Json.Serialization;

namespace Business.Model.Entities.Venues
{
    /// <summary>
    /// Represents a specific seat within a venue area
    /// </summary>
    public class Seat : BaseEntity
    {
        /// <summary>
        /// Unique identifier for the seat
        /// </summary>
        public int SeatId { get; set; }

        /// <summary>
        /// ID of the area this seat belongs to
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Row identifier for the seat
        /// </summary>
        public string Row { get; set; } = null!;

        /// <summary>
        /// Number identifier for the seat
        /// </summary>
        public string Number { get; set; } = null!;

        /// <summary>
        /// Flag indicating if the seat is accessible for people with disabilities
        /// </summary>
        public bool IsAccessible { get; set; }

        /// <summary>
        /// Flag indicating if the seat is a VIP seat
        /// </summary>
        public bool IsVip { get; set; }

        /// <summary>
        /// Additional notes about the seat
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Navigation property for the area this seat belongs to
        /// </summary>
        [JsonIgnore]
        public virtual Area Area { get; set; } = null!;

        /// <summary>
        /// Navigation property for tickets assigned to this seat
        /// </summary>
        [JsonIgnore]
        public virtual Ticket? Ticket { get; set; }
    }
}