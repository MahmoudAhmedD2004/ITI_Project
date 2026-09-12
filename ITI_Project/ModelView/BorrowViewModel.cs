using ITI_Project.Model;
using System.ComponentModel.DataAnnotations;

namespace ITI_Project.ModelView
{
    public class BorrowViewModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; } = "";
        public string BookCover { get; set; } = "";
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }

        public List<Member> Members { get; set; } = new();

        [Required(ErrorMessage = "Please select a member")]
        public int MemberId { get; set; }
    }
}