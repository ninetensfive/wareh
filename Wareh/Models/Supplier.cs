﻿namespace Wareh.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Supplier
    {
        public Supplier()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Supplier")]
        public string Name { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [StringLength(255)]
        public string Country { get; set; }

        [Display(Name = "Home Page")]
        public string HomePage { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}