namespace Wareh.Models
{
    public class SupplierProduct
    {
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}