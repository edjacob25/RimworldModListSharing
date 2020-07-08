using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Models
{
    public class FileUpload
    {
        [Required]
        [Display(Name = "File")]
        [BindProperty]
        public IFormFile FormFile { get; set; }

        [Display(Name = "Name for the list (Optional)")]
        [BindProperty]
        public string? Name { get; set; }
    }
}