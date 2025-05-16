using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;

        public BookController(IBookService bookService, 
            IAuthorService authorService, 
            ICategoryService categoryService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> InsertBook([FromBody] Book book)
        {
            if(await _authorService.GetAuthorById(book.AuthorId) == null)
            {
                return NotFound("Khong co tac gia nay de them vao sach");
            }
            if(await _categoryService.GetCategoryById(book.CategoryId) == null)
            {
                return NotFound("Khong co loai sach nay");
            }
            var newBook = await _bookService.InsertBook(book);
            if (newBook == null)
            {
                return BadRequest("Loi khong them duoc sach nay");
            }
            return Ok(newBook);
        }

        [HttpPut]
        public async Task<ActionResult<Book>> UpdateBook([FromBody] Book book)
        {
            var findBook = await _bookService.GetBookById(book.Id);
            if(findBook == null)
            {
                return NotFound("Khong tim thay sach nay de sua");
            }
            if (await _authorService.GetAuthorById(book.AuthorId) == null)
            {
                return NotFound("Khong co tac gia nay de sua vao sach");
            }
            if (await _categoryService.GetCategoryById(book.CategoryId) == null)
            {
                return NotFound("Khong co loai sach nay");
            }
            var bookUpdate = await _bookService.UpdateBook(book);
            if (bookUpdate == null)
            {
                return BadRequest("Khong the sua duoc sach nay");
            }
            return Ok(bookUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _bookService.DeleteBook(id);
            if (book == null)
            {
                return BadRequest("Khong the xoa duoc sach nay");
            }
            return Ok(book);
        }

        [HttpPost("{authorName}")]
        public async Task<ActionResult<Book>> InsertBookWithAuthorName(string authorName, [FromBody] Book book)
        {
            var authors = await _authorService.GetAllAuthors();
            var author = authors.FirstOrDefault(a => a.Name == authorName);
            if (author == null)
            {
                return NotFound("Khong co tac gia nay de them vao sach");
            }
            book.AuthorId = author.Id;
            if (await _categoryService.GetCategoryById(book.CategoryId) == null)
            {
                return NotFound("Khong co loai sach nay");
            }
            var newBook = await _bookService.InsertBook(book);
            if (newBook == null)
            {
                return BadRequest("Loi khong them duoc sach nay");
            }
            return Ok(newBook);
        }
    }
}
