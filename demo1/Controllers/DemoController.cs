using demo1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo1.Controllers
{
    [Route("demo")]
    [ApiController]
    public class DemoController : ControllerBase
    {

        [Route("heure")]
        [HttpGet]
        public string GetHeure() {
            return DateTime.Now.ToLongTimeString();
        }

        [Route("doubler/{a}")]
        [HttpPost]
        public IActionResult Doubler(int a) {
            return Ok(a + a);
        }

        [Route("add/{nom}/{b}")]
        [HttpGet]
        public IActionResult Add(string nom,  int b)
        {
            return Ok(nom + b.ToString());
        }

        [Route("bonjour/{nom}")]
        [HttpGet]
        public IActionResult Bonjour(string nom)
        {
            return Ok("Bonjour " + nom);
        }


        [Route("bonjour")]
        [HttpGet]
        public IActionResult Bonjour([FromServices] INomService nomService, [FromServices] ILogger<DemoController> log)
        {
            log.LogInformation($"Dire Bonjour à {nomService.Nom}");
            return Ok($"Bonjour {nomService.Nom}!");
        }

        [Route("bonjour")]
        [HttpPost]
        public IActionResult Bonjour([FromBody]string nom, [FromServices]INomService nomService)
        {
            nomService.Nom = nom;
            return Created("bonjour", nom);
        }







    }
}
