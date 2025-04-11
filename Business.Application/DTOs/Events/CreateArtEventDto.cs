using Business.Model.Entities.Events.Enums;

namespace Business.Application.DTOs.Events
{
    public class CreateArtEventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EventStatus Status { get; set; }
        public EventCategory Category { get; set; }
        public string ImageUrl { get; set; }
    }
}