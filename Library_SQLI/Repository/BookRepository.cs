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
            Book u = _context.Books.Include(I=>I.Author).FirstOrDefault(bb1=>bb1.Id==b11.Id);
            if (u != null)
            {
                return true;
            }
            return false;
        }

        public Book GetBookByID(int  id)
        {
            return _context.Books.Include(I => I.Author).FirstOrDefault(bb1 => bb1.Id == id);
        }

        public bool ExisteWIthID(int  id)
        {
            Book u = _context.Books.Include(i=>i.Author).FirstOrDefault(bb1=>bb1.Id==id);

            if (u != null)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }
        public List<Book> GetBookList()
        {
           List<Book> books = new List<Book>();

            books = _context.Books.Include(I=>I.Author).ToList();
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
            var existingBook = _context.Books.Include(I=>I.Author).FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Genre = book.Genre;
              
               
                _context.SaveChanges();
            }
        }
}
}
