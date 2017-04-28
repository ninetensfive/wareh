namespace Wareh.ViewModels
{
    using System.Collections.Generic;
    using Models;

    public class PurchaseOrderViewModel
    {
        public PurchaseOrder PurchaseOrder { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }
    }
}