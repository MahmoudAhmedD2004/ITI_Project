using ITI_Project.ModelView;

namespace ITI_Project.Services
{
    public interface IAiService
    {
        Task<BookAutoSummaryDto> GenerateBookSummaryAsync(string backCoverText, List<string> availableCategories);
    }
}