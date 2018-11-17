using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNetAuthentication.Business;
using RestWithAspNetAuthentication.Data.VO;

namespace RestWithAspNetAuthentication.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookBusiness _bookBusiness;

        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();

            return new ObjectResult(_bookBusiness.Create(book));
        }

        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Put([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();

            var updatedBook = _bookBusiness.Update(book);
            if (updatedBook == null) return BadRequest();

            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public IActionResult Delete(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            _bookBusiness.Delete(id);

            return NoContent();
        }

    }
}
