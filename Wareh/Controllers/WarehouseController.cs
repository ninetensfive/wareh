using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wareh.Models;

namespace Wareh.Controllers
{
    public class WarehouseController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var warehouses = db.Warehouses.ToList();

                return View(warehouses);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Warehouses.Add(warehouse);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(warehouse);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var warehouse = db.Warehouses.Find(id);

                if (warehouse == null)
                {
                    RedirectToAction("Index");
                }


                return View(warehouse);
            }
        }

        [HttpPost]
        public ActionResult Edit(Supplier model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var warehouse = db.Warehouses.Find(model.Id);

                    if (warehouse == null)
                    {
                        RedirectToAction("Index");
                    }

                    warehouse.Name = model.Name;
                    warehouse.Address = model.Address;
                    warehouse.City = model.City;
                    warehouse.Country = model.Country;


                    db.SaveChanges();

                    return RedirectToAction("Details", new { id = model.Id });
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var warehouse = db.Warehouses.Find(id);

                if (warehouse == null)
                {
                    RedirectToAction("Index");
                }

                return View(warehouse);
            }
        }

    }
}