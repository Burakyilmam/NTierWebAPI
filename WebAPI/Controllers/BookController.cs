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
    }

}
