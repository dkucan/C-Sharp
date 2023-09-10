using VIdeoteka.Data;
using VIdeoteka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace VIdeoteka.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KazetaController : ControllerBase
    {
        private readonly videotekaContext _context;

        public KazetaController(videotekaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var Kazeta = _context.Kazeta.ToList();
                if (Kazeta == null || Kazeta.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.Kazeta.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }

        }

        /// <summary>
        /// Dodaje kazetu u bazu
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    POST api/v1/Kazeta
        ///    {naslov:"",trajanje:90}
        ///
        /// </remarks>
        /// <returns>Kreirana kazeta u bazi s svim podacima</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response
    }
}

       