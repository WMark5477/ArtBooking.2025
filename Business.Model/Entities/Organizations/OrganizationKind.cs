namespace Business.Model.Entities.Organizations
{
    /// <summary>
    /// Defines the different kinds of art organizations
    /// </summary>
    public enum OrganizationKind
    {
        /// <summary>
        /// Movie theater showing films
        /// </summary>
        Cinema,

        /// <summary>
        /// Live performance venue for plays and dramatic productions
        /// </summary>
        Theatre,

        /// <summary>
        /// Art display venue
        /// </summary>
        Gallery,

        /// <summary>
        /// Institution that preserves and displays cultural, artistic, or historical artifacts
        /// </summary>
        Museum,

        /// <summary>
        /// Venue for live music performances
        /// </summary>
        ConcertHall,

        /// <summary>
        /// Educational institution focused on teaching arts
        /// </summary>
        ArtSchool,

        /// <summary>
        /// Cultural center hosting various art activities
        /// </summary>
        CulturalCenter,

        /// <summary>
        /// Facility focused on dance performances
        /// </summary>
        DanceStudio,

        /// <summary>
        /// Independent or non-profit organization supporting arts
        /// </summary>
        ArtFoundation,

        /// <summary>
        /// Other types of art organizations not listed above
        /// </summary>
        Other
    }
}