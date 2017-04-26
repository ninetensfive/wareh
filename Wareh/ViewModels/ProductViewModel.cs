using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wareh.Models;

namespace Wareh.ViewModels
{
    public class ProductViewModel
    {
        //public ProductViewModel()
        //{
        //    this.Suppliers = new HashSet<Supplier>();
        //    this.Manufacturers = new HashSet<Manufacturer>();
        //}
        public Product Product { get; set; }

        public IEnumerable<Manufacturer> Manufacturers { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }

        public List<int> SelectedSuppliers { get; set; }

    }
}