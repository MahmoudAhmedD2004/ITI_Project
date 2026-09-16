using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Model
{
    [Index(nameof(MemberId), nameof(BookId), IsUnique = true)]
    public class Favorite
    {
        public int Id { get; set; }
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;

        public Member? Member { get; set; }
        public Book? Book { get; set; }
    }
}
