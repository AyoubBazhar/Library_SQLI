using Library_SQLI.Models;

namespace Library_SQLI.Repository
{
    public interface IBookRepository
    {

        public void AddBook(Book bk);
        public void RemoveBook(Book bkk);
        public void UpdateBook(Book b1);
        public Book GetBookByID(int id);

        public List<Book> GetBookList();
        public bool ExisteWIthID(int id);
       
        public Boolean Existe(Book b1);
    }
}
