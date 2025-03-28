using Business.Model.Entities.Common;
using Business.Model.Entities.Events;
using Business.Model.Entities.Organizations;
using Business.Model.Entities.Venues;
using Business.Model.Entities.Common.Enums;
using System.Text.Json.Serialization;

namespace Business.Model.Entities.Pricing
{
    /// <summary>
    /// Represents a price list template defined for a venue
    /// </summary>
    public class PriceList : BaseEntity
    {
        /// <summary>
        /// Unique identifier for the price list
        /// </summary>
        public int PriceListId { get; set; }

        /// <summary>
        /// ID of the venue this price list belongs to
        /// </summary>
        public int? VenueId { get; set; }

        /// <summary>
        /// Name of the price list
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description of the price list
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Start date from which this price list is valid
        /// </summary>
        public DateTime? ValidFrom { get; set; }

        /// <summary>
        /// End date until which this price list is valid
        /// </summary>
        public DateTime? ValidTo { get; set; }

        /// <summary>
        /// Currency code for the prices in this price list
        /// </summary>
        public CurrencyCode Currency { get; set; } = CurrencyCode.PLN;

        /// <summary>
        /// Navigation property for the venue this price list belongs to
        /// </summary>
        [JsonIgnore]
        public virtual Venue? Venue { get; set; }

        /// <summary>
        /// Navigation property for price entries in this price list
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<PriceEntry>? PriceEntries { get; set; }

        /// <summary>
        /// Navigation property for schedule items using this price list
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<ScheduleItem>? ScheduleItems { get; set; }
    }
}