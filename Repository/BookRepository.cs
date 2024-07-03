using Library_SQLI.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_SQLI.Repository
{
    public class BookRepository : IBookRepository
    {
        MyContext _context;
        public BookRepository(MyContext _context)
        {
            this._context = _context;
        }
        public void AddBook(Book bk)
        {
            _context.Books.Add(bk);
            _context.SaveChanges();
        }

        public bool Existe(Book b11)
        {
            Book u = _context.Books.FirstOrDefault(bb1=>bb1.Id==b11.Id);
            if (u != null)
            {
                return true;
            }
            return false;
        }

        public IList<Book> GetBookList()
        {
           IList<Book> books = new List<Book>();

            books = _context.Books.Include(a=>a.Id).ToList();
            return books;
        }

        public void RemoveBook(Book bkk)
        {
           if (Existe(bkk))
            {
                _context.Remove(bkk);
                _context.SaveChanges();
            }
        }
        public void UpdateBook(Book book)
        {
            var existingBook = _context.Books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Genre = book.Genre;
                existingBook.AuthorId = book.AuthorId;
                _context.Entry(existingBook).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
}
}
