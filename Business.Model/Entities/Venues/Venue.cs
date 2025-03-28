using Business.Model.Entities.Common;
using Business.Model.Entities.Events;
using Business.Model.Entities.Organizations;
using Business.Model.Entities.Pricing;
using System.Text.Json.Serialization;

namespace Business.Model.Entities.Venues
{
    /// <summary>
    /// Represents a venue where events can be held
    /// </summary>
    public class Venue : BaseEntity
    {
        /// <summary>
        /// Unique identifier for the venue
        /// </summary>
        public int VenueId { get; set; }

        /// <summary>
        /// Name of the venue
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description of the venue
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Address of the venue
        /// </summary>
        public string Address { get; set; } = null!;

        /// <summary>
        /// City where the venue is located
        /// </summary>
        public string City { get; set; } = null!;

        /// <summary>
        /// State/province where the venue is located
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// Country where the venue is located
        /// </summary>
        public string Country { get; set; } = null!;

        /// <summary>
        /// Postal/ZIP code of the venue
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// Contact email for the venue
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Contact phone number for the venue
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Website URL for the venue
        /// </summary>
        public string? Website { get; set; }

        /// <summary>
        /// Maximum capacity of the venue
        /// </summary>
        public int? Capacity { get; set; }

        /// <summary>
        /// Image URL for the venue
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Foreign key for the art organization that owns this venue
        /// </summary>
        public int ArtOrganizationId { get; set; }

        /// <summary>
        /// Navigation property for the art organization that owns this venue
        /// </summary>
        [JsonIgnore]
        public virtual ArtOrganization? Organization { get; set; }

        /// <summary>
        /// Navigation property for areas within this venue
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Area>? Areas { get; set; }

        /// <summary>
        /// Navigation property for price lists associated with this venue
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<PriceList>? PriceLists { get; set; }

        /// <summary>
        /// Navigation property for schedule items taking place at this venue
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<ScheduleItem>? ScheduleItems { get; set; }
    }
}