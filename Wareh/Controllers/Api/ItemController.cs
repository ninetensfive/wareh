namespace Wareh.Controllers.Api
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Models;

    public class ItemController : ApiController
    {
        [HttpDelete]
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var item = db.Items.SingleOrDefault(i => i.Id == id);

                if (item == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                db.Items.Remove(item);
                db.SaveChanges();
            }
        }
    }
}
