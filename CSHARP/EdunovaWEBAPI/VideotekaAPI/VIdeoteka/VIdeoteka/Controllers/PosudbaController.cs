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
                        Clan = g.Clan,
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
    }
}
//[HttpPost]
//public IActionResult Post(PosudbaDTO posudbaDTO)
//{
//    if (!ModelState.IsValid)
//    {
//        return BadRequest(ModelState);
//    }
//    if (posudbaDTO.Sifra <= 0)
//    {
//        return BadRequest(ModelState);
//    }
//    try
//    {
//        var kazeta = _context.Kazeta.Find(posudbaDTO.Sifra)
//                    if (kazeta == null)
//        {
//            return BadRequest(ModelState);
//        }
//        Posudba g = new();
//        {
//            Naslov = posudbaDTO.Naslov,
                        



//                }

//            }
//        }
//    }
//}