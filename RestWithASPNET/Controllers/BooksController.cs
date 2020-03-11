using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Model;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {


        // GET: api/Person
        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(_personBusiness.FindAll());
            return Ok();
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            //var person = _personBusiness.FindById(id);
            //if (person == null)
            //    return NotFound();

            //return Ok(person);
            return Ok();
        }

        // POST: api/Person
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {

            //if (person == null)
            //    return BadRequest();

            //return new ObjectResult(_personBusiness.Create(book));
            return Ok();
        }

        // PUT: api/Person
        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            //if (person == null)
            //    return BadRequest();

            //var result = _personBusiness.Update(book);
            //if (result == null) return BadRequest();

            //return new ObjectResult(result);
            return Ok();
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
