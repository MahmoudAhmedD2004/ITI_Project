using ITI_Project.Model;

namespace ITI_Project.ModelView
{
    public class BookViewModel
    {
        public FilterViewModel Filter { get; set; } = new();
        public CreateBookViewModel Create { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
        public List<Author> Authors { get; set; } = new();
        public List<Book> Books { get; set; } = new();
    }
}
