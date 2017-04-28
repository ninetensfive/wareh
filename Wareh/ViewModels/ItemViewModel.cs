using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wareh.Models;

namespace Wareh.ViewModels
{
    public class ItemViewModel
    {
        public Item Item { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }

        public IEnumerable<Warehouse> Warehouses { get; set; }
    }
}