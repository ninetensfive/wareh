namespace Wareh.Controllers.Api
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Wareh.Models;

    public class SupplierController : ApiController
    {
        [HttpDelete]
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var supplier = db.Suppliers.SingleOrDefault(m => m.Id == id);

                if (supplier == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                db.Suppliers.Remove(supplier);
                db.SaveChanges();
            }
        }
    }
}
