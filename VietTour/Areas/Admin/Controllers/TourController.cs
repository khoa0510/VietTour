using Microsoft.AspNetCore.Mvc;

namespace VietTour.Areas.Admin.Controllers
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
