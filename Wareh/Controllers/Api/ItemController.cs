using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wareh.Models;

namespace Wareh.Controllers.Api
{
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
