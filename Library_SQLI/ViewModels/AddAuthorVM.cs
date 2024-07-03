using Library_SQLI.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library_SQLI.ViewModels
{
    public class AddAuthorVM
    {

        [Required]
        public string Name { get; set; }

    }
}
