using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wareh.Models
{
    public class Item
    {
        public Item()
        {
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        [Required]
        [StringLength(255)]
        public string Location { get; set; }

        [Required]
        public int PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Created Date")]
        public DateTime? CreatedAt { get; set; }

    }
}