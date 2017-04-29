namespace Wareh.Controllers.Api
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Models;

    public class ProductController : ApiController
    {
        [HttpDelete]
        [Authorize]
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var product = db.Products.SingleOrDefault(m => m.Id == id);

                if (product == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
