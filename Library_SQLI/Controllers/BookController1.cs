using Library_SQLI.Mappers;
using Library_SQLI.Models;
using Library_SQLI.Repository;
using Library_SQLI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_SQLI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BooksController(IBookRepository bookRepository,IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        
        public IActionResult Index()
        {
            var books = _bookRepository.GetBookList();
            return View(books);
        }

        
 

    
        public IActionResult Create()
        {
            var authors = _authorRepository.GetAuthorList(); 
            AddBookVM v = new AddBookVM();
            v.Authors=BookMapper.ListAutherSelectedList(authors).ToList();
            return View(v);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddBookVM book)
        {
            if (ModelState.IsValid)
            {
                Book b = BookMapper.VMtoBook(book); 
                _bookRepository.AddBook(b);
                return RedirectToAction(nameof(Index));
            }
            var authors = _authorRepository.GetAuthorList();
            AddBookVM v = new AddBookVM();
            v.Authors = BookMapper.ListAutherSelectedList(authors).ToList();
            return View();
        }


        public IActionResult Edit(int id)
        {
            
            if (!_bookRepository.ExisteWIthID(id))
            {
                return NotFound();
            }
            Book bb = _bookRepository.GetBookByID(id);
            if (bb != null)
            {
                UpdateBookVM V = BookMapper.BOOKTOUpdateVM(bb);
                return View(V);
            }

            return NotFound();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateBookVM vm)
        {
           
            if (ModelState.IsValid)
            {
               
                    if (_bookRepository.ExisteWIthID(vm.Id))
                    {
                        Book b = BookMapper.UpdateVMTOBOOK(vm);
                        _bookRepository.UpdateBook(b);
                         return RedirectToAction(nameof(Index));
                    
                }
                


            }
            return View();

        }

        // GET: Books/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book book = _bookRepository.GetBookByID(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookRepository.RemoveBook(book);
            return RedirectToAction("Index");
        }

       
    }
}
