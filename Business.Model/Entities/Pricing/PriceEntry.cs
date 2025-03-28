using Business.Model.Entities.Common;
using Business.Model.Entities.Venues;
using System.Text.Json.Serialization;

namespace Business.Model.Entities.Pricing
{
    /// <summary>
    /// Represents a price entry for a specific area in a price list
    /// </summary>
    public class PriceEntry : BaseEntity
    {
        /// <summary>
        /// Unique identifier for the price entry
        /// </summary>
        public int PriceEntryId { get; set; }

        /// <summary>
        /// ID of the price list this entry belongs to
        /// </summary>
        public int PriceListId { get; set; }

        /// <summary>
        /// ID of the area this price entry is for
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// Price amount
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Description of the price entry
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Flag indicating if this price entry is for VIP seats
        /// </summary>
        public bool IsVip { get; set; }

        /// <summary>
        /// Navigation property for the price list this entry belongs to
        /// </summary>
        [JsonIgnore]
        public virtual PriceList PriceList { get; set; } = null!;

        /// <summary>
        /// Navigation property for the area this price entry is for
        /// </summary>
        [JsonIgnore]
        public virtual Area Area { get; set; } = null!;
    }
}