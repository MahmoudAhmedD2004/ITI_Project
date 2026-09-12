using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Model
{
    [Index(nameof(LoanId), IsUnique = true)]
    public class Fine
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPaid { get; set; }
        [ForeignKey("Loan")]
        public int LoanId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Loan? Loan { get; set; }
    }
}
