using Microsoft.AspNetCore.Mvc;

namespace EdunovaAPP.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SmjerControllers : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var lista = new List<Smjer>()
            {
                new() { Naziv = "Prvi" },
                new() { Naziv = "Drugi" }
            };
            return new JsonResult(lista);
        }
        [HttpPost]
        public IActionResult Post(Smjer Smjer) { 
        // dodavanje u bazu
        return new JsonResult(Smjer)}
    }
}
