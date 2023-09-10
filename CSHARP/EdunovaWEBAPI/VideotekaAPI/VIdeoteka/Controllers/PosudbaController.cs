using Microsoft.AspNetCore.Mvc;
using VIdeoteka.Models;

namespace VIdeoteka.Controllers
{ 
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PosudbaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get ()
        {
            var lista = new List<Posudba>()
            {
                new () {Naslov = "Titanic"},
                new () {Naslov = "Armageddon"},
            };
            return new JsonResult(lista);
        }

        [HttpPost]
        public IActionResult Post(Posudba posudba)
        {
            return Created ("/api/v1/Posudba", posudba);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put (int sifra, Posudba posudba)
        {
            // promjena u bazi
            return StatusCode(StatusCodes.Status200OK, posudba);

        }
        [HttpDelete]
        [Route("{sifra:int}")]
        public IActionResult Delete(int sifra, Posudba posudba)
        {
            // brisanje u bazi
            return StatusCode(StatusCodes.Status200OK, "{\"obrisano\": true}"); ;

        }

    }
}
