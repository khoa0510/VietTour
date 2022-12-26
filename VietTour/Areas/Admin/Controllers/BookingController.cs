using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using VietTour.Areas.Admin.Models;
using VietTour.Data.Repositories;

namespace VietTour.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Policy = "Employee")]
    public class BookingController : Controller
	{
        private readonly MainRepository _mainRepository;
		private readonly List<string> _payList;

        public BookingController(MainRepository mainRepository)
        {
            _mainRepository = mainRepository;
			_payList = new List<string>()
			{
				"Chưa thanh toán",
				"Đã thanh toán"
			};
        }

        [HttpGet]
		public ActionResult Index(int? page, string sortBy, string search)
		{
            int pageNumber = page ?? 1;
			int pageSize = 12;
			BookingViewModel bookingList = new()
			{
				BookingList = _mainRepository.BookingRepository.GetAll(pageNumber, pageSize, sortBy, search)
			};
			return View(bookingList);
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			EditBookingViewModel editBookingViewModel = _mainRepository.BookingRepository.GetBooking(id);
			ViewBag.TripList = _mainRepository.TripRepository.ListTripTimeByTour(editBookingViewModel.TourId);
			ViewBag.PayList = _payList;
            return View(editBookingViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, EditBookingViewModel editBookingViewModel)
		{
				_mainRepository.BookingRepository.EditBooking(id, editBookingViewModel);
				return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			_mainRepository.BookingRepository.DeleteBooking(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
