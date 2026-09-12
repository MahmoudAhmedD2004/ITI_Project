using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.ModelView
{
    public class CreateBookViewModel
    {
        [Required]
        public string Title { get; set; } = "";
        [Required]
        [MaxLength(13)]
        public string ISBN { get; set; } = "";
        [Required]
        public string Summary { get; set; } = "";
        [Required]
        public string BookLanguage { get; set; } = "";
        [Required]
        public int PublishedYear { get; set; }
        [Required]

        public IFormFile? CoverImageFile { get; set; }
        // public string CoverImage { get; set; } = "";
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
