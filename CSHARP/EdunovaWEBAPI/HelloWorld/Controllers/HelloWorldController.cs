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
        public String DrugaMetoda(string s="", int i=0)
        {
            return "Hello " + s + " " + i;
        }


    }
}
