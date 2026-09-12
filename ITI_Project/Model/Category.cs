using System.ComponentModel.DataAnnotations;

namespace ITI_Project.Model
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = "";
        [MaxLength(255)]
        public string Description { get; set; } = "";
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
