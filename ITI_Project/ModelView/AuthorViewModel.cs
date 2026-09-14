using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ITI_Project.Model;

namespace ITI_Project.ModelView
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name of Author Is Required")]
        public string Name { get; set; }
        public string? Bio {  get; set; }
        public IFormFile? Photo { get; set; }
        public string? ExistingPhoto { get; set; }
    }

    public class AuthorDetailsViewModel
    {
        public Author Author { get; set; } = default!;
        public IEnumerable<Book> Books {  get; set; } = new List<Book>();

    }
}
