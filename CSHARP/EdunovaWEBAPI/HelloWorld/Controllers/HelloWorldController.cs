using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public String Hello()
        {
            return "Hello World";
        }

        [HttpGet]
        [Route("Pozdrav")]

        public String DrugaMetoda()
        {

            return "Pozdrav svijetu";
        }

        [HttpGet]
        [Route("PozdravParametar")]
        public String DrugaMetoda(string s)
        {
            return "Hello " + s;
        }

        [HttpGet]
        [Route("PozdravVišeParametara")]
        public String DrugaMetoda(string s = "", int i = 0)
        {
            return "Hello " + s + " " + i;
        }

        // Kreirajte rutu /HelloWorld/zad1 koja ne prima paramtere i vraća Vaše ime

        [HttpGet]
        [Route("MojeIme")]
        public String HelloWorld()
        {
            return "Darko";
        }

        [HttpGet]
        [Route("ZbrojDvaBroja")]
        public int ZbrojParametara(int b = 0, int i = 0)
        {
            return b + i;
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public String PozdravRuta(int sifra)
        {
            return "Hello" + sifra;
        }

        [HttpGet]
        [Route("{sifra:int}/{kategorija}")]
        public String PozdravRuta2(int sifra, string kategorija)
        {
            return "Hello" + sifra + "" + kategorija;
        }

        [HttpPost]
        public string DodavanjeNovog(string ime)
        {
            return "dodao " + ime;
        }
        [HttpPut]
        public string promjena(int sifra, string naziv)
        {
            return "Na šifri " + sifra + "postavljam " + naziv;
        }

        [HttpDelete]
        public bool Obrisao (int sifra)
        {
            return true;
        }

        [HttpGet]
        [Route("matrica")]
        public IActionResult Matrica (int x, int y)
        {
            var m = new int[x, y];

            
            return new JsonResult (JsonConvert.SerializeObject(m));
        }
    }

    }

