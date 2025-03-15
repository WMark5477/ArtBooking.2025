using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TestConroller: ControllerBase{
   [HttpGet()]
   public ActionResult Check(){
      return Ok(new {
         Message = "Git"
      });
   }
}