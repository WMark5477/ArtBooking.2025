using Business.Application.DTOs.ArtOrganizationFilters;
using Business.Model.Entities.Organizations;
using Xtech.Common.Pagination;

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

        /// <summary>
        /// List organizations with pagination, filtering, and sorting
        /// </summary>
        /// <param name="listParams">List parameters including pagination, filters, and sorting</param>
        /// <returns>A paged list of art organizations</returns>
        PagedList<ArtOrganization> ListOrganizations(PagedListParams<ArtOrganizationFilters> listParams);
    }
}
