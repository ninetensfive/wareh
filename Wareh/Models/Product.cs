namespace Wareh.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Suppliers = new List<Supplier>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Product")]
        public string Name { get; set; }

        [StringLength(255)]
        public string Barcode { get; set; }

        [Display(Name = "Manufacturer")]
        public int? ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }   

        public virtual List<Supplier> Suppliers { get; set; }
    }
}