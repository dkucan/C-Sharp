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

    public class ClanController : ControllerBase
    {
        private readonly videotekaContext _videotekaContext;

        public ClanController(videotekaContext videotekaContext)
        {
            _videotekaContext = videotekaContext;
        }
        /// <summary>
        /// Dohvaća sve clanove iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    GET api/v1/Clan
        ///
        /// </remarks>
        /// <returns>Clanovi u bazi</returns>
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

            var clan = _videotekaContext.Clan.ToList();
            if (clan == null || clan.Count == 0)
            {
                return new EmptyResult();
            }

            List<CLANDTO> vrati = new();

            clan.ForEach(p =>

            {
                var pdto = new CLANDTO()
                {
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Adresa = p.Adresa,
                    Mobitel = p.Mobitel,
                    OIB = p.OIB,
                    Datum_Uclanjenja = p.Datum_Uclanjenja,
                };

                vrati.Add(pdto);


            });


            return Ok(vrati);

        }
        /// <summary>
        /// Dodaje clana u bazu
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    POST api/v1/Clan
        ///    {Ime:"",Prezime:""}
        ///
        /// </remarks>
        /// <returns>Kreirani clan u bazi s svim podacima</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 

        [HttpPost]
        public IActionResult Post (CLANDTO dto)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Clan p = new Clan()
                {
                    Ime = dto.Ime,
                    Prezime = dto.Prezime,
                    Adresa = dto.Adresa,
                    Mobitel = dto.Mobitel,
                    OIB = dto.OIB,
                    Datum_Uclanjenja = dto.Datum_Uclanjenja,
                };
                _videotekaContext.Clan.Add(p);
                _videotekaContext.SaveChanges();
                dto.Sifra = p.Sifra;
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode (StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
           
        }
        /// <summary>
        /// Mijenja podatke postojećeg polaznika u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        /// 
        ///  PUT api/v1/Clan/1
        ///  
        /// {
        /// "sifra": 0,
        /// "Ime" : "string",
        /// "Prezime: "string",
        /// "Adresa": "string",
        /// "Mobitel" : "string",
        /// "Datum_uclanjenja": "datetime"
        /// }
        /// 
        /// </remarks>
        /// <param name="sifra">Sifra clana koji se mijenja</param>
        /// <returns>Svi poslani podaci od clana</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi clana kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        /// </remarks>
        /// </summary>
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put (int sifra, CLANDTO pdto)
        {
            if (sifra <=0 || pdto == null)
            {
                return BadRequest();
            }
            ClanBaza.Ime = pdto.Ime;
            ClanBaza.Prezime = pdto.Prezime;
            ClanBaza.Adresa = pdto.Adresa;
            ClanBaza.Mobitel = pdto.Mobitel;
            ClanBaza.OIB = pdto.OIB;
            ClanBaza.Datum = pdto.Datum_Uclanjenja,

                _videotekaContext.Clan.Update(clanBaza)

        }


    }
}

