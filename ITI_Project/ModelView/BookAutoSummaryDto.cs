namespace ITI_Project.ModelView
{
    public class BookAutoSummaryDto
    {
        public string Summary { get; set; } = "";
        public string Category { get; set; } = "";
        public List<string> Tags { get; set; } = new();
    }
}
