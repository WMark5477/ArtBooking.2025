using Business.Model.Entities.Events;
using Business.Model.Entities.Events.Enums;
using System;

namespace Business.Application.DTOs.Events
{
    public class ArtEventDto
    {
        public int ArtEventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EventStatus Status { get; set; }
        public EventCategory Category { get; set; }
        public string ImageUrl { get; set; }
        public int ArtOrganizationId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}