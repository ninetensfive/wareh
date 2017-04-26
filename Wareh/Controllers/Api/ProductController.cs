using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wareh.Models;

namespace Wareh.Controllers.Api
{
    public class ProductController : ApiController
    {
        [HttpDelete]
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
