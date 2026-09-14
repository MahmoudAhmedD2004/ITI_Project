using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Model
{
    [Index(nameof(ISBN), IsUnique = true)]
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }="";
        [MaxLength(13)]
        public string ISBN { get; set; } = "";
        public string Summary { get; set; } = "";
        public string BookLanguage { get; set; } = "";
        public int PublishedYear { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string CoverImage { get; set; } = "";
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Author? Author { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Category? Category { get; set; } 
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();

        [NotMapped]
        public string Initials =>
           string.Join("", Title.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Take(3)
                                 .Select(w => char.ToUpper(w[0])));

        private static readonly string[] Palette = {
            "#A2703F,#8A5C31",
            "#5E7D63,#3F5843",
            "#1D2A38,#2A3B4D",
            "#B0503C,#8C3B2A",
            "#7C8A97,#5B6773"
        };

        [NotMapped]
        public string CoverColorStart => Palette[Id % Palette.Length].Split(',')[0];
        [NotMapped]
        public string CoverColorEnd => Palette[Id % Palette.Length].Split(',')[1];
    }
}
