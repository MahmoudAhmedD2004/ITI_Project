using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Model
{
    [Index(nameof(BookId), IsUnique = true)]
    public class Ebook
    {
        public int Id { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string FilePath { get; set; } = "";
        public string OriginalFileName { get; set; } = "";
        public DateTime UploadedDate { get; set; } = DateTime.Now;

        public Book? Book { get; set; }
    }
}
