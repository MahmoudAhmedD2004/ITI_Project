using ITI_Project.Model;
using System.ComponentModel.DataAnnotations;

namespace ITI_Project.ModelView
{
    public class SignUpViewModel
    {
        [Required]
        public string UserName { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string PhoneNumber { get; set; } = "";
        [Required]
        public string PasswordHash { get; set; } = "";
        
    }
}
