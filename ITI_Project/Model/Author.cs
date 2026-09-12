using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Model
{
    public class Author
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";
        public string Bio { get; set; } = "";
        [Column(TypeName = "nvarchar(max)")]
        public string Photo { get; set; } = "";
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
