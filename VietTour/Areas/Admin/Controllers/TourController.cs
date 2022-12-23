using Microsoft.AspNetCore.Mvc;
using VietTour.Areas.Admin.Models;

namespace VietTour.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TourController : Controller
    {
        List<string> ProvinceList = new List<string>
        {
            "Ha Noi",
            "TP.HCM"
        };

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

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ProvinceList = ProvinceList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTourViewModel createTourViewModel)
        {
            bool err = false;
            //Thêm hàm check sau
            if (err)
            {
                return View(createTourViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            bool err = false;
            //Thêm hàm check sau
            if (err)
            {
                return View(collection);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            return View();
        }
    }
}
