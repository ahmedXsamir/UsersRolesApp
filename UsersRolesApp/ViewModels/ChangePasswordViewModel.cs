using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UsersApp.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 6 characters long.")]
        [MaxLength(50, ErrorMessage = "Password cannot exceed 50 characters.")]
        [DisplayName("New Password")]
        [Compare("ConfirmNewPassword", ErrorMessage = "Passwords do not match.")]
        public string NewPassword { get; set; } = null!;

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm New Password")]
        public string ConfirmNewPassword { get; set; } = null!;
    }
}
