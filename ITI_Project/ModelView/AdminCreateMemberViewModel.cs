using System.ComponentModel.DataAnnotations;
using ITI_Project.Model;

namespace ITI_Project.ModelView
{
    public class AdminCreateMemberViewModel
    {
        [Required(ErrorMessage = "Username must be at least 3 characters.")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters.")]
        public string UserName { get; set; } = "";

        [Required(ErrorMessage = "Please enter a valid email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = "";

        [Required(ErrorMessage = "Password must be at least 6 characters.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; } = "";

        [Required]
        public Role Role { get; set; } = Role.Member;
    }
}