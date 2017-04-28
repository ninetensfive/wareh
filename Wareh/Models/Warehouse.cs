namespace Wareh.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Warehouse
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Warehouse")]
        public string Name { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [StringLength(255)]
        public string Country { get; set; }
    }
}