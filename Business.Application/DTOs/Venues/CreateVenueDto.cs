using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.DTOs.Venues
{
    public class CreateVenueDto
    {
        public int VenueId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Website { get; set; }
        public int? Capacity { get; set; }
        public string? ImageUrl { get; set; }
        public int ArtOrganizationId { get; set; }
    }
}
