namespace Business.Application.Services.Venues
{

    /// <summary>
    /// Filter parameters for venue listings
    /// </summary>
    public class VenueFilters
    {
        /// <summary>
        /// Filter by venue name (partial match)
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Filter by city (partial match)
        /// </summary>
        public string? Description { get; set; }
    }
}
