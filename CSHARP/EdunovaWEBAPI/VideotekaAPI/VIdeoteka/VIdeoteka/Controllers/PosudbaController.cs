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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var novaPosudba = _videotekaContext.posudba.ToList();
                if (novaPosudba == null || novaPosudba.Count == 0)
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
                return StatusCode(StatusCodes.Status201Created, posudba);
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
                var novaPosudba= _videotekaContext.posudba.Find(sifra);
                if (novaPosudba == null)
                {
                    return BadRequest();
                }
                // inače se rade Mapper-i
                // mi ćemo za sada ručno
                posudba.Datum_posudbe = novaPosudba.Datum_posudbe;
                posudba.Datum_vracanja = novaPosudba.Datum_vracanja;
                posudba.Clan = novaPosudba.Clan;
                posudba.Zakasnina = novaPosudba.Zakasnina;

                _videotekaContext.posudba.Update(novaPosudba);
                _videotekaContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, novaPosudba);
                
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
                var novaPosudba = _videotekaContext.posudba.Find(sifra);
                if (novaPosudba == null)
                {
                    return BadRequest();
                }

                _videotekaContext.posudba.Remove(novaPosudba);
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