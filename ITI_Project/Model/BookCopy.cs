using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Model
{
    [Index(nameof(Barcode), IsUnique = true)]
    public class BookCopy
    {
        public int Id { get; set; }
        public string Barcode { get; set; } = "";
        public string Status { get; set; } = "";
        public int BookId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Book? Book { get; set; }
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
