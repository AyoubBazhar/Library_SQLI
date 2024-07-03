using System.ComponentModel.DataAnnotations;

namespace Library_SQLI.ViewModels
{
    public class UpdateBookVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}
