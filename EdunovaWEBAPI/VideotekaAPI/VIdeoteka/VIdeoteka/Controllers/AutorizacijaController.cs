﻿using System.IdentityModel.Tokens.Jwt;
using System.Text;
using VIdeoteka.Data;
using VIdeoteka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EdunovaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AutorizacijaController : ControllerBase
    {

        private readonly videotekaContext _videotekaContext;


        public AutorizacijaController(videotekaContext context)
        {
            _videotekaContext = context;
        }



        [HttpPost("token")]
        public IActionResult GenerirajToken(Operater operater)
        {


            var operBaza = _videotekaContext.Operater
                   .Where(p => p.Email!.Equals(operater.Email))
                   .FirstOrDefault();

            if (operBaza == null)
            {
                // Šaljem Status403Forbidden jer forntend hvata sve 401 i baca na login pa nikada ne dobijem poruku da
                // nije dobro korisničko ime ili lozinka
                return StatusCode(StatusCodes.Status403Forbidden, "Niste autorizirani, ne mogu naći operatera");
            }



            if (!BCrypt.Net.BCrypt.Verify(operater.Lozinka, operBaza.Lozinka))
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Niste autorizirani, lozinka ne odgovara");
            }


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("MojKljucKojijeJakoTajan");


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.Add(TimeSpan.FromHours(8)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);


            return Ok(jwt);

        }
    }
}