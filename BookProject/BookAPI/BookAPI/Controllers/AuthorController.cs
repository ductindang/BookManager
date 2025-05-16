using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public AuthorController(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthors();
            return Ok(authors);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> InsertAuthor([FromBody] Author author)
        {
            var newAuthor = await _authorService.InsertAuthor(author);
            if (newAuthor == null)
            {
                return BadRequest("Loi khong them duoc tac gia nay");
            }
            return Ok(newAuthor);
        }

        [HttpPut]
        public async Task<ActionResult<Author>> UpdateAuthor([FromBody] Author author)
        {
            var findAuthor = await _authorService.GetAuthorById(author.Id);
            if (findAuthor == null)
            {
                return NotFound("Khong tim thay tac gia nay de sua");
            }
            var authorUpdate = await _authorService.UpdateAuthor(author);
            if (authorUpdate == null)
            {
                return BadRequest("Khong the sua duoc tac gia nay");
            }
            return Ok(authorUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            var findAuthor = await _authorService.GetAuthorById(id);
            if (findAuthor == null)
            {
                return NotFound("Khong tim thay tac gia nay de xoa");
            }
            if (await _bookService.GetBookByAuthor(id) != null)
            {
                return BadRequest("Khong the xoa tac gia nay, vi du lieu sach dang co");
            }
            var author = await _authorService.DeleteAuthor(id);
            if (author == null)
            {
                return BadRequest("Khong the xoa duoc tac gia nay");
            }
            return Ok(author);
        }
    }
}
