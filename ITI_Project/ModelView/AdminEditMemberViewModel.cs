using System.ComponentModel.DataAnnotations;
using ITI_Project.Model;

namespace ITI_Project.ModelView
{
    public class AdminEditMemberViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username must be at least 3 characters.")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters.")]
        public string UserName { get; set; } = "";

        [Required(ErrorMessage = "Please enter a valid email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = "";

        // Optional: leave blank to keep the member's current password unchanged.
        // Intentionally never pre-filled with the existing password - the admin
        // can only set a brand new one, not see the current one.
        public string? NewPassword { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}