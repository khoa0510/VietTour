using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VietTour.Areas.Admin.Models;
using VietTour.Areas.Public.Models;
using VietTour.Data.Entities;
using VietTour.Data.Repositories;

namespace VietTour.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TourController : Controller
    {
        private readonly MainRepository _mainRepository;
        private readonly List<string?> _provinceList;

        public TourController(MainRepository mainRepository)
        {
            _mainRepository = mainRepository;
            _provinceList = _mainRepository.TourRepository.GetProvinceList();
        }

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
            ViewBag.ProvinceList = _provinceList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTourViewModel createTourViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createTourViewModel);
            }

            if (_mainRepository.TourRepository.CreateTour(createTourViewModel))
            {
                TempData["Status"] = "Tạo Tour thành công";
            }
            else
            {
                TempData["Status"] = "Tạo Tour thất bại";
            }
            return RedirectToAction("Index", "Home");
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
