using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wareh.Models;

namespace Wareh.Controllers.Api
{
    public class PurchaseOrderController : ApiController
    {
        [HttpDelete]
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var purchaseOrder = db.PurchaseOrders.SingleOrDefault(m => m.Id == id);

                if (purchaseOrder == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                db.PurchaseOrders.Remove(purchaseOrder);
                db.SaveChanges();

            }
        }
    }
}
