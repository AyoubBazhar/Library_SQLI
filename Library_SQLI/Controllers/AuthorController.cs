using Library_SQLI.Mappers;
using Library_SQLI.Models;
using Library_SQLI.Repository;
using Library_SQLI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_SQLI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;//injection repos
        }

        public ActionResult Index()
        {
            var authors = _authorRepository.GetAuthorList();
            var authorViewModels = authors.Select(AuthorMapper.GetAuthorViewModelFromAuthor).ToList();
            return View(authorViewModels);
        }
        public IActionResult Details(int id)
        {
            var author = _authorRepository.GetAuthorWithBooks(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }


        public ActionResult Create()
        {
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddAuthorVM authorAddVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var author = AuthorMapper.GetAuthorFromAuthorAddVM(authorAddVM);
                    _authorRepository.AddAuthor(author);
                    return RedirectToAction(nameof(Index));
                }
                return View(authorAddVM);
            }
            catch
            {
                return View(authorAddVM);
            }
        }



        public IActionResult Edit(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            var authorEditVM = AuthorMapper.GetAuthorEditVMFromAuthor(author);
            return View(authorEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorEditVM authorEditVM)
        {
            if (!ModelState.IsValid)
            {
                return View(authorEditVM);
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

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(authorEditVM);
            }
        }




        public ActionResult Delete(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var author = _authorRepository.GetAuthorById(id);
                if (author == null)
                {
                    return NotFound();
                }

                _authorRepository.RemoveAuthor(author);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
