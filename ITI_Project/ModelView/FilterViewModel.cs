namespace ITI_Project.ModelView
{
    public class FilterViewModel
    {
        public int Category { get; set; }
        public int Author { get; set; } 
        public string BookLanguage { get; set; } = "";
        public string Availability { get; set; } = "";
        public string SortBy { get; set; } = "";
    }
}
