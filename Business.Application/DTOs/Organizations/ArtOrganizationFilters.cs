using Business.Model.Entities.Organizations;

namespace Business.Application.DTOs.Organizations
{
    /// <summary>
    /// Filter parameters for art organization listings
    /// </summary>
    public class ArtOrganizationFilters
    {
        /// <summary>
        /// Filter by organization name (partial match)
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Filter by organization kind
        /// </summary>
        public OrganizationKind? Kind { get; set; }
    }
}