using System.ComponentModel.DataAnnotations;

namespace ST10291238_PROG7311_Part2.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // Farmer or Employee
    }
}
