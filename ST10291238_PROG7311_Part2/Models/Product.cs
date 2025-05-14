using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST10291238_PROG7311_Part2.Models
{
    public class Product
    {
        [Key]
        public int Productid { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        [ForeignKey("Farmer")]
        public int FarmerId { get; set; }
        public virtual Farmer Farmer { get; set; }
    }
}
