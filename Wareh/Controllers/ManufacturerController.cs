using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wareh.Models;

namespace Wareh.Controllers
{
    public class ManufacturerController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var manufacturers = db.Manufacturers.ToList();

                return View(manufacturers);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Manufacturers.Add(manufacturer);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(manufacturer);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var manufacturer = db.Manufacturers.Find(id);

                if (manufacturer == null)
                {
                    RedirectToAction("Index");
                }


                return View(manufacturer);
            }
        }

        [HttpPost]
        public ActionResult Edit(Manufacturer model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var manufacturer = db.Manufacturers.Find(model.Id);

                    if (manufacturer == null)
                    {
                        RedirectToAction("Index");
                    }

                    manufacturer.Name = model.Name;
                    manufacturer.Address = model.Address;
                    manufacturer.City = model.City;
                    manufacturer.Country = model.Country;
                    manufacturer.HomePage = model.HomePage;

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
                var manufacturer = db.Manufacturers.Find(id);

                if (manufacturer == null)
                {
                    RedirectToAction("Index");
                }

                return View(manufacturer);
            }
        }
    }
}