using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VietTour.Areas.Admin.Models;
using VietTour.Data.Repositories;

namespace VietTour.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Policy = "Employee")]
    public class TripController : Controller
	{
        private readonly MainRepository _mainRepository;

        public TripController(MainRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        [HttpGet]
		public ActionResult Index(int? page, string sortBy, string search)
		{
            int pageNumber = page ?? 1;
            int pageSize = 12;
			TripViewModel tripViewModel = new()
			{
				tripList = _mainRepository.TripRepository.GetAll(pageNumber, pageSize, sortBy, search)
			};
            return View(tripViewModel);
		}

		//Get trips by tour
		[HttpGet]
		public ActionResult TripsByTour(int tour_id)
		{
			return View();
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CreateTripViewModel createTripViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(createTripViewModel);
			}
			else
			{
				_mainRepository.TripRepository.Create(createTripViewModel);
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var editTripViewModel = _mainRepository.TripRepository.GetOne(id);
			return View(editTripViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, EditTripViewModel editTripViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(editTripViewModel);
			}
			else
			{
				_mainRepository.TripRepository.Edit(id, editTripViewModel);
				return RedirectToAction(nameof(Index));
			}
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			_mainRepository.TripRepository.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
