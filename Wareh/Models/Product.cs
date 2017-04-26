using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wareh.Models
{
    public class Product
    {
        public Product()
        {
            this.Suppliers = new HashSet<Supplier>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Barcode { get; set; }

        [Display(Name = "Manufacturer")]
        public int? ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }   

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}