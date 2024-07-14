using Library_Sqli_Api.Mappers;
using Library_Sqli_Api.Models;
using Library_Sqli_Api.Repository;
using Library_Sqli_Api.ViewModels;
using Library_Sqli_Api.Mappers;
using Library_Sqli_Api.Models;
using Library_Sqli_Api.Repository;
using Library_Sqli_Api.ViewModels.ViewModels;
using Library_Sqli_Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Library_Sqli_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly MyContext _context;

        public AuthorsController(IAuthorRepository authorRepository, MyContext context)
        {
             _context = context;

            _authorRepository = authorRepository;
        }

        // GET: api/authors
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors([FromQuery] Boolean includeBooks)
        {
            //var authors = _authorRepository.GetAuthorList();
            //var authorViewModels = authors.Select(AuthorMapper.GetAuthorViewModelFromAuthor).ToList();

            IQueryable<Author> query = _context.Authors;

            if (includeBooks)
            {
                query = query.Include(a => a.Books);
            }
            var authors = query.ToList();
            if (includeBooks)
            {
                // Break circular references manually
                foreach (var author in authors)
                {
                    foreach (var book in author.Books)
                    {
                        book.Author = null;
                    }
                }
            }

            return Ok(authors);
        }

        // GET: api/authors/5
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id, [FromQuery] Boolean includeBooks)
        {
            
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return author;
        }

        // POST: api/authors
        [HttpPost]
        public ActionResult<Author> PostAuthor(AddAuthorVM authorAddVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var author = AuthorMapper.GetAuthorFromAuthorAddVM(authorAddVM);
                    _authorRepository.AddAuthor(author);
                    return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
                }
                return BadRequest(ModelState);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/authors/5
        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, AuthorEditVM authorEditVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authorEditVM.Id)
            {
                return BadRequest();
            }

            try
            {
                var author = _authorRepository.GetAuthorById(id);
                if (author == null)
                {
                    return NotFound();
                }

                author.Name = authorEditVM.Name;
                _authorRepository.UpdateAuthor(author);

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/authors/5
        [HttpDelete("{id}")]
        public ActionResult<Author> DeleteAuthor(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            _authorRepository.RemoveAuthor(author);

            return author;
        }
    }
}
