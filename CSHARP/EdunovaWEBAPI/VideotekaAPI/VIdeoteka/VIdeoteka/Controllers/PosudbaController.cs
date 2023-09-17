using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using VIdeoteka.Data;
using VIdeoteka.Models;

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

        [HttpGet("{Sifra}")]
        public IActionResult GetPosudba(int id)
        {
            try
            {
                var posudba = _videotekaContext.posudba
                    .Include(p => p.Kazete)
                    .SingleOrDefault(p => p.Sifra == id);

                if (posudba == null)
                {
                    return NotFound(); // Vraćamo 404 ako posudba s traženim ID-om ne postoji
                }

                return Ok(posudba);
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
                return CreatedAtAction(nameof(GetPosudba), new { id = posudba.Sifra }, posudba);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPut("{Sifra}")]
        public IActionResult Put(int id, Posudba posudba)
        {
            if (id != posudba.Sifra || !_videotekaContext.posudba.Any(p => p.Sifra == id))
            {
                return BadRequest();
            }

            try
            {
                _videotekaContext.Entry(posudba).State = EntityState.Modified;
                _videotekaContext.SaveChanges();

                return Ok(posudba);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpDelete("{Sifra}")]
        public IActionResult Delete(int id)
        {
            var posudba = _videotekaContext.posudba.Find(id);
            if (posudba == null)
            {
                return NotFound();
            }

            try
            {
                _videotekaContext.posudba.Remove(posudba);
                _videotekaContext.SaveChanges();
                return Ok(new { poruka = "Obrisano" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }
    }
}