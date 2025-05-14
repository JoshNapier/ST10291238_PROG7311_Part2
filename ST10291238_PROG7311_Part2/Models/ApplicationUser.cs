using Microsoft.AspNetCore.Identity;

namespace ST10291238_PROG7311_Part2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; } // Role of the user (e.g., Farmer, Employee)
    }
}
