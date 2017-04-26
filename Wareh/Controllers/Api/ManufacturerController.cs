using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wareh.Models;

namespace Wareh.Controllers.Api
{
    public class ManufacturerController : ApiController
    {
        [HttpDelete]
        public void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var manufacturer = db.Manufacturers.SingleOrDefault(m => m.Id == id);

                if(manufacturer == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                db.Manufacturers.Remove(manufacturer);
                db.SaveChanges();

            }
        }
    }
}
