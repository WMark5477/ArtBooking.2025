using AutoMapper;
using Business.Application.DTOs.Venues;
using Business.Model.Entities.Venues;

namespace Business.Application.Mapping
{
    public class VenueProfile : Profile
    {
        public VenueProfile()
        {
            CreateMap<Venue, VenueDto>();
            CreateMap<CreateVenueDto, Venue>();
        }
    }
}
