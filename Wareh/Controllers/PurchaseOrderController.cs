namespace Wareh.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Models;
    using ViewModels;

    public class PurchaseOrderController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var purchaseOrders = db.PurchaseOrders
                    .Include(s => s.Supplier)
                    .Include(p => p.Product)
                    .ToList();

                return View(purchaseOrders);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create(int? productId)
        {
            if (productId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var db = new ApplicationDbContext())
            {
                var product = db.Products.Find(productId);

                if (product == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                var suppliers = product.Suppliers.ToList();

                var viewModel = new PurchaseOrderViewModel();
                viewModel.PurchaseOrder = new PurchaseOrder();
                viewModel.PurchaseOrder.ProductId = (int)productId;
                viewModel.PurchaseOrder.Product = product;
                viewModel.Suppliers = suppliers;

                return View(viewModel);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(int? productId, PurchaseOrderViewModel model)
        {
            if (productId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            model.PurchaseOrder.ProductId = (int)productId;

            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    db.PurchaseOrders.Add(model.PurchaseOrder);
                    db.SaveChanges();

                    return RedirectToAction("Details");
                }
            }

            return RedirectToAction("Home", "Index");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var purchaseOrder = db.PurchaseOrders.Find(id);

                if (purchaseOrder == null)
                {
                    RedirectToAction("Index");
                }

                var product = db.Products.Find(purchaseOrder.ProductId);
                purchaseOrder.Product = product;

                var viewModel = new PurchaseOrderViewModel();

                viewModel.PurchaseOrder = purchaseOrder;
                viewModel.Suppliers = purchaseOrder.Product.Suppliers.ToList();

                return View(viewModel);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int? id, PurchaseOrderViewModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                var purchaseOrder = db.PurchaseOrders.Find(id);

                if (purchaseOrder == null)
                {
                    RedirectToAction("Index");
                }

                var product = db.Products.Find(purchaseOrder.ProductId);
                purchaseOrder.Product = product;
                purchaseOrder.MeasureUnit = model.PurchaseOrder.MeasureUnit;
                purchaseOrder.Quantity = model.PurchaseOrder.Quantity;
                purchaseOrder.SupplierId = model.PurchaseOrder.SupplierId;

                if (ModelState.IsValid)
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                model = new PurchaseOrderViewModel
                {
                    PurchaseOrder = purchaseOrder,
                    Suppliers = purchaseOrder.Product.Suppliers.ToList()
                };
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var purchaseOrders = db.PurchaseOrders
                    .Include(s => s.Supplier)
                    .Include(p => p.Product)
                    .SingleOrDefault(p => p.Id == id);

                if (purchaseOrders == null)
                {
                    return RedirectToAction("Index");
                }

                return View(purchaseOrders);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Execute(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ApplicationDbContext())
            {
                var purchaseOrder = db.PurchaseOrders.Find(id);

                if (purchaseOrder == null)
                {
                    return RedirectToAction("Index");
                }

                db.SaveChanges();

                return RedirectToAction("Create", "Item", new { purchaseOrderId = id });
            }
        }
    }
}