using Business.Model.Entities.Organizations;
using System;

namespace Business.Application.DTOs.Organizations
{
    /// <summary>
    /// Mapper for converting between ArtOrganization entities and DTOs
    /// </summary>
    public static class ArtOrganizationMapper
    {
        /// <summary>
        /// Maps an ArtOrganization entity to an ArtOrganizationDto
        /// </summary>
        public static ArtOrganizationDto ToDto(this ArtOrganization entity)
        {
            return new ArtOrganizationDto
            {
                ArtOrganizationId = entity.ArtOrganizationId,
                Name = entity.Name,
                Description = entity.Description,
                Kind = entity.Kind,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Website = entity.Website,
                Street = entity.Street,
                AddressNumber = entity.AddressNumber,
                Town = entity.Town,
                PostalCode = entity.PostalCode,
                Country = entity.Country,
                LogoUrl = entity.LogoUrl,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        /// <summary>
        /// Maps a CreateArtOrganizationDto to an ArtOrganization entity
        /// </summary>
        public static ArtOrganization ToEntity(this CreateArtOrganizationDto dto)
        {
            return new ArtOrganization
            {
                Name = dto.Name,
                Description = dto.Description,
                Kind = dto.Kind,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Website = dto.Website,
                Street = dto.Street,
                AddressNumber = dto.AddressNumber,
                Town = dto.Town,
                PostalCode = dto.PostalCode,
                Country = dto.Country,
                LogoUrl = dto.LogoUrl
            };
        }
    }
}