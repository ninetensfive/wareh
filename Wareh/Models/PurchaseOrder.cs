using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wareh.Models
{
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Required]
        [StringLength(255)]
        public string MeasureUnit { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExecutedAt { get; set; }



    }
}