using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNetQueryParams.Business;
using RestWithAspNetQueryParams.Data.VO;
using Tapioca.HATEOAS;

namespace RestWithAspNetQueryParams.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : Controller
    {
        private readonly IBookBusiness _bookBusiness;

        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();

            return new ObjectResult(_bookBusiness.Create(book));
        }

        [HttpPut]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();

            var updatedBook = _bookBusiness.Update(book);
            if (updatedBook == null) return BadRequest();

            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            _bookBusiness.Delete(id);

            return NoContent();
        }

    }
}
