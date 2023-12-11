using Business.Abstract;
using Business.Concrete;
using DataAccess.Repositories;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IGenericService<Book> _bookService;
        private readonly DataContext _dataContext;

        public BookController(IGenericService<Book> bookService, DataContext dataContext)
        {
            _bookService = bookService;
            _dataContext = dataContext;
        }

        [HttpGet("ListBook")]
        public IActionResult ListBook()
        {
            var value = _bookService.List();
            if (value == null)
            {
                return NotFound("Kitap Bulunamadı.");
            }
            return Ok(value);
        }

        [HttpGet("GetBook/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound("Kitap bulunamadı.");
            }
            return Ok(book);
        }
        [HttpDelete("DeleteById")]
        public IActionResult DeleteById(int id)
        {
            var value = _bookService.Get(id);
            if (value != null)
            {
                _bookService.Delete(value);
                return Ok($"ID değeri {value.Id} olan kitap başarıyla silindi.");
            }
            else
            {
                return NotFound("Kitap bulunmamaktadır.");
            }

        }
        [HttpDelete("DeleteAll")]
        public IActionResult DeleteAll()
        {
            var value = _dataContext.Books.ToList();
            if (value != null)
            {
                _dataContext.RemoveRange(value);
                _dataContext.SaveChanges();
                return Ok($"kitaplar başarıyla silindi.");
            }
            else
            {
                return NotFound("Kitap bulunmamaktadır.");
            }
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {

            var existingBook = _dataContext.Books.FirstOrDefault(s => s.Id == book.Id);
            if (existingBook != null)
            {
                return Conflict($"ID değeri {book.Id} olan kitap zaten mevcut.");
            }
            var categoryId = _dataContext.Categories.FirstOrDefault(x => x.Id == book.CategoryId);
            var writerId = _dataContext.Writers.FirstOrDefault(x => x.Id == book.WriterId);
            if (categoryId == null && writerId == null)
            {
                return Conflict($"Kategori ve yazar bulunmamaktadır.");
            }
            if (categoryId == null)
            {
                return Conflict($"Kategori bulunmamaktadır.");
            }
            else if (writerId == null)
            {
                return Conflict($"Yazar bulunmamaktadır.");
            }
            else
            {
                _bookService.Add(book);
                return Ok("Kitap başarıyla eklendi.");
            }
        }
        [HttpPut]
        public IActionResult Update(string name, decimal price, int categoryId, int writerId, int id)
        {
            var value = _bookService.Get(id);
            var existcategoryId = _dataContext.Categories.FirstOrDefault(x => x.Id == categoryId);
            var existwriterId = _dataContext.Writers.FirstOrDefault(x => x.Id == writerId);
            if (existcategoryId == null && existwriterId == null)
            {
                return Conflict($"Kategori ve yazar bulunmamaktadır.");
            }
            if (existcategoryId == null)
            {
                return Conflict($"Kategori bulunmamaktadır.");
            }
            if (existwriterId == null)
            {
                return Conflict($"Yazar bulunmamaktadır.");
            }
            if (value != null)
            {
                value.Name = name;
                value.Price = price;
                value.WriterId = writerId;
                value.CategoryId = categoryId;
                _bookService.Update(value);
                return Ok($"ID değeri {value.Id} olan kitap başarıyla güncellendi.");
            }

            else
            {
                return Conflict($"ID değeri {id} olan kitap bulunmamaktadır.");
            }
        }
    }

}
