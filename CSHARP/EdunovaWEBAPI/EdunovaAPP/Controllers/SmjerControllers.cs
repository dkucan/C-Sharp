using EdunovaAPP.Models;
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
        public IActionResult Post(Smjer smjer)
        {
            // dodavanje u bazu
            return Created("/api/v1/Smjer", smjer);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        
        public IActionResult Put(int sifra, Smjer smjer)
        {

            return StatusCode(StatusCodes.Status200OK, smjer);
        }
        [HttpDelete]
        [Route("{sifra:int")]
        [Produces("aplication/json")]

        public IActionResult Delete(int sifra)
        {
            // brisanje u bazi
            return StatusCode(StatusCodes.Status200OK, "{\"obrisano\": true}");

        }
    }

}
