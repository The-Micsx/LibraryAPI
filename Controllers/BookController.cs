using LibraryAPI.ActionClass.HelperClass.DTO;
using LibraryAPI.Interfes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _IBook;
        public BookController(IBook ibook) => _IBook = ibook;

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<BookDTO>> Get() => await Task.FromResult(_IBook.GetBook());

        [HttpDelete("book/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<string>>> Delete(long id) => await Task.FromResult(_IBook.DeleteBook(id));

        [HttpGet("book/{title}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<BookDTO>> Get(string title) => await Task.FromResult(_IBook.GetBookOfTitle(title));
    }
}
