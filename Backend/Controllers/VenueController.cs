using Business.Model.Data;
using Business.Model.Entities.Venues;
using Xtech.Common.Pagination;
using Microsoft.AspNetCore.Mvc;
using Business.Application.Services.Venues;
using Business.Application.DTOs.Venues;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class VenueController : ControllerBase
{
    private readonly IVenueService venueService;
    public VenueController(IVenueService venueService)
    {
        this.venueService = venueService;
    }

    [HttpPost]
    public ActionResult<VenueDto> CreateVenue(CreateVenueDto venueDto, [FromQuery] int? artOrganizationId = null)
    {
        try
        {
            var createdVenue = venueService.CreateVenue(venueDto, artOrganizationId);
            return CreatedAtAction(nameof(GetVenue), new { id = createdVenue.VenueId }, createdVenue);
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
    public ActionResult<Venue> GetVenue(int id)
    {
        try
        {
            var venue = venueService.GetVenue(id);

            if (venue == null) return Problem(
                statusCode: 404,
                title: "Venue cannot be found",
                detail: $"Venue with id:{id} cannot be found!"
            );
            return Ok(venue);
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
    /// List venues with pagination, filtering, and sorting
    /// </summary>
    /// <param name="listParams">List parameters including pagination, filters, and sorting</param>
    /// <returns>A paged list of venues</returns>
    [HttpGet("list")]
    public ActionResult<PagedList<Venue>> ListVenues([FromQuery] PagedListParams<VenueFilters> listParams)
    {
        try
        {
            var result = venueService.ListVenues(listParams);
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
    /// Updates an existing venue
    /// </summary>
    /// <param name="id">The ID of the venue to update</param>
    /// <param name="venue">The updated venue data</param>
    /// <returns>The updated venue</returns>
    [HttpPut("{id}")]
    public ActionResult<Venue> EditVenue(int id, VenueDto venueDto)
    {
        try
        {
            var updatedVenue = venueService.EditVenue(id, venueDto);

            if (updatedVenue == null)
            {
                return Problem(
                    statusCode: 404,
                    title: "Venue cannot be found",
                    detail: $"Venue with id:{id} cannot be found!"
                );
            }

            return Ok(updatedVenue);
        }
        catch (ArgumentException exp)
        {
            return Problem(
                statusCode: 409,
                title: "Venue name must be unique",
                detail: $"Venue with name: {venueDto.Name} already exists!"
            );
        }
    }

    /// <summary>
    /// Deletes a venue by ID
    /// </summary>
    /// <param name="id">The ID of the venue to delete</param>
    /// <returns>No content if successful</returns>
    [HttpDelete("{id}")]
    public ActionResult DeleteVenue(int id)
    {
        try
        {
            var venue = venueService.GetVenue(id);
            if (venue == null)
            {
                return NotFound($"Venue with id:{id} cannot be found!");
            }

            venueService.DeleteVenue(id);
            

            return NoContent();
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