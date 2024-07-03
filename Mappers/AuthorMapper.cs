using Library_SQLI.Models;
using Library_SQLI.ViewModels;

namespace Library_SQLI.Mappers
{
    public class AuthorMapper
    {

        public static AddAuthorVMTOAuthor(AddAuthorVM v1)
        {
            Author author = new Author();
            author.Name = v1.Name;  
            author.Id=v1.ID;
            

        }
    }
}
