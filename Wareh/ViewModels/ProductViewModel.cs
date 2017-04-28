namespace Wareh.ViewModels
{
    using System.Collections.Generic;
    using Models;

    public class ProductViewModel
    {   
        public Product Product { get; set; }

        public IEnumerable<Manufacturer> Manufacturers { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }

        public List<int> SelectedSuppliers { get; set; }
    }
}