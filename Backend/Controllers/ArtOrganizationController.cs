using Business.Model.Data;
using Business.Model.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class ArtOrganizationController: ControllerBase {
   
   private readonly ArtBookingDbContext _dbContext;
   
   public ArtOrganizationController(ArtBookingDbContext dbContext) {
      _dbContext = dbContext;
   }

   [HttpPost]
   public ActionResult<ArtOrganization> CreateOrganization(ArtOrganization organization) {
      _dbContext.Add(organization);
      _dbContext.SaveChanges();

      return Ok(organization); 
   }

   [HttpGet]
   public ActionResult<ArtOrganization> GetOrganization(int id) {
      var organization  = _dbContext.ArtOrganizations.Find(id);
      return Ok(organization);
   }
}