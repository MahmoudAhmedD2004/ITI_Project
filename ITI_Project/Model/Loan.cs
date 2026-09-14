using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Model
{
    public enum LoanStatus
    {
        Requested,
        Active,
        ReturnRequested,
        Returned,
        Rejected,
        Cancelled
    }

    public class Loan
    {
        public int Id { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime? BorrowDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public LoanStatus Status { get; set; } = LoanStatus.Requested;

        [MaxLength(255)]
        public string? RejectionReason { get; set; }

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