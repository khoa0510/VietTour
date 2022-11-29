using Microsoft.AspNetCore.Mvc;

namespace VietTour.Areas.Public.Controllers
{
    public class TourController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
