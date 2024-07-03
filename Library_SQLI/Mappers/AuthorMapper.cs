﻿using Library_SQLI.Models;
using Library_SQLI.ViewModels;

namespace Library_SQLI.Mappers
{
    public class AuthorMapper
    {
        //conversion mn viewmodels l model author
        public static Author GetAuthorFromAuthorAddVM(AuthorAddVM authorAddVM)
        {
            return new Author
            {
                Name = authorAddVM.Name,
               
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
