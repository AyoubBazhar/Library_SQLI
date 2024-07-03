using Library_SQLI.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_SQLI.Repository
{
    public class AuthorRepository : IAuthorRepository
    {

        MyContext _context;
        public AuthorRepository(MyContext _context)
        {
            this._context = _context;
        }
        public void AddAuthor(Author a)
        {
           _context.Authors.Add(a);
            _context.SaveChanges(); 
        }

        public IList<Author> GetAuthorList()
        {
            IList<Author> list = new List<Author>();   
            
            list= _context.Authors.ToList();
            return list;
        }

        public void RemoveAuthor(Author a)
        {
            if (Existe(a)) {
                _context.Authors.Include(a=>a.Books).Remo;
                _context.SaveChanges();
            }
        }

        public void UpdateAuthor()
        {
            _context.SaveChanges();
        }
        public Boolean Existe(Author a1)
        {
        Author aa = _context.Authors.FirstOrDefault(a=>a.Id == a1.Id);
            if (aa != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
