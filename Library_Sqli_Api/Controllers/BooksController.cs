using Library_Sqli_Api.Mappers;
using Library_Sqli_Api.Models;
using Library_Sqli_Api.Repository;
using Library_Sqli_Api.ViewModels;
using Library_Sqli_Api.Mappers;
using Library_Sqli_Api.Models;
using Library_Sqli_Api.Repository;
using Library_Sqli_Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library_SQLI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BooksController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _bookRepository.GetBookList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _bookRepository.GetBookByID(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddBookVM book)
        {
            if (ModelState.IsValid)
            {
                Book b = BookMapper.VMtoBook(book);
                _bookRepository.AddBook(b);
                return CreatedAtAction(nameof(GetBook), new { id = b.Id }, b);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, UpdateBookVM vm)
        {
            if (id != vm.Id)
            {
                return BadRequest();
            }

            if (!_bookRepository.ExisteWIthID(id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Book b = BookMapper.UpdateVMTOBOOK(vm);
                _bookRepository.UpdateBook(b);
                return NoContent();
            }

            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book bookToDelete = _bookRepository.GetBookByID(id);
            if (bookToDelete == null)
            {
                return NotFound();
            }

            _bookRepository.RemoveBook(bookToDelete);
            return NoContent();
        }

    }
}
