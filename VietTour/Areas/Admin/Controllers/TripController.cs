using Microsoft.AspNetCore.Mvc;

namespace VietTour.Areas.Admin.Controllers
{
	public class TripController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
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
		public ActionResult Create(IFormCollection collection)
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

		[HttpGet]
		public ActionResult Edit(int tour_id, int trip_id)
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int tour_id, int trip_id, IFormCollection collection)
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
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int tour_id, int trip_id)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
