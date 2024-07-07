using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Library_SQLI.ViewModels
{
    public class UpdateBookVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public IList<SelectListItem>? Authors { get; set; }
    }
}
