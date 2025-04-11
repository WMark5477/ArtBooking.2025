using AutoMapper;
using Business.Application.DTOs.Organizations;
using Business.Model.Entities.Organizations;

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
        }
    }
}