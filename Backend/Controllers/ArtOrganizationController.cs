using Business.Model.Data;
using Business.Model.Entities.Organizations;
using Xtech.Common.Pagination;
using Microsoft.AspNetCore.Mvc;
using Business.Application.Services.Organizations;
using System;
using System.Linq;
using Business.Application.DTOs.ArtOrganizationFilters;

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
    public ActionResult<ArtOrganization> CreateOrganization(ArtOrganization organization)
    {
        try
        {
            var createdOrganization = _artOrganizationService.CreateOrganization(organization);
            return CreatedAtAction(nameof(CreateOrganization), new { createdOrganization.ArtOrganizationId }, createdOrganization);
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

    [HttpGet]
    public ActionResult<ArtOrganization> GetOrganization(int id)
    {
        try
        {
            var organization = _dbContext.ArtOrganizations.Find(id);

            if (organization == null) return Problem(
                statusCode: 404,
                title: "Organization cannot be found",
                detail: $"Organization with id:{id} cannot be found!"
            );
            return Ok(organization);
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
    public ActionResult<PagedList<ArtOrganization>> ListOrganizations([FromQuery] PagedListParams<ArtOrganizationFilters> listParams)
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
    /// <param name="organization">The updated organization data</param>
    /// <returns>The updated organization</returns>
    [HttpPut("{id}")]
    public ActionResult<ArtOrganization> EditOrganization(int id, ArtOrganization organization)
    {
        try
        {
            if (id != organization.ArtOrganizationId)
            {
                return BadRequest("The ID in the URL does not match the ID in the provided data.");
            }

            var existingOrganization = _dbContext.ArtOrganizations.Find(id);
            if (existingOrganization == null)
            {
                return NotFound($"Organization with id:{id} cannot be found!");
            }

            // Update only scalar properties, preserving relationships
            existingOrganization.Name = organization.Name;
            existingOrganization.Description = organization.Description;
            existingOrganization.Kind = organization.Kind;
            existingOrganization.Email = organization.Email;
            existingOrganization.PhoneNumber = organization.PhoneNumber;
            existingOrganization.Website = organization.Website;
            existingOrganization.Street = organization.Street;
            existingOrganization.AddressNumber = organization.AddressNumber;
            existingOrganization.Town = organization.Town;
            existingOrganization.PostalCode = organization.PostalCode;
            existingOrganization.Country = organization.Country;
            existingOrganization.LogoUrl = organization.LogoUrl;
            // Do NOT update navigation properties (Events, Users)

            _dbContext.SaveChanges();

            return Ok(existingOrganization);
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