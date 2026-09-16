using System.ComponentModel.DataAnnotations;

namespace ITI_Project.ModelView
{
    public class EditProfileViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = "";
    }
}