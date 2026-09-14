using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Model
{
    public enum BookCopyStatus
    {
        Available,
        Reserved,
        Borrowed
    }

    [Index(nameof(Barcode), IsUnique = true)]
    public class BookCopy
    {
        public int Id { get; set; }
        public string Barcode { get; set; } = "";
        public BookCopyStatus Status { get; set; } = BookCopyStatus.Available;
        public int BookId { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Book? Book { get; set; }

        public ICollection<Loan> Loans { get; set; } = [];
    }
}