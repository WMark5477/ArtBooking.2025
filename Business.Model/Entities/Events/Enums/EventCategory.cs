namespace Business.Model.Entities.Events.Enums
{
    /// <summary>
    /// Represents the category of an art event
    /// </summary>
    public enum EventCategory
    {
        /// <summary>
        /// Music concert or performance
        /// </summary>
        Concert = 1,

        /// <summary>
        /// Theater performance
        /// </summary>
        Theater = 2,

        /// <summary>
        /// Dance performance
        /// </summary>
        Dance = 3,

        /// <summary>
        /// Art exhibition
        /// </summary>
        Exhibition = 4,

        /// <summary>
        /// Film screening
        /// </summary>
        Film = 5,

        /// <summary>
        /// Literary event (book reading, poetry, etc.)
        /// </summary>
        Literary = 6,

        /// <summary>
        /// Festival with multiple types of performances
        /// </summary>
        Festival = 7,

        /// <summary>
        /// Workshop or educational event
        /// </summary>
        Workshop = 8,

        /// <summary>
        /// Other type of art event
        /// </summary>
        Other = 9
    }
}