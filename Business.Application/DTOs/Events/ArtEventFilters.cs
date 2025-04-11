using Business.Model.Entities.Events.Enums;

namespace Business.Application.DTOs.Events
{
    public class ArtEventFilters
    {
        public string? Name { get; set; }
        public EventCategory? Category { get; set; }
        public EventStatus? Status { get; set; }
        public int? OrganizationId { get; set; }
    }
}