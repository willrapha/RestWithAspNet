using Microsoft.AspNetCore.Mvc;
using RestWithAspNetLayers.Model;
using RestWithAspNetLayers.Services.Implementations;

namespace RestWithAspNetLayers.Controllers
{
    /* Mapeia as requisições de http://localhost:{porta}/api/person/
   Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
   pegando a primeira parte do nome da classe em lower case [Person]Controller
   e expõe como endpoint REST
   */
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonsController : Controller
    {
        private IPersonService _personService;

        /* Injeção de uma instancia de IPersonService ao criar
        uma instancia de PersonController */
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/person/
        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/person/{id}
        //recebendo um ID como no Path da requisição
        //Get com parâmetros para o FindById --> Busca Por ID
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();

            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            _personService.Delete(id);

            return NoContent(); // 204 Na tela
        }
    }
}
