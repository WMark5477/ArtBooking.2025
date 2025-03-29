using Business.Model.Entities.Organizations;

namespace Business.Application.Services.Organizations
{
    /// <summary>
    /// Interface for Art Organization service operations
    /// </summary>
    public interface IArtOrganizationService
    {
        /// <summary>
        /// Creates a new art organization
        /// </summary>
        /// <param name="organization">The organization to create</param>
        /// <returns>The created organization with ID</returns>
        ArtOrganization CreateOrganization(ArtOrganization organization);
    }
}
