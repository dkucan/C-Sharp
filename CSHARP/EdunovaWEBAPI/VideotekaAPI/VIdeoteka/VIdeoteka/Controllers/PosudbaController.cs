using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using VIdeoteka.Data;
using VIdeoteka.Models;
using Microsoft.Data.SqlClient;

namespace VIdeoteka.Controllers
{
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
            try
            {
                var posudbe = _videotekaContext.posudba
                    .Include(p => p.Kazete)
                    .ToList();

                if (posudbe == null || posudbe.Count == 0)
                {
                    return NotFound(); // Vraćamo 404 ako nema posudbi
                }

                return Ok(posudbe);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Posudba posudba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _videotekaContext.posudba.Add(posudba);
                _videotekaContext.SaveChanges();
                return CreatedAtAction(nameof(Get), new { Sifra = posudba.Sifra }, posudba);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Posudba posudba)
        {

            if (sifra <= 0 || posudba == null)
            {
                return BadRequest();
            }

            try
            {
                var posudbe = _videotekaContext.posudba.Find(sifra);
                if (posudbe == null)
                {
                    return BadRequest();
                }
                // inače se rade Mapper-i
                // mi ćemo za sada ručno
                posudbe.Datum_Posudbe = posudbe.Datum_Posudbe;
                posudbe.Datum_Vracanja = posudbe.Datum_Vracanja;
                posudbe.Clan = posudbe.Clan;
                posudbe.Zakasnina = posudbe.Zakasnina;

                _videotekaContext.posudba.Update(posudbe);
                _videotekaContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, posudbe);

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
                var posudba = _videotekaContext.posudba.Find(sifra);
                if (posudba == null)
                {
                    return BadRequest();
                }

                _videotekaContext.posudba.Remove(posudba);
                _videotekaContext.SaveChanges();

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