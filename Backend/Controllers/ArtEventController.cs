using Business.Model.Data;
using Business.Model.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ArtEventController : ControllerBase
{
    private readonly ArtBookingDbContext _dbContext;

    public ArtEventController(ArtBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult<ArtEvent> CreateArtEvent(ArtEvent artEvent)
    {
        try
        {
            _dbContext.Add(artEvent);
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

        return CreatedAtAction(nameof(CreateArtEvent), new { artEvent.ArtEventId }, artEvent);
    }

    [HttpGet("{id}")]
    public ActionResult<ArtEvent> GetArtEvent(int id)
    {
        try
        {
            var artEvent = _dbContext.ArtEvents.Find(id);

            if (artEvent == null) return Problem(
                statusCode: 404,
                title: "ArtEvent cannot be found",
                detail: $"ArtEvent with id:{id} cannot be found!"
            );
            return Ok(artEvent);
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
    public ActionResult<List<ArtEvent>> GetAllArtEvents()
    {
        try
        {
            return Ok(_dbContext.ArtEvents.ToList());
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
    public ActionResult UpdateArtEvent(int id, ArtEvent updatedEvent)
    {
        try
        {
            var existingEvent = _dbContext.ArtEvents.Find(id);
            if (existingEvent == null) return Problem(
                statusCode: 404,
                title: "Venue cannot be found",
                detail: $"Venue with id:{id} cannot be found!"
            );
            existingEvent.Name = updatedEvent.Name;
            existingEvent.Description = updatedEvent.Description;
            existingEvent.Venue = updatedEvent.Venue;
            existingEvent.Date = updatedEvent.Date;
            existingEvent.Location = updatedEvent.Location;
            existingEvent.PriceList = updatedEvent.PriceList;
            existingEvent.ScheduleItems = updatedEvent.ScheduleItems;
            existingEvent.ArtOrganization = updatedEvent.ArtOrganization;
            _dbContext.SaveChanges(); 
            return Ok(existingEvent);
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
    public ActionResult DeleteArtEvent(int id)
    {
        try
        {
            var artEvent = _dbContext.ArtEvents.Find(id);
            if (artEvent == null) return Problem(
                statusCode: 404,
                title: "ArtEvent cannot be found",
                detail: $"ArtEvent with id:{id} cannot be found!"
            );
            _dbContext.ArtEvents.Remove(artEvent);
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