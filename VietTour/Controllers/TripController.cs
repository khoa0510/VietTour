using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VietTour.Controllers
{
	public class TripController : Controller
	{
		// GET: trips //Get all trips
		[HttpGet("trips")]
		public ActionResult Index()
		{
			return View();
		}

		// GET: tour/5/trips //Get trips by tour
		[HttpGet("tours/{tour_id}/trips")]
		public ActionResult TripsByTour(int tour_id)
		{
			return View();
		}

		// GET: tours/5/trips/create
		[HttpGet("tours/{tour_id}/trips/create")]
		public ActionResult Create()
		{
			return View();
		}

		// POST: tours/5/trips
		[HttpPost("tours/{tour_id}/trips")]
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

		// GET: tours/5/trips/10/edit
		[HttpGet("tours/{tour_id}/trips/{trip_id}/edit")]
		public ActionResult Edit(int tour_id, int trip_id)
		{
			return View();
		}

		// PUT: tours/5/trips/10
		[HttpPut("tours/{tour_id}/trips/{trip_id}")]
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

		// DELETE: tours/5/trips/10
		[HttpDelete("tours/{tour_id}/trips/{trip_id}")]
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
