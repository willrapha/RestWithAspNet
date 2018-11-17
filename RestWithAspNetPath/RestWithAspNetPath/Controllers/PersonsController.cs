using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNetPath.Business;
using RestWithAspNetPath.Data.VO;
using Tapioca.HATEOAS;

namespace RestWithAspNetAuthentication.Controllers
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
        private readonly IPersonBusiness _personBusiness;

        /* Injeção de uma instancia de IPersonService ao criar
        uma instancia de PersonController */
        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // SwaggerResponse foi depreciado por isso utilizamos o ProducesResponseType
        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // [SwaggerResponse((202), Type = typeof(List<Person>))]
        // determina o objeto de retorno em caso de sucesso List<Person>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/{id}
        // [SwaggerResponse((202), Type = typeof(Person))]
        // determina o objeto de retorno em caso de sucesso Person
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();

            return Ok(person);
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/
        // [SwaggerResponse((202), Type = typeof(Person))]
        // determina o objeto de retorno em caso de sucesso Person
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(PersonVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]PersonVO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/
        // determina o objeto de retorno em caso de sucesso Person
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPut]
        [ProducesResponseType((202), Type = typeof(PersonVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]PersonVO person)
        {
            if (person == null) return BadRequest();

            var updatedPerson = _personBusiness.Update(person);
            if (updatedPerson == null) return BadRequest();

            return new ObjectResult(updatedPerson);
        }

        [HttpPatch]
        [ProducesResponseType((202), Type = typeof(PersonVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch([FromBody]PersonVO person)
        {
            if (person == null) return BadRequest();

            var updatedPerson = _personBusiness.Update(person);
            if (updatedPerson == null) return BadRequest();

            return new ObjectResult(updatedPerson);
        }


        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/persons/v1/{id}
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpDelete("{id}")]
        [ProducesResponseType((204), Type = typeof(PersonVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            _personBusiness.Delete(id);

            return NoContent(); // 204 Na tela
        }
    }
}
