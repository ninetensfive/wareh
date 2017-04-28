namespace Wareh.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Models;
    using ViewModels;

    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var products = db.Products.Include(m => m.Manufacturer).Include(s => s.Suppliers).ToList();

                return View(products);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (var db = new ApplicationDbContext())
            {
                var manufacturers = db.Manufacturers.ToList();
                var suppliers = db.Suppliers.ToList();

                var viewModel = new ProductViewModel
                {
                    Manufacturers = manufacturers,
                    Suppliers = suppliers
                };

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel, int[] selectedSuppliers)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    //var suppliers = new HashSet<Supplier>();

                    var suppliers = db.Suppliers.Where(s => selectedSuppliers.Contains(s.Id)).ToList();

                    var product = new Product
                    {
                        Name = productViewModel.Product.Name,
                        Barcode = productViewModel.Product.Barcode,
                        ManufacturerId = productViewModel.Product.ManufacturerId,
                        Suppliers = suppliers,
                    };

                    db.Products.Add(product);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            using (var db = new ApplicationDbContext())
            {
                var manufacturers = db.Manufacturers.ToList();
                var suppliers = db.Suppliers.ToList();

                var viewModel = new ProductViewModel
                {
                    Manufacturers = manufacturers,
                    Suppliers = suppliers,
                    Product = productViewModel.Product
                };

                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var product = db.Products.Find(id);

                if (product == null)
                {
                    RedirectToAction("Index");
                }

                var manufacturers = db.Manufacturers.ToList();
                var suppliers = db.Suppliers.ToList();

                var viewModel = new ProductViewModel();
                viewModel.Product = product;
                viewModel.Manufacturers = manufacturers;
                viewModel.Suppliers = suppliers;
                viewModel.SelectedSuppliers = product.Suppliers.Select(s => s.Id).ToList();

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel, int[] selectedSuppliers)
        {
            int? id = int.Parse(RouteData.Values["Id"].ToString());

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ApplicationDbContext())
            {
                var suppliers = db.Suppliers.Where(s => selectedSuppliers.Contains(s.Id)).ToList();

                var product = db.Products.Find(id);

                for (var i = 0; i < product.Suppliers.Count; i++)
                {
                    product.Suppliers.Remove(product.Suppliers[i]);
                }

                product.Name = productViewModel.Product.Name;
                product.Barcode = productViewModel.Product.Barcode;
                product.ManufacturerId = productViewModel.Product.ManufacturerId;
                product.Suppliers = suppliers;

                if (ModelState.IsValid)
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                var manufacturers = db.Manufacturers.ToList();

                suppliers = db.Suppliers.ToList();

                productViewModel.Manufacturers = manufacturers;
                productViewModel.Suppliers = suppliers;
            }

            return View(productViewModel);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var product = db.Products.Include(m => m.Manufacturer)
                    .Include(s => s.Suppliers)
                    .SingleOrDefault(p => p.Id == id);

                if (product == null)
                {
                    RedirectToAction("Index");
                }

                return View(product);
            }
        }
    }
}