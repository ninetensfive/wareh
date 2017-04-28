namespace Wareh.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
            this.CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Measure Unit")]
        public string MeasureUnit { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Created Date")]
        public DateTime? CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Executed Date")]
        public DateTime? ExecutedAt { get; set; }
    }
}