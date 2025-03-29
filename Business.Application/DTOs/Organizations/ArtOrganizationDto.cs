using Business.Model.Entities.Organizations;
using System;

namespace Business.Application.DTOs.Organizations
{
    /// <summary>
    /// Data Transfer Object for Art Organization responses
    /// </summary>
    public class ArtOrganizationDto
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
        public string? Street { get; set; }

        /// <summary>
        /// Refers to building or building and apartment number on the street
        /// </summary>
        public string? AddressNumber { get; set; }

        /// <summary>
        /// Town or city in the organization's address
        /// </summary>
        public string? Town { get; set; }

        /// <summary>
        /// Postal code in the organization's address
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// Country in the organization's address
        /// </summary>
        public string Country { get; set; } = "Polska";

        /// <summary>
        /// Logo image URL for the organization
        /// </summary>
        public string? LogoUrl { get; set; }

        /// <summary>
        /// Date and time the organization was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time the organization was last updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}