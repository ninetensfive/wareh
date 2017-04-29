namespace Wareh.Controllers.Api
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Wareh.Models;

    public class WarehouseController : ApiController
    {
        [HttpDelete]
        [Authorize]
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var warehouse = db.Warehouses.SingleOrDefault(m => m.Id == id);

                if (warehouse == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                db.Warehouses.Remove(warehouse);
                db.SaveChanges();
            }
        }
    }
}
