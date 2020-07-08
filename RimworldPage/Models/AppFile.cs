using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Models
{
    public class AppFile
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
    }

    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name = "File")]
        [BindProperty]
        public IFormFile FormFile { get; set; }
    }
}