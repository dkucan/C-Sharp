using VIdeoteka.Data;
using VIdeoteka.Models;
using VIdeoteka.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace VIdeoteka.Controllers
{
    /// <summary>
    /// NAMIJENJENO ZA CRUD OPERACIJE SA ENTITETOM ČLAN U BAZI
    /// </summary>

    [ApiController]
    [Route("api/v1/[controller]")]

    public class PosudbaController : ControllerBase
    {
        private readonly videotekaContext _context;

        public PosudbaController(videotekaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Dohvaća sve posudbe iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    GET api/v1/Posudba
        ///
        /// </remarks>
        /// <returns>Posudbe u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var posudbe = _context.posudba.ToList();
                if (posudbe == null || posudbe.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.posudba.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }
        /// <summary>
        /// Dodaje smjer u bazu
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    POST api/v1/Posudba
        ///    {naziv:"",trajanje:100}
        ///
        /// </remarks>
        /// <returns>Kreirana posudba u bazi s svim podacima</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 

        [HttpPost]
        public IActionResult Post(Posudba posudba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.posudba.Add(posudba);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, posudba);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }
        /// <summary>
        /// Mijenja podatke postojeće posudbe u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/Posudba/1
        ///
        /// {
        ///  "sifra": 0,
        ///  "Datum_posudbe": "datetime",
        ///  "Datum_vraćanja": "datetime",
        ///  "Zakasnina: "int"
        /// }
        ///
        /// </remarks>
        /// <param name="sifra">Šifra smjera koji se mijenja</param>  
        /// <returns>Svi poslani podaci od smjera</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi smjera kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        [HttpPut]
        [Route("{Sifra:int}")]
        public IActionResult Put(int sifra, Posudba posudba)
        {
            if (sifra <= 0 || posudba == null)
            {
                return BadRequest();
            }
            try
            {
                var posudbaBaza = _context.posudba.Find(sifra);
                if (posudbaBaza == null)
                {
                    return BadRequest();
                }
                posudbaBaza.Sifra = posudba.Sifra;
                posudbaBaza.Datum_posudbe = posudba.Datum_posudbe;
                posudbaBaza.Datum_vracanja = posudba.Datum_vracanja;
                posudbaBaza.Zakasnina = posudba.Zakasnina;
                posudbaBaza.Članovi = posudba.Članovi;

                _context.posudba.Update(posudbaBaza);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, posudbaBaza);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
            }
        }

        /// <summary>
        /// Briše posudbu iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    DELETE api/v1/Posudba/1
        ///    
        /// </remarks>
        /// <param name="sifra">Šifra posudbe koja se briše</param>  
        /// <returns>Odgovor da li je obrisano ili ne</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi posudbe koju želimo obrisati</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (sifra <= 0)
            {
                return BadRequest();
            }

            var posudbaBaza = _context.posudba.Find(sifra);
            if (posudbaBaza == null)
            {
                return BadRequest();
            }
            try
            {
                _context.posudba.Remove(posudbaBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");
            }
            catch (Exception ex)
            {
                return new JsonResult("{\"poruka\":\"Ne može se obrisati\"}");
            }
        }
    }
}

