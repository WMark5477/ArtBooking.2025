using Business.Model.Data;
using Business.Model.Entities.Organizations;
using Xtech.Common.Pagination;
using System;
using System.Linq;
using Business.Application.DTOs.ArtOrganizationFilters;

namespace Business.Application.Services.Organizations
{
    /// <summary>
    /// Service for handling Art Organization operations
    /// </summary>
    public class ArtOrganizationService : IArtOrganizationService
    {
        private readonly ArtBookingDbContext _dbContext;

        public ArtOrganizationService(ArtBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Creates a new art organization
        /// </summary>
        /// <param name="organization">The organization to create</param>
        /// <returns>The created organization with ID</returns>
        /// <exception cref="Exception">Thrown when an error occurs during organization creation</exception>
        public ArtOrganization CreateOrganization(ArtOrganization organization)
        {
            _dbContext.Add(organization);
            _dbContext.SaveChanges();
            return organization;
        }

        /// <summary>
        /// List organizations with pagination, filtering, and sorting
        /// </summary>
        /// <param name="listParams">List parameters including pagination, filters, and sorting</param>
        /// <returns>A paged list of art organizations</returns>
        public PagedList<ArtOrganization> ListOrganizations(PagedListParams<ArtOrganizationFilters> listParams)
        {
            var query = _dbContext.ArtOrganizations.AsQueryable();

            // Apply filters if provided
            if (listParams.Filters != null)
            {
                // Filter by name (case-insensitive partial match)
                if (!string.IsNullOrEmpty(listParams.Filters.Name))
                {
                    query = query.Where(o => o.Name.ToLower().Contains(listParams.Filters.Name.ToLower()));
                }

                // Filter by kind
                if (listParams.Filters.Kind.HasValue)
                {
                    query = query.Where(o => o.Kind == listParams.Filters.Kind.Value);
                }
            }

            // Apply sorting
            if (listParams.HasSort())
            {
                if (listParams.SortByFieldIs("OrganizationName"))
                {
                    query = listParams.IsSortByAsc()
                        ? query.OrderBy(o => o.Name)
                        : query.OrderByDescending(o => o.Name);
                }
                else if (listParams.SortByFieldIs("CreatedAt"))
                {
                    query = listParams.IsSortByAsc()
                        ? query.OrderBy(o => o.CreatedAt)
                        : query.OrderByDescending(o => o.CreatedAt);
                }
                // Default sorting by Name ascending if sort field is not recognized
                else
                {
                    query = query.OrderBy(o => o.Name);
                }
            }
            else
            {
                // Default sorting by Name if no sort specified
                query = query.OrderBy(o => o.Name);
            }

            return query.AsPagedList(listParams.PageNumber, listParams.PageSize);
        }
    }
}
