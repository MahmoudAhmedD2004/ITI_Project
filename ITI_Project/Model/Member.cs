using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ITI_Project.Model
{
    public enum Role
    {
        Member,
        Librarian,
        Admin
    }
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class Member
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; } = "";
        [MaxLength(50)]
        public string Email { get; set; } = "";
        [MaxLength (20)]
        public string PhoneNumber { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public Role Role { get; set; }
        public DateTime MembershipStartDate { get; set; }
        public DateTime MembershipExpiryDate { get; set; }
        public bool IsBlocked {  get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
