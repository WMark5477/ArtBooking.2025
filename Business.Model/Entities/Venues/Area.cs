using Business.Model.Entities.Common;
using Business.Model.Entities.Pricing;
using Business.Model.Entities.Tickets;
using System.Text.Json.Serialization;

namespace Business.Model.Entities.Venues
{
    /// <summary>
    /// Represents an area or section within a venue
    /// </summary>
    public class Area : BaseEntity
    {
        /// <summary>
        /// Primary key for the area
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// ID of the venue this area belongs to
        /// </summary>
        public int VenueId { get; set; }

        /// <summary>
        /// Name of the area
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description of the area
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Capacity of the area (number of people or seats)
        /// </summary>
        public int? Capacity { get; set; }

        /// <summary>
        /// Flag indicating if this area has assigned seats
        /// </summary>
        public bool HasAssignedSeats { get; set; }

        /// <summary>
        /// Navigation property for the venue this area belongs to
        /// </summary>
        [JsonIgnore]
        public virtual Venue Venue { get; set; } = null!;

        /// <summary>
        /// Navigation property for seats within this area (if it has assigned seats)
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Seat>? Seats { get; set; }

        /// <summary>
        /// Navigation property for the price entry associated with this area
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<PriceEntry>? PriceEntries { get; set; }

        /// <summary>
        /// Navigation property for tickets assigned to this area
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Ticket>? Tickets { get; set; }
    }
}