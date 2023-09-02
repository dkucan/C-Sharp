using Microsoft.AspNetCore.Mvc;

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
        public int ZbrojParametara (int b = 0, int i = 0)
        {
           return b+i;
        }
    }

}
