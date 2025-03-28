namespace Business.Model.Entities.Users
{
    /// <summary>
    /// Represents the role of a user in the system
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Master administrator with full system access
        /// </summary>
        MasterAdmin = 1,

        /// <summary>
        /// Administrator for an organizer with access to manage their events
        /// </summary>
        OrganizerAdmin = 2,

        /// <summary>
        /// Cashier role for ticket sales and management
        /// </summary>
        Cashier = 3,
    }
}