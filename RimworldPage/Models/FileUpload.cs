using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Models
{
    public class FileUpload
    {
        public static readonly string[] Versions = { "1.0", "1.1" };
        public static readonly string[] Expansions = { "Royalty" };

        [Required]
        [Display(Name = "File")]
        [BindProperty]
        public IFormFile FormFile { get; set; }

        [Display(Name = "Name for the list (Optional)")]
        [BindProperty]
        public string? Name { get; set; }

        [Display(Name = "Rimworld version (Optional)")]
        [BindProperty]
        public string? Version { get; set; }

        [Display(Name = "Expansions used (Optional)")]
        [BindProperty]
        public List<string>? ExpansionsUsed { get; set; }
    }
}