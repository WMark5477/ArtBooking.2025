using AutoMapper;
using Business.Application.DTOs.Organizations;
using Business.Application.DTOs.Events;
using Business.Model.Entities.Organizations;
using Business.Model.Entities.Events;

namespace Business.Application.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map from CreateArtOrganizationDto to ArtOrganization entity
            CreateMap<CreateArtOrganizationDto, ArtOrganization>();

            // Map from ArtOrganization entity to ArtOrganizationDto
            CreateMap<ArtOrganization, ArtOrganizationDto>();

            // Map from CreateArtEventDto to ArtEvent entity
            CreateMap<CreateArtEventDto, ArtEvent>();

            // Map from ArtEvent entity to ArtEventDto
            CreateMap<ArtEvent, ArtEventDto>();
        }
    }
}