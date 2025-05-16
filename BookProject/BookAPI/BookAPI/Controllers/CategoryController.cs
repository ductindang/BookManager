using BusinessLogicLayer.Services;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;

        public CategoryController(ICategoryService categoryService, IBookService bookService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategorys()
        {
            var cates = await _categoryService.GetAllCategorys();
            return Ok(cates);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> InsertCategory([FromBody] Category category)
        {
            var cate = await _categoryService.InsertCategory(category);
            if (cate == null)
            {
                return BadRequest("Loi khong them duoc loai sach nay");
            }
            return Ok(cate);
        }

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory([FromBody] Category category)
        {
            var findCate = await _categoryService.GetCategoryById(category.Id);
            if (findCate == null)
            {
                return NotFound("Khong tim thay loai sach nay de sua");
            }
            var cate = await _categoryService.UpdateCategory(category);
            if (cate == null)
            {
                return BadRequest("Khong the sua duoc loai sach nay");
            }
            return Ok(cate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var findCate = await _categoryService.GetCategoryById(id);
            if (findCate == null)
            {
                return NotFound("Khong tim thay loai sach nay de xoa");
            }
            if (await _bookService.GetBookByCategory(id) != null)
            {
                return BadRequest("Khong the xoa loai sach nay, vi du lieu sach dang co");
            }
            var cate = await _categoryService.DeleteCategory(id);
            if (cate == null)
            {
                return BadRequest("Khong the xoa duoc loai sach nay");
            }
            return Ok(cate);
        }
    }
}
