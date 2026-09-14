using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [ForeignKey("Member")]
        public int MemberId { get; set; } 
        public DateTime ReservationDate { get; set; }
        public  string Status { get; set; } = "";
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Book? Book { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Member? Member { get; set; }
    }
}
