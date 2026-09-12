using ITI_Project.Model;

namespace ITI_Project.ModelView
{
    public class HomeIndexViewModel
    {
        public List<Book> NewArrivals { get; set; } = new();
        public List<Book> MostLoans { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
    }
}
