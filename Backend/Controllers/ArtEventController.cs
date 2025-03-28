using Business.Model.Data;
using Business.Model.Entities.Events;
using Business.Model.Entities.Events.Enums;
using Xtech.Common.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class ArtEventController : ControllerBase
{
    private readonly ArtBookingDbContext _dbContext;

    public ArtEventController(ArtBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Creates a new art event
    /// </summary>
    /// <param name="artEvent">The art event to create</param>
    /// <returns>The created art event</returns>
    [HttpPost]
    public ActionResult<ArtEvent> CreateEvent(ArtEvent artEvent)
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
                title: "An unexpected error occurred",
                // just for debugging purposes
                detail: exp.Message
            );
        }

        return CreatedAtAction(nameof(CreateEvent), new { artEvent.ArtEventId }, artEvent);
    }

    /// <summary>
    /// Gets a specific art event by ID
    /// </summary>
    /// <param name="id">The ID of the event to retrieve</param>
    /// <returns>The requested art event</returns>
    [HttpGet]
    public ActionResult<ArtEvent> GetEvent(int id)
    {
        try
        {
            var artEvent = _dbContext.ArtEvents.Find(id);

            if (artEvent == null) return Problem(
                statusCode: 404,
                title: "Event cannot be found",
                detail: $"Event with id:{id} cannot be found!"
            );
            return Ok(artEvent);
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
    /// List art events with pagination, filtering, and sorting
    /// </summary>
    /// <param name="listParams">List parameters including pagination, filters, and sorting</param>
    /// <returns>A paged list of art events</returns>
    [HttpGet("list")]
    public ActionResult<PagedList<ArtEvent>> ListEvents([FromQuery] PagedListParams<ArtEventFilters> listParams)
    {
        try
        {
            var query = _dbContext.ArtEvents.AsQueryable();

            // Apply filters if provided
            if (listParams.Filters != null)
            {
                // Filter by name (case-insensitive partial match)
                if (!string.IsNullOrEmpty(listParams.Filters.Name))
                {
                    query = query.Where(e => e.Name.ToLower().Contains(listParams.Filters.Name.ToLower()));
                }

                // Filter by category
                if (listParams.Filters.Category.HasValue)
                {
                    query = query.Where(e => e.Category == listParams.Filters.Category.Value);
                }

                // Filter by status
                if (listParams.Filters.Status.HasValue)
                {
                    query = query.Where(e => e.Status == listParams.Filters.Status.Value);
                }

                // Filter by organization
                if (listParams.Filters.OrganizationId.HasValue)
                {
                    query = query.Where(e => e.ArtOrganizationId == listParams.Filters.OrganizationId.Value);
                }
            }

            // Apply sorting
            if (listParams.HasSort())
            {
                if (listParams.SortByFieldIs("Name"))
                {
                    query = listParams.IsSortByAsc()
                        ? query.OrderBy(e => e.Name)
                        : query.OrderByDescending(e => e.Name);
                }
                else if (listParams.SortByFieldIs("Status"))
                {
                    query = listParams.IsSortByAsc()
                        ? query.OrderBy(e => e.Status)
                        : query.OrderByDescending(e => e.Status);
                }
                else if (listParams.SortByFieldIs("CreatedAt"))
                {
                    query = listParams.IsSortByAsc()
                        ? query.OrderBy(e => e.CreatedAt)
                        : query.OrderByDescending(e => e.CreatedAt);
                }
                // Default sorting by Name ascending if sort field is not recognized
                else
                {
                    query = query.OrderBy(e => e.Name);
                }
            }
            else
            {
                // Default sorting by Name if no sort specified
                query = query.OrderBy(e => e.Name);
            }

            var result = query.AsPagedList(listParams.PageNumber, listParams.PageSize);
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
    /// Updates an existing art event
    /// </summary>
    /// <param name="id">The ID of the event to update</param>
    /// <param name="artEvent">The updated event data</param>
    /// <returns>The updated event</returns>
    [HttpPut("{id}")]
    public ActionResult<ArtEvent> EditEvent(int id, ArtEvent artEvent)
    {
        try
        {
            if (id != artEvent.ArtEventId)
            {
                return BadRequest("The ID in the URL does not match the ID in the provided data.");
            }

            var existingEvent = _dbContext.ArtEvents.Find(id);
            if (existingEvent == null)
            {
                return NotFound($"Event with id:{id} cannot be found!");
            }

            // Update properties
            existingEvent.Name = artEvent.Name;
            existingEvent.Description = artEvent.Description;
            existingEvent.Status = artEvent.Status;
            existingEvent.Category = artEvent.Category;
            existingEvent.ImageUrl = artEvent.ImageUrl;
            existingEvent.ArtOrganizationId = artEvent.ArtOrganizationId;
            // Do NOT update navigation properties (ScheduleItems, Organization)

            _dbContext.SaveChanges();

            return Ok(existingEvent);
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
    /// Deletes an art event
    /// </summary>
    /// <param name="id">The ID of the event to delete</param>
    /// <returns>No content if successful</returns>
    [HttpDelete("{id}")]
    public ActionResult DeleteEvent(int id)
    {
        try
        {
            var artEvent = _dbContext.ArtEvents.Find(id);
            if (artEvent == null)
            {
                return NotFound($"Event with id:{id} cannot be found!");
            }

            _dbContext.ArtEvents.Remove(artEvent);
            _dbContext.SaveChanges();

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

    /// <summary>
    /// Filter parameters for art event listings
    /// </summary>
    public class ArtEventFilters
    {
        /// <summary>
        /// Filter by event name (partial match)
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Filter by event category
        /// </summary>
        public EventCategory? Category { get; set; }

        /// <summary>
        /// Filter by event status
        /// </summary>
        public EventStatus? Status { get; set; }

        /// <summary>
        /// Filter by organization ID
        /// </summary>
        public int? OrganizationId { get; set; }
    }
}