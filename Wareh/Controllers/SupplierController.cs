namespace Wareh.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    public class SupplierController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var suppliers = db.Suppliers.ToList();

                return View(suppliers);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Suppliers.Add(supplier);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(supplier);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var supplier = db.Suppliers.Find(id);

                if (supplier == null)
                {
                    RedirectToAction("Index");
                }

                return View(supplier);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Supplier model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var supplier = db.Suppliers.Find(model.Id);

                    if (supplier == null)
                    {
                        RedirectToAction("Index");
                    }

                    supplier.Name = model.Name;
                    supplier.Address = model.Address;
                    supplier.City = model.City;
                    supplier.Country = model.Country;
                    supplier.HomePage = model.HomePage;
                   
                    db.SaveChanges();

                    return RedirectToAction("Details", new { id = model.Id });
                }
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var supplier = db.Suppliers.Find(id);

                if (supplier == null)
                {
                    RedirectToAction("Index");
                }

                return View(supplier);
            }
        }
    }
}