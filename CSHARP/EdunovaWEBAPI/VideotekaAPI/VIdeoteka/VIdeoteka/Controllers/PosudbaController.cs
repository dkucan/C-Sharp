using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using VIdeoteka.Data;
using VIdeoteka.Models;
using Microsoft.Data.SqlClient;
using VIdeoteka.Models.DTO;

namespace VIdeoteka.Controllers
{
    /// <summary>
    /// Namijenjeno za CRUD operacije nad posudbom
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]

    public class PosudbaController : ControllerBase
    {
        private readonly videotekaContext _context;
        private readonly ILogger<PosudbaController> _logger;
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context"></param>

        public PosudbaController(videotekaContext context,
            ILogger<PosudbaController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Dohvaćam grupe");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var posudba = _context.posudba
                    .Include(g => g.Kazete)
                    .Include(g => g.Clan)
                    .ToList();

                if (posudba == null || posudba.Count == 0)
                {
                    return new EmptyResult();
                }
                List<PosudbaDTO> vrati = new();

                posudba.ForEach(g =>
                {
                    vrati.Add(new PosudbaDTO()
                    {
                        Clan = g.Clan.Ime+""+g.Clan.Prezime,
                        Datum_posudbe = g.Datum_posudbe,
                        Datum_vracanja = g.Datum_vracanja,
                        Zakasnina = g.Zakasnina,

                    });
                });
                return Ok(vrati);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);

            }
        }
        [HttpPost]
        public IActionResult Post(PosudbaDTO posudbaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (posudbaDTO.Sifra <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var kazeta = _context.posudba.Find(posudbaDTO.Sifra);
                if (kazeta == null)
                {
                    return BadRequest(ModelState);
                }
                Posudba g = new()
                {
                   
                    Datum_posudbe = posudbaDTO.Datum_posudbe,
                    Datum_vracanja = posudbaDTO.Datum_vracanja,
                    Zakasnina = posudbaDTO.Zakasnina,
                };
                _context.posudba.Add(g);
                _context.SaveChanges();

                posudbaDTO.Sifra = g.Sifra;
                posudbaDTO.Kazete = g.Kazete;

                return Ok(posudbaDTO);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
            }
        }
        [HttpPut]
        [Route("{Sifra:int}")]
        public IActionResult Put(int Sifra, PosudbaDTO posudbaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (Sifra <= 0 || posudbaDTO == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var kazete = _context.Kazeta.Find(posudbaDTO.Sifra);
                if (kazete == null)
                {
                    return BadRequest();
                }
                var posudba = _context.posudba.Find(Sifra);
                if (posudba == null)
                {
                    return BadRequest(ModelState);
                }
                posudba.Sifra = posudbaDTO.Sifra;
                posudba.Datum_posudbe = posudbaDTO.Datum_posudbe;
                posudba.Datum_vracanja = posudbaDTO.Datum_vracanja;
                posudba.Zakasnina = posudbaDTO.Zakasnina;


                _context.posudba.Update(posudba);
                _context.SaveChanges();

                return Ok(posudbaDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }

        }
        [HttpDelete]
        [Route("{Sifra:int}")]
        [Produces("application/json")]

        public IActionResult Delete (int sifra)
        {
            if (sifra <=0)
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

                return new JsonResult("{\"poruka\":\"obrisano\"}");
            }
            catch (Exception ex)
            {
                return new JsonResult ("{\"poruka\":\"Ne može se obrisati\"}");
            }
        }

    }
}



