using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wareh.Models;

namespace Wareh.Controllers.Api
{
    public class WarehouseController : ApiController
    {
        [HttpDelete]
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
