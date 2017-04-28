namespace Wareh.Controllers.Api
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Models;

    public class ManufacturerController : ApiController
    {
        [HttpDelete]
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var manufacturer = db.Manufacturers.SingleOrDefault(m => m.Id == id);

                if (manufacturer == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                db.Manufacturers.Remove(manufacturer);
                db.SaveChanges();
            }
        }
    }
}
