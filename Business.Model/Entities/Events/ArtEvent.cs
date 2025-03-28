using Business.Model.Entities.Common;
using Business.Model.Entities.Events.Enums;
using Business.Model.Entities.Organizations;
using System.Text.Json.Serialization;

namespace Business.Model.Entities.Events
{
    /// <summary>
    /// Represents an art event
    /// </summary>
    public class ArtEvent : BaseEntity
    {
        /// <summary>
        /// Unique identifier for the art event
        /// </summary>
        public int ArtEventId { get; set; }

        /// <summary>
        /// Name of the event
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description of the event
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// ID of the organization this event belongs to
        /// </summary>
        public int ArtOrganizationId { get; set; }

        /// <summary>
        /// Current status of the event
        /// </summary>
        public EventStatus Status { get; set; }

        /// <summary>
        /// Category of the event
        /// </summary>
        public EventCategory Category { get; set; }

        /// <summary>
        /// Image URL for the event
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Navigation property for the organization this event belongs to (required for DbContext relationship)
        /// </summary>
        [JsonIgnore]
        public virtual ArtOrganization Organization { get; set; } = null!;


        /// <summary>
        /// Navigation property for schedule items for this event
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<ScheduleItem>? ScheduleItems { get; set; }
    }
}