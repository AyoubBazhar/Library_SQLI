using Library_Sqli_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library_Sqli_Api.ViewModels
{
    public class AddAuthorVM
    {

        [Required]
        public string Name { get; set; }

    }
}
