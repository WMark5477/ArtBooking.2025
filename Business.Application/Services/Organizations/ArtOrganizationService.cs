using Business.Model.Data;
using Business.Model.Entities.Organizations;


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
    }
}
