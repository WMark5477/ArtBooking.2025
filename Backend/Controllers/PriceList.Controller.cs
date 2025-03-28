using Business.Model.Data;
using Business.Model.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PriceListController : ControllerBase
{
    private readonly ArtBookingDbContext _dbContext;

    public PriceListController(ArtBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public ActionResult<PriceList> CreatePriceList(PriceList priceList)
    {
        try
        {
            _dbContext.Add(priceList);
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

        return CreatedAtAction(nameof(CreatePriceList), new { priceList.PriceListId }, priceList);
    }

    [HttpPost("copy/{id}")]
    public ActionResult CopyPriceList(int id)
    {
        try
        {
            var priceList = _dbContext.PriceLists.Find(id);
            if (priceList == null) return Problem(
                statusCode: 404,
                title: "PriceList cannot be found",
                detail: $"PriceList with id:{id} cannot be found!"
            );
            var copiedPriceList = new PriceList();
            copiedPriceList.VenueId = priceList.VenueId;
            copiedPriceList.Venue = priceList.Venue;
            copiedPriceList.ArtEventId = priceList.ArtEventId;
            copiedPriceList.ArtEvent = priceList.ArtEvent;
            copiedPriceList.PriceEntries = priceList.PriceEntries;
            _dbContext.PriceLists.Add(copiedPriceList);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(CopyPriceList), new { copiedPriceList.PriceListId }, copiedPriceList);
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
    public ActionResult<PriceList> GetPriceList(int id)
    {
        try
        {
            var priceList = _dbContext.PriceLists.Find(id);

            if (priceList == null) return Problem(
                statusCode: 404,
                title: "PriceList cannot be found",
                detail: $"PriceList with id:{id} cannot be found!"
            );
            return Ok(priceList);
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
    public ActionResult<List<PriceList>> GetAllPriceLists()
    {
        try
        {
            return Ok(_dbContext.PriceLists.ToList());
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
    public ActionResult UpdatePriceList(int id, PriceList updatedPriceList)
    {
        try
        {
            var existingPriceList = _dbContext.PriceLists.Find(id);
            if (existingPriceList == null) return Problem(
                statusCode: 404,
                title: "Venue cannot be found",
                detail: $"Venue with id:{id} cannot be found!"
            );
            existingPriceList.VenueId = updatedPriceList.VenueId;
            existingPriceList.Venue = updatedPriceList.Venue;
            existingPriceList.ArtEventId = updatedPriceList.ArtEventId;
            existingPriceList.ArtEvent = updatedPriceList.ArtEvent;
            existingPriceList.PriceEntries = updatedPriceList.PriceEntries;
            _dbContext.SaveChanges(); 
            return Ok(existingPriceList);
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
    public ActionResult DeletePriceList(int id)
    {
        try
        {
            var priceList = _dbContext.PriceLists.Find(id);
            if (priceList == null) return Problem(
                statusCode: 404,
                title: "ArtEvent cannot be found",
                detail: $"ArtEvent with id:{id} cannot be found!"
            );
            _dbContext.PriceLists.Remove(priceList);
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