using VIdeoteka.Data;
using VIdeoteka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using VIdeoteka.Models.DTO;
using System.Runtime.Serialization;
using System.Data.SqlTypes;
using System.Globalization;

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

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {

            if (sifra <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var s = _context.Kazeta.Find(sifra);

                if (s == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, s);
                }

                return new JsonResult(s);

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
        public IActionResult Put(int sifra, KAZETA Kazeta)
        {

            if (sifra <= 0 || Kazeta == null)
            {
                return BadRequest();
            }

            try
            {
                var KazetaBaza = _context.Kazeta.Find(sifra);
                if (KazetaBaza == null)
                {
                    return BadRequest();
                }
                // inače se rade Mapper-i
                // mi ćemo za sada ručno
                KazetaBaza.Naslov = Kazeta.Naslov;
                KazetaBaza.Godina_izdanja = Kazeta.Godina_izdanja;
                KazetaBaza.Zanr = Kazeta.Zanr;
                KazetaBaza.Cijena_posudbe = Kazeta.Cijena_posudbe;
                KazetaBaza.Cijena_zakasnine = Kazeta.Cijena_zakasnine;

                _context.Kazeta.Update(KazetaBaza);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, KazetaBaza);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  ex); // kada se vrati cijela instanca ex tada na klijentu imamo više podataka o grešci
                // nije dobro vraćati cijeli ex ali za dev je OK
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
        //[HttpGet]
        //[Route("DodajKazeteFaker")]
        //public string PopuniBazu()
        //{
        //    KAZETA p;
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        p = new()
        //        {
        //            Naslov = Faker.Company.Name(), //stavljeno ovako zbog upisa u bazu
        //            Godina_izdanja = DateTime.Now,
        //            Zanr = Faker.Company.Suffix(), //stavljeno ovako zbog upisa u bazu
        //            Cijena_posudbe = Faker.RandomNumber.Next(2, 5),
        //            Cijena_zakasnine = Faker.RandomNumber.Next(2, 5),
        //        };
        //        _context.Kazeta.Add(p);
        //        _context.SaveChanges();
        //    }

        //    return "Uneseno 1000 fake kazeta";

        // Faker ne bih želio brisati ali je morao ići van iz produkcije zato što je u bazi još bio problem sa Godinom izdanja koja se morala
        // prebaciti sa DateTime na int a nije bilo baš nikakve mogućnosti faker prilagoditi tako da... No ostavljam ga ovdje zakomentiranog
        // za uspomenu na trud...

        }

    }
         
        
   
    