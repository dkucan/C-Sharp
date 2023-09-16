using VIdeoteka.Data;
using VIdeoteka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace VIdeoteka.Controllers
{
    /// <summary>
    /// Namijenjeno za CRUD operacije sa entitetom POSUDBA u bazi
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PosudbaController : ControllerBase
    {
        private readonly videotekaContext _videotekaContext;

        public PosudbaController(videotekaContext videotekaContext)
        {
            _videotekaContext = videotekaContext;
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
                var posudba = _videotekaContext.posudba.ToList();
                if (posudba == null || posudba.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_videotekaContext.posudba.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        /// <summary>
        /// Dodaje posudbu u bazu
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
        public IActionResult Post(Posudba Posudba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _videotekaContext.posudba.Add(Posudba);
                _videotekaContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, Posudba);
            } catch (Exception ex) { }
            {
                return BadRequest(ModelState);
            }
            }
        }
    }


