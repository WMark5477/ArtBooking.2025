using Business.Model.Entities.Common;
using Business.Model.Entities.Pricing;
using Business.Model.Entities.Tickets;
using Business.Model.Entities.Venues;
using System.Text.Json.Serialization;

namespace Business.Model.Entities.Events
{
    /// <summary>
    /// Represents a scheduled time entry for an event
    /// </summary>
    public class ScheduleItem : BaseEntity
    {
        /// <summary>
        /// Unique identifier for the schedule item
        /// </summary>
        public int ScheduleItemId { get; set; }

        /// <summary>
        /// ID of the event this schedule item belongs to
        /// </summary>
        public int ArtEventId { get; set; }

        /// <summary>
        /// ID of the venue where this schedule item takes place
        /// </summary>
        public int? VenueId { get; set; }

        /// <summary>
        /// Title or name of the schedule item
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Description of the schedule item
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Start time of the schedule item
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End time of the schedule item
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Location or venue area where this schedule item takes place
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Order of this item in the schedule
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// ID of the price list associated with this schedule item
        /// </summary>
        public int? PriceListId { get; set; }

        /// <summary>
        /// Navigation property for the event this schedule item belongs to
        /// </summary>
        [JsonIgnore]
        public virtual ArtEvent ArtEvent { get; set; } = null!;

        /// <summary>
        /// Navigation property for the venue where this schedule item takes place
        /// </summary>
        [JsonIgnore]
        public virtual Venue? Venue { get; set; }

        /// <summary>
        /// Navigation property for tickets issued for this schedule item
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Ticket>? Tickets { get; set; }

        /// <summary>
        /// Navigation property for the price list associated with this schedule item
        /// </summary>
        [JsonIgnore]
        public virtual PriceList? PriceList { get; set; }
    }
}