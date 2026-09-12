using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Model
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [ForeignKey("BookCopy")]
        public int BookCopyId { get; set; }
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public BookCopy? BookCopy { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Member? Member { get; set; }
        public Fine? Fines { get; set; } 
    }
}
