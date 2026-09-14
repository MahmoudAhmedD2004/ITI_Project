using ITI_Project.Model;
using System.ComponentModel.DataAnnotations;

namespace ITI_Project.ModelView
{
    public class ReviewViewModel
    {
        public int LoanId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Comment { get; set; } = "";
        public Loan? Loan { get; set; }
    }
}
