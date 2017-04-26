﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wareh.Models
{
    public class Supplier
    {
        public Supplier()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [StringLength(255)]
        public string Country { get; set; }

        public string HomePage { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}