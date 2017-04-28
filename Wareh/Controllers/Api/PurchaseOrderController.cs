namespace Wareh.Controllers.Api
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Models;

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
