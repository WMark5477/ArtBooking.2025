using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Business.Model.Entities.Common;
using Business.Model.Entities.Events;
using Business.Model.Entities.Pricing;
using Business.Model.Entities.Users;
using Business.Model.Entities.Venues;

namespace Business.Model.Entities.Organizations
{
    /// <summary>
    /// Represents an organization involved in art events
    /// </summary>
    public class ArtOrganization : BaseEntity
    {
        /// <summary>
        /// Unique identifier for the art organization
        /// </summary>
        public int ArtOrganizationId { get; set; }

        /// <summary>
        /// Name of the organization
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description of the organization
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Type of art organization (e.g., Cinema, Theatre, Gallery)
        /// </summary>
        public OrganizationKind Kind { get; set; }

        /// <summary>
        /// Contact email for the organization
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Contact phone number for the organization
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Website URL for the organization
        /// </summary>
        public string? Website { get; set; }

        /// <summary>
        /// Street name in the organization's address
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string? Street { get; set; }

        /// <summary>
        /// Refers to building or building and apartment number on the street
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string? AddressNumber { get; set; }

        /// <summary>
        /// Town or city in the organization's address
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string? Town { get; set; }

        /// <summary>
        /// Postal code in the organization's address
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string? PostalCode { get; set; }

        /// <summary>
        /// Country in the organization's address
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Country { get; set; } = "Polska";

        /// <summary>
        /// Logo image URL for the organization
        /// </summary>
        public string? LogoUrl { get; set; }

        /// <summary>
        /// Navigation property for events associated with this organization
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<ArtEvent>? Events { get; set; }

        /// <summary>
        /// Navigation property for users who are members of this organization
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<User>? Users { get; set; }

        /// <summary>
        /// Navigation property for venues owned by this organization
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Venue>? Venues { get; set; }

        /// <summary>
        /// Navigation property for price lists managed by this organization
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<PriceList>? PriceLists { get; set; }
    }
}