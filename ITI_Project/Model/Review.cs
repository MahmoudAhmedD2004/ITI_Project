using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Model
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = "";
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [ForeignKey("Member")]
        public int MemberId { get; set; }

        public Book? Book { get; set; } 
        public Member? Member { get; set; } 
    }
}
