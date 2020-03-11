using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Business;
using RestWithASPNET.Model;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookBusiness _bookBusiness;

        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        // GET: api/Book
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());

        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST: api/Book
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            return new ObjectResult(_bookBusiness.Create(book));
        }

        // PUT: api/Book
        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            var result = _bookBusiness.Update(book);
            if (result == null) return BadRequest();

            return new ObjectResult(result);
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
