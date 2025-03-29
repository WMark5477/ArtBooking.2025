using Business.Application.DTOs.Organizations;
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
        /// <param name="organizationDto">The organization DTO with data for creation</param>
        /// <returns>The created organization DTO with ID</returns>
        ArtOrganizationDto CreateOrganization(CreateArtOrganizationDto organizationDto);

        /// <summary>
        /// List organizations with pagination, filtering, and sorting
        /// </summary>
        /// <param name="listParams">List parameters including pagination, filters, and sorting</param>
        /// <returns>A paged list of art organization DTOs</returns>
        PagedList<ArtOrganizationDto> ListOrganizations(PagedListParams<ArtOrganizationFilters> listParams);
    }
}
