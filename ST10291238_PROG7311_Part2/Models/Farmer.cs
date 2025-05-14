using System.ComponentModel.DataAnnotations;

namespace ST10291238_PROG7311_Part2.Models
{
    public class Farmer
    {
        [Key]
        public int FarmerId { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
