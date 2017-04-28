namespace Wareh.ViewModels
{
    using System.Collections.Generic;
    using Models;

    public class ItemViewModel
    {
        public Item Item { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }

        public IEnumerable<Warehouse> Warehouses { get; set; }
    }
}