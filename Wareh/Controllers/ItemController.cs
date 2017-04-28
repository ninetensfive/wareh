using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wareh.Models;
using Wareh.ViewModels;
using System.Data.Entity;

namespace Wareh.Controllers
{
    public class ItemController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var items = db.Items
                    .Include(p => p.PurchaseOrder)
                    .Include(w => w.Warehouse)
                    .Include(pr => pr.PurchaseOrder.Product)
                    .Include(s => s.PurchaseOrder.Supplier)
                    .ToList();
                return View(items);
            }

        }

        [HttpGet]
        public ActionResult Create(int? purchaseOrderId)
        {
            if (purchaseOrderId == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ApplicationDbContext())
            {
                var purchaseOrder = db.PurchaseOrders.Find(purchaseOrderId);

                if (purchaseOrder == null)
                {
                    return RedirectToAction("Index");
                }

                var existingItem = db.Items.SingleOrDefault(i => i.PurchaseOrderId == purchaseOrderId);

                if ( existingItem != null)
                {
                    return RedirectToAction("Edit", new { id = existingItem.Id });
                }

                purchaseOrder.Product = db.Products.Find(purchaseOrder.ProductId);
                purchaseOrder.Supplier = db.Suppliers.Find(purchaseOrder.SupplierId);

                var viewModel = new ItemViewModel();
                viewModel.PurchaseOrder = purchaseOrder;

                var warehouses = db.Warehouses.ToList();
                viewModel.Warehouses = warehouses;

                return View(viewModel);

            }

        }

        [HttpPost]
        public ActionResult Create(int? purchaseOrderId, ItemViewModel model)
        {
            if (purchaseOrderId == null || model == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ApplicationDbContext())
            {
                var existingItem = db.Items.SingleOrDefault(i => i.PurchaseOrderId == purchaseOrderId);

                if (existingItem != null)
                {
                    return RedirectToAction("Edit", new { id = existingItem.Id });
                }

                var item = new Item();
                item.WarehouseId = model.Item.WarehouseId;
                item.Location = model.Item.Location;
                item.PurchaseOrderId = (int)purchaseOrderId;
             
                db.Items.Add(item);
                db.SaveChanges();

                var purchaseOrder = db.PurchaseOrders.Find(purchaseOrderId);
                purchaseOrder.ExecutedAt = DateTime.Now;

                db.SaveChanges();

                return RedirectToAction("Details", new { id = item.Id });

            }
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ApplicationDbContext())
            {
                var item = db.Items
                    .Include(p => p.PurchaseOrder)
                    .Include(pr => pr.PurchaseOrder.Product)
                    .Include(s => s.PurchaseOrder.Supplier)
                    .Include(w => w.Warehouse)
                    .SingleOrDefault(i => i.Id == id);


                
                if (item == null)
                {
                    RedirectToAction("Index");
                }

                var viewModel = new ItemViewModel();
                viewModel.Item = item;
                viewModel.Warehouses = db.Warehouses.ToList(); 

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(int? id, ItemViewModel model)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ApplicationDbContext())
            {
                var item = db.Items
                    .Include(p => p.PurchaseOrder)
                    .Include(pr => pr.PurchaseOrder.Product)
                    .Include(s => s.PurchaseOrder.Supplier)
                    .Include(w => w.Warehouse)
                    .SingleOrDefault(i => i.Id == id);



                if (item == null)
                {
                    RedirectToAction("Index");
                }

                if (ModelState.IsValid)
                {
                    item.WarehouseId = model.Item.WarehouseId;
                    item.Location = model.Item.Location;

                    db.Items.Add(item);
                    db.SaveChanges();

                    var purchaseOrder = db.PurchaseOrders.Find(db.Items.Find(item.Id).PurchaseOrderId);
                    purchaseOrder.ExecutedAt = DateTime.Now;

                    db.SaveChanges();

                    return RedirectToAction("Details", new { id = item.Id});
                }

                var viewModel = new ItemViewModel();
                viewModel.Item = item;
                viewModel.Warehouses = db.Warehouses.ToList();

                return View(viewModel);
            }
        }

        public ActionResult Details(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                var item = db.Items
                    .Find(id);

                if (item == null)
                {
                    RedirectToAction("Index");
                }

                var viewModel = new ItemViewModel();
                item.Warehouse = db.Warehouses.Find(item.WarehouseId);
                viewModel.Item = item;
                viewModel.PurchaseOrder = db.PurchaseOrders.Find(item.PurchaseOrderId);
                viewModel.PurchaseOrder.Product = db.Products.Find(viewModel.PurchaseOrder.ProductId);



                return View(viewModel);
            }
        }
    }
}