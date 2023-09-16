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

            var clan = _videotekaContext.clan.ToList();
            if (clan == null || clan.Count == 0)
            {
                return new EmptyResult();
            }

            List<CLANDTO> vrati = new();

            clan.ForEach(p =>

            {
                var pdto = new CLANDTO()
                {
                    Sifra = p.Sifra,
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
        public IActionResult Post(CLANDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Clan p = new Clan()
                {
                    Sifra = dto.Sifra,
                    Ime = dto.Ime,
                    Prezime = dto.Prezime,
                    Adresa = dto.Adresa,
                    Mobitel = dto.Mobitel,
                    OIB = dto.OIB,
                    Datum_Uclanjenja = dto.Datum_Uclanjenja,
                };
                _videotekaContext.clan.Add(p);
                _videotekaContext.SaveChanges();
                dto.Sifra = p.Sifra;
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }

        }


        /// <summary>
        /// Mijenja podatke postojećeg clana u bazi
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

        [HttpPut]
        [Route("{Sifra:int}")]

        public IActionResult Put(int Sifra, CLANDTO pdto)
        {
            if (Sifra <= 0 || pdto == null)
            {
                return BadRequest();
            }
            try
            {
                var clan = _videotekaContext.clan.Find(Sifra);
                if (clan == null)
                {
                    return BadRequest();
                }
                clan.Ime = pdto.Ime;
                clan.Prezime = pdto.Prezime;
                clan.Adresa = pdto.Adresa;
                clan.Mobitel = pdto.Mobitel;
                clan.OIB = pdto.OIB;
                clan.Datum_Uclanjenja = pdto.Datum_Uclanjenja;

                _videotekaContext.clan.Update(clan);
                _videotekaContext.SaveChanges();
                pdto.Sifra = clan.Sifra;
                return StatusCode(StatusCodes.Status200OK, pdto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
            }
        }

        /// <summary>
        /// Briše clana iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    DELETE api/v1/Polaznik/1
        ///    
        /// </remarks>
        /// <param name="sifra">Šifra polaznika koji se briše</param>  
        /// <returns>Odgovor da li je obrisano ili ne</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi polaznika kojeg želimo obrisati</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        [HttpDelete]
        [Route("{Sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int Sifra)
        {
            if (Sifra <= 0)
            {
                return BadRequest();
            }

            var clan = _videotekaContext.clan.Find(Sifra);
            if (clan == null)
            {
                return BadRequest();
            }

            try
            {
                _videotekaContext.clan.Remove(clan);
                _videotekaContext.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");

            }
            catch (Exception ex)
            {

                return new JsonResult("{\"poruka\":\"Ne može se obrisati\"}");

            }

        }
    }
}

        




