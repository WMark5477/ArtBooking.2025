using Business.Model.Entities.Organizations;
using System.ComponentModel.DataAnnotations;

namespace Business.Application.DTOs.Organizations
{
    /// <summary>
    /// Data Transfer Object for creating a new Art Organization
    /// </summary>
    public class CreateArtOrganizationDto
    {
        /// <summary>
        /// Name of the organization
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description of the organization
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Type of art organization (e.g., Cinema, Theatre, Gallery)
        /// </summary>
        [Required]
        public OrganizationKind Kind { get; set; }

        /// <summary>
        /// Contact email for the organization
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Contact phone number for the organization
        /// </summary>
        [Phone]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Website URL for the organization
        /// </summary>
        [Url]
        public string? Website { get; set; }

        /// <summary>
        /// Street name in the organization's address
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Street { get; set; } = null!;

        /// <summary>
        /// Refers to building or building and apartment number on the street
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string AddressNumber { get; set; } = null!;

        /// <summary>
        /// Town or city in the organization's address
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Town { get; set; } = null!;

        /// <summary>
        /// Postal code in the organization's address
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string PostalCode { get; set; } = null!;

        /// <summary>
        /// Country in the organization's address
        /// </summary>
        [MaxLength(50)]
        public string Country { get; set; } = "Polska";

        /// <summary>
        /// Logo image URL for the organization
        /// </summary>
        [Url]
        public string? LogoUrl { get; set; }
    }
}