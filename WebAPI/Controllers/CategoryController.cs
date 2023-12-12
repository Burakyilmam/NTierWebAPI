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
        [HttpDelete("DeleteAll")]
        public IActionResult DeleteAll()
        {
            var value = _categoryService.List();
            if (value != null)
            {
                _dataContext.RemoveRange(value);
                _dataContext.SaveChanges();
                return Ok("Kategoriler başarıyla silindi.");
            }
            else
            {
                return NotFound("Kategori bulunmamaktadır.");
            }
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {

            var existingCategory = _dataContext.Categories.FirstOrDefault(s => s.Id == category.Id);
            if (existingCategory != null)
            {
                return Conflict($"ID değeri {category.Id} olan kitap zaten mevcut.");
            }     
            else
            {
                category.CreateDate = DateTime.Now;
                category.Statu = true;
                category.UpdateDate = null;
                _categoryService.Add(category);
                return Ok("Kategori başarıyla eklendi.");
            }
        }
        [HttpPut]
        public IActionResult Update(string name, int id)
        {
            var value = _categoryService.Get(id);
            
            if (value != null)
            {
                value.Name = name;
                value.UpdateDate = DateTime.Now;
                _categoryService.Update(value);
                return Ok($"ID değeri {value.Id} olan kategori başarıyla güncellendi.");
            }

            else
            {
                return Conflict($"ID değeri {id} olan kategori bulunmamaktadır.");
            }
        }
    }
}
