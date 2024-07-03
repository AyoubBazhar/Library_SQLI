using Library_SQLI.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library_SQLI.ViewModels
{
    public class AddAuthorVM
    {
        [HiddenInput] 
        public  int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ICollection<Book> Books { get; set; }
    }
}
