namespace Business.Model.Entities.Common
{
    /// <summary>
    /// Base class for all entities in the system
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Date and time when the entity was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// User who created the entity
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// Date and time when the entity was last updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// User who last updated the entity
        /// </summary>
        public int? UpdatedById { get; set; }

        /// <summary>
        /// Flag indicating if the entity is active
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}