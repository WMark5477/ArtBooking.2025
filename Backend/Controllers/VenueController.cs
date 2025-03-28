using Business.Model.Data;
using Business.Model.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VenueController : ControllerBase
{
    private readonly ArtBookingDbContext _dbContext;

    public VenueController(ArtBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult<Venue> CreateVenue(Venue venue)
    {
        try
        {
            _dbContext.Add(venue);
            _dbContext.SaveChanges();
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

        return CreatedAtAction(nameof(CreateVenue), new { venue.VenueId }, venue);
    }

    [HttpGet("{id}")]
    public ActionResult<Venue> GetVenue(int id)
    {
        try
        {
            var venue = _dbContext.Venues.Find(id);

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
   
    [HttpGet]
    public ActionResult<List<Venue>> GetAllVenues()
    {
        try
        {
            return Ok(_dbContext.Venues.ToList());
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
    
    [HttpPut]
    public ActionResult UpdateVenue(int id, Venue updatedVenue)
    {
        try
        {
            var existingVenue = _dbContext.Venues.Find(id);
            if (existingVenue == null) return Problem(
                statusCode: 404,
                title: "Venue cannot be found",
                detail: $"Venue with id:{id} cannot be found!"
            );
            existingVenue.Name = updatedVenue.Name;
            existingVenue.Areas = updatedVenue.Areas;
            existingVenue.PriceList = updatedVenue.PriceList;
            existingVenue.PriceListId = updatedVenue.PriceListId;
            existingVenue.ArtEvents = updatedVenue.ArtEvents;
            existingVenue.ScheduleItems = updatedVenue.ScheduleItems;
            _dbContext.SaveChanges(); 
            return Ok(existingVenue);
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
    [HttpPatch]
    public ActionResult AssignPriceList(int id, int priceListId)
    {
        try
        {
            var venue = _dbContext.Venues.Find(id);
            var priceList = _dbContext.PriceLists.Find(priceListId);
            if (venue == null) return Problem(
                statusCode: 404,
                title: "Venue cannot be found",
                detail: $"Venue with id:{id} cannot be found!"
            );
            venue.PriceListId = priceListId;
            venue.PriceList = priceList;
            priceList.VenueId = id;
            priceList.Venue = venue;
            _dbContext.SaveChanges();
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

    [HttpDelete]
    public ActionResult DeleteVenue(int id)
    {
        try
        {
            var venue = _dbContext.Venues.Find(id);
            if (venue == null) return Problem(
                statusCode: 404,
                title: "ArtEvent cannot be found",
                detail: $"ArtEvent with id:{id} cannot be found!"
            );
            _dbContext.Venues.Remove(venue);
            _dbContext.SaveChanges();
            return NoContent();
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
}