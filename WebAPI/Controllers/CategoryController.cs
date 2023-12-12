using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IGenericService<Category> _categoryService;
        private readonly DataContext _dataContext;

        public CategoryController(IGenericService<Category> categoryService, DataContext dataContext)
        {
            _categoryService = categoryService;
            _dataContext = dataContext;
        }
        [HttpGet("ListCategory")]
        public IActionResult ListCategory()
        {
            var value = _categoryService.List();
            if (value == null)
            {
                return NotFound("Kategori Bulunamadı.");
            }
            return Ok(value);
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.Get(id);
            if (value == null)
            {
                return NotFound("Kategori Bulunamadı.");
            }
            return Ok(value);
        }
        [HttpDelete("DeleteById")]
        public IActionResult DeleteById(int id)
        {
            var value = _categoryService.Get(id);
            if (value != null)
            {
                _categoryService.Delete(value);
                return Ok($"ID değeri {value.Id} olan kategori başarıyla silindi.");
            }
            else
            {
                return NotFound("Kitap bulunmamaktadır.");
            }
        }
    }
}
