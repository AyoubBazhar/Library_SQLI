using Library_Sqli_Api.Models;
using Library_Sqli_Api.ViewModels;
using Library_Sqli_Api.ViewModels.ViewModels;

namespace Library_Sqli_Api.Mappers
{
    public class AuthorMapper
    {
        //conversion mn viewmodels l model author
        public static Author GetAuthorFromAuthorAddVM(AddAuthorVM authorAddVM)
        {
            return new Author
            {
                Name = authorAddVM.Name,
               
            };
        }
        public static AuthorEditVM GetAuthorEditVMFromAuthor(Author author)
        {
            return new AuthorEditVM
            {
                Id = author.Id,
                Name = author.Name,
            };
        }


        public static Author GetAuthorFromAuthorEditVM(AuthorEditVM authorEditVM)
        {
            return new Author
            {
                Id = authorEditVM.Id,
                Name = authorEditVM.Name,
              
            };
        }

        public static AuthorViewModel GetAuthorViewModelFromAuthor(Author author)
        {
            return new AuthorViewModel
            {
                Id = author.Id,
                Name = author.Name,
                
            };
        }
    }
}
