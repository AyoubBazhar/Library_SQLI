using Library_SQLI.Mappers;
using Library_SQLI.Models;
using Library_SQLI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_SQLI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController1(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;//injection repos
        }

        public ActionResult Index()
        {
            var authors = _authorRepository.GetAuthorList();
            var authorViewModels = authors.Select(AuthorMapper.GetAuthorViewModelFromAuthor).ToList();
            return View(authorViewModels);
           
        }

        public ActionResult Details(int id)
        {
            var author = _authorRepository.GetAuthorList().FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            var authorViewModel = AuthorMapper.GetAuthorViewModelFromAuthor(author);
            return View(authorViewModel);
        }

 
        public ActionResult Create()
        {
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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


        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
