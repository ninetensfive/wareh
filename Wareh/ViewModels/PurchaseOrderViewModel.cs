using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wareh.Models;

namespace Wareh.ViewModels
{
    public class PurchaseOrderViewModel
    {
        public PurchaseOrder PurchaseOrder { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }
    }
}