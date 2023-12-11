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
    }

}
