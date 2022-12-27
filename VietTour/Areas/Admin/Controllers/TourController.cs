using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VietTour.Areas.Admin.Models;
using VietTour.Data.Repositories;

namespace VietTour.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Employee")]
    public class TourController : Controller
    {
        private readonly MainRepository _mainRepository;
        private readonly List<string?> _provinceList;

        public TourController(MainRepository mainRepository, IMapper mapper)
        {
            _mainRepository = mainRepository;
            _provinceList = _mainRepository.TourRepository.GetProvinceList();
        }

        [HttpGet]
        public ActionResult Index(int? page, string sortBy, string search)
        {
            int pageNumber = page ?? 1;
            int pageSize = 12;
            TourViewModel tourViewModel = new()
            {
                tourList = _mainRepository.TourRepository.GetAll(pageNumber, pageSize, sortBy, search)
            };
            return View(tourViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ProvinceList = _provinceList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]CreateTourViewModel createTourViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProvinceList = _provinceList;
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
            ViewBag.ProvinceList = _provinceList;
            EditTourViewModel tour = _mainRepository.TourRepository.GetTour(id);
            return View(tour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditTourViewModel editTourViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProvinceList = _provinceList;
                return View(editTourViewModel);
            }
            else
            {
                _mainRepository.TourRepository.EditTour(id, editTourViewModel);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _mainRepository.TourRepository.DeleteTour(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
