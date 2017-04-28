namespace Wareh.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Item
    {
        public Item()
        {
            this.CreatedAt = DateTime.Now;
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