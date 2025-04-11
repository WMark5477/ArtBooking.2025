using AutoMapper;
using Business.Application.DTOs.Events;
using Business.Model.Entities.Events;

namespace Business.Application.Mapping
{
    public class ArtEventProfile : Profile
    {
        public ArtEventProfile()
        {
            CreateMap<ArtEvent, ArtEventDto>();
            CreateMap<CreateArtEventDto, ArtEvent>();
        }
    }
}