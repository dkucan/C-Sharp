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

        /// <summary>
        /// Dohvaća sve kazete iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    GET api/v1/Kazeta
        ///
        /// </remarks>
        /// <returns>Smjerovi u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        /// 
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


        [HttpPost]
        public IActionResult Post(KAZETA Kazeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Kazeta.Add(Kazeta);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, Kazeta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                   ex.Message);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int Sifra, KAZETA Kazeta)
        {

            if (Sifra <= 0 || Kazeta == null)
            {
                return BadRequest();
            }

            try
            {
                var KAZETABaza = _context.Kazeta.Find(Sifra);
                if (KAZETABaza == null)
                {
                    return BadRequest();
                }
              
                KAZETABaza.Naslov = Kazeta.Naslov;
                KAZETABaza.Godina_izdanja = Kazeta.Godina_izdanja;
                KAZETABaza.Zanr = Kazeta.Zanr;
                KAZETABaza.Cijena_posudbe = Kazeta.Cijena_posudbe;
                KAZETABaza.Cijena_zakasnine = Kazeta.Cijena_zakasnine;

                _context.Kazeta.Update(KAZETABaza);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, KAZETABaza);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
            }
        }
        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (sifra <= 0)
            {
                return BadRequest();
            }

            try
            {
                var KAZETABaza = _context.Kazeta.Find(sifra);
                if (KAZETABaza == null)
                {
                    return BadRequest();
                }

                _context.Kazeta.Remove(KAZETABaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");

            }
            catch (Exception ex)
            {

                try
                {
                    SqlException sqle = (SqlException)ex;
                    return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  sqle);
                }
                catch (Exception e)
                {

                }

                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  ex);
            }
        }
    }
}

            
        
   
    