namespace Wareh.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Item");
        }
    }
}