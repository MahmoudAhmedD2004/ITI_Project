using ITI_Project.Model;

namespace ITI_Project.ModelView
{
    public class FilterViewModel
    {
        public int Category { get; set; }
        public int Author { get; set; }
        public string BookLanguage { get; set; } = "";
        public BookCopyStatus? Availability { get; set; }
        public string SortBy { get; set; } = "";
        public int Page { get; set; } = 1;
        public int TotalPages { get; set; }
    }
}