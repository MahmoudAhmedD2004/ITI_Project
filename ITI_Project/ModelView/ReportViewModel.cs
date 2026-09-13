using ITI_Project.Model;

namespace ITI_Project.ModelView
{
    public class ReportViewModel
    {
        public List<Loan> Loans { get; set; } = new();
        public Dictionary<string,int> MostBorrowed { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
        
    }
}
