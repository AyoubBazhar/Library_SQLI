using Library_SQLI.Models;
using Library_SQLI.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Library_SQLI.Mappers
{
    public class BookMapper
    {

        public  static Book VMtoBook (AddBookVM ?v1)
        {
            Book book = new Book ();
            book.AuthorId = v1.AuthorId;
            book.Title = v1.Title;
            book.Genre = v1.Genre;  
            return book;    
            
        }

        public  static UpdateBookVM BOOKTOUpdateVM (Book b)
        {
            if (b != null) { 
            UpdateBookVM vm = new UpdateBookVM ();
            vm.AuthorId = b.AuthorId;
            vm.Title = b.Title;
            vm.Genre = b.Genre;
            return vm;
            }
            return null; 
        }


        public static Book UpdateVMTOBOOK(UpdateBookVM vm)
        {
            if (vm != null)
            {
                Book bb = new Book();
                bb.Id = vm.Id;
                bb.AuthorId = vm.AuthorId;
                bb.Title = vm.Title;
                bb.Genre = vm.Genre;
                
                return bb;
            }
            return null;
        }
        public static BookVM FromBookToBookVM(Book bb)
        {
            return new BookVM
            {
                AuthorId = bb.AuthorId,
                Title = bb.Title,
                Genre = bb.Genre,
            };
        }
        public static  IEnumerable<SelectListItem> ListAutherSelectedList (IList<Author> Mylist)
        {
            foreach(var book in Mylist) { 
            SelectListItem selectListItems = new SelectListItem();
               
                selectListItems.Value= book.Id.ToString();
                selectListItems.Text = book.Name;    
                yield return selectListItems;  

            }
        }
    }
}
