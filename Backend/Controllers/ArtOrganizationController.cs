using Business.Model.Data;
using Business.Model.Entities.Organizations;
using Xtech.Common.Pagination;
using Microsoft.AspNetCore.Mvc;
using Business.Application.Services.Organizations;
using System;
using System.Linq;
using Business.Application.DTOs.Organizations;

[ApiController]
[Route("api/[controller]")]
public class ArtOrganizationController : ControllerBase
{
    private readonly ArtBookingDbContext _dbContext;
    private readonly IArtOrganizationService _artOrganizationService;

    public ArtOrganizationController(ArtBookingDbContext dbContext, IArtOrganizationService artOrganizationService)
    {
        _dbContext = dbContext;
        _artOrganizationService = artOrganizationService;
    }

    [HttpPost]
    public ActionResult<ArtOrganizationDto> CreateOrganization(CreateArtOrganizationDto organizationDto)
    {
        try
        {
            var createdOrganization = _artOrganizationService.CreateOrganization(organizationDto);
            return CreatedAtAction(nameof(GetOrganization), new { id = createdOrganization.ArtOrganizationId }, createdOrganization);
        }
        catch (Exception exp)
        {
            return Problem(
                statusCode: 500,
                title: "An unexpected error occured",
                // just for debugging purposes
                detail: exp.Message
            );
        }
    }

    [HttpGet("{id}")]
    public ActionResult<ArtOrganizationDto> GetOrganization(int id)
    {
        try
        {
            var organization = _dbContext.ArtOrganizations.Find(id);

            if (organization == null) return Problem(
                statusCode: 404,
                title: "Organization cannot be found",
                detail: $"Organization with id:{id} cannot be found!"
            );

            return Ok(organization.ToDto());
        }
        catch (Exception exp)
        {
            return Problem(
                statusCode: 500,
                title: "An unexpected error occured",
                // just for debugging purposes
                detail: exp.Message
            );
        }
    }

    /// <summary>
    /// List organizations with pagination, filtering, and sorting
    /// </summary>
    /// <param name="listParams">List parameters including pagination, filters, and sorting</param>
    /// <returns>A paged list of art organizations</returns>
    [HttpGet("list")]
    public ActionResult<PagedList<ArtOrganizationDto>> ListOrganizations([FromQuery] PagedListParams<ArtOrganizationFilters> listParams)
    {
        try
        {
            var result = _artOrganizationService.ListOrganizations(listParams);
            return Ok(result);
        }
        catch (Exception exp)
        {
            return Problem(
                statusCode: 500,
                title: "An unexpected error occurred",
                detail: exp.Message
            );
        }
    }

    /// <summary>
    /// Updates an existing art organization
    /// </summary>
    /// <param name="id">The ID of the organization to update</param>
    /// <param name="organizationDto">The updated organization data</param>
    /// <returns>The updated organization</returns>
    [HttpPut("{id}")]
    public ActionResult<ArtOrganizationDto> EditOrganization(int id, CreateArtOrganizationDto organizationDto)
    {
        try
        {
            var existingOrganization = _dbContext.ArtOrganizations.Find(id);
            if (existingOrganization == null)
            {
                return NotFound($"Organization with id:{id} cannot be found!");
            }

            // Update only scalar properties, preserving relationships
            existingOrganization.Name = organizationDto.Name;
            existingOrganization.Description = organizationDto.Description;
            existingOrganization.Kind = organizationDto.Kind;
            existingOrganization.Email = organizationDto.Email;
            existingOrganization.PhoneNumber = organizationDto.PhoneNumber;
            existingOrganization.Website = organizationDto.Website;
            existingOrganization.Street = organizationDto.Street;
            existingOrganization.AddressNumber = organizationDto.AddressNumber;
            existingOrganization.Town = organizationDto.Town;
            existingOrganization.PostalCode = organizationDto.PostalCode;
            existingOrganization.Country = organizationDto.Country;
            existingOrganization.LogoUrl = organizationDto.LogoUrl;
            existingOrganization.UpdatedAt = DateTime.UtcNow;
            // Do NOT update navigation properties (Events, Users)

            _dbContext.SaveChanges();

            return Ok(existingOrganization.ToDto());
        }
        catch (Exception exp)
        {
            return Problem(
                statusCode: 500,
                title: "An unexpected error occurred",
                detail: exp.Message
            );
        }
    }
}