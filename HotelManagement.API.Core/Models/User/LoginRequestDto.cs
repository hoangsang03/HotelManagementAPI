using System.ComponentModel.DataAnnotations;

namespace HotelManagementAPI.Models.User
{

    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited from {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
