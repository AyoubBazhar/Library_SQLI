using Library_SQLI.Models;
using Library_SQLI.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Library_SQLI.Mappers
{
    public class BookMapper
    {

        public  static Book VMtoBook (AddBookVM v1)
        {
            Book book = new Book ();
            book.AuthorId = v1.AuthorId;
            book.Title = v1.Title;
            book.Genre = v1.Genre;  
            return book;    
            
        }
    }
}
