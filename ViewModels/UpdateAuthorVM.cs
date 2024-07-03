using Library_SQLI.Models;
using System.ComponentModel.DataAnnotations;

namespace Library_SQLI.ViewModels
{
    public class UpdateAuthorVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public ICollection<Book> Books { get; set; }
    }
}
