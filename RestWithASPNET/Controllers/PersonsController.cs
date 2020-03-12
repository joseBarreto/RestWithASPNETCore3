using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Business;
using RestWithASPNET.Data.VO;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<PersonVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(PersonVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        [SwaggerResponse((201), Type = typeof(PersonVO))]        
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {

            if (person == null)
                return BadRequest();

            return new ObjectResult(_personBusiness.Create(person));
        }

        [HttpPut]
        [SwaggerResponse((202), Type = typeof(PersonVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();

            var result = _personBusiness.Update(person);
            if (result == null) return BadRequest();

            return new ObjectResult(result);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse((204), Type = typeof(PersonVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
