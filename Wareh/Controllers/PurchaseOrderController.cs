using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wareh.Models;
using Wareh.ViewModels;

namespace Wareh.Controllers
{
    public class PurchaseOrderController : Controller
    {
        [HttpGet]
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
        public ActionResult Create(int? productId, PurchaseOrderViewModel model)
        {
            if (productId == null)
            {
                return RedirectToAction("Index", "Home");            
            }

            model.PurchaseOrder.ProductId = (int)productId;

            if(ModelState.IsValid)
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
    }
}