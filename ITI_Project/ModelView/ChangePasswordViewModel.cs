using System.ComponentModel.DataAnnotations;

namespace ITI_Project.ModelView
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Please enter your current password.")]
        public string CurrentPassword { get; set; } = "";

        [Required(ErrorMessage = "Please enter a new password.")]
        [MinLength(6, ErrorMessage = "New password must be at least 6 characters.")]
        public string NewPassword { get; set; } = "";


        [Required(ErrorMessage = "Please confirm your new password.")]
        [Compare(nameof(NewPassword), ErrorMessage = "New password and confirmation do not match.")]
        public string ConfirmPassword { get; set; } = "";

    }
}