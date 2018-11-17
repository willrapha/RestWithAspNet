using Microsoft.AspNetCore.Mvc;
using RestWithAspNetSwagger.Business;
using RestWithAspNetSwagger.Data.VO;

namespace RestWithAspNetSwagger.Controllers
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
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();

            return new ObjectResult(_bookBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();

            var updatedBook = _bookBusiness.Update(book);
            if (updatedBook == null) return BadRequest();

            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            _bookBusiness.Delete(id);

            return NoContent();
        }

    }
}
