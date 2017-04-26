﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wareh.Models;

namespace Wareh.Controllers
{
    public class SupplierController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var suppliers = db.Suppliers.ToList();

                return View(suppliers);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
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