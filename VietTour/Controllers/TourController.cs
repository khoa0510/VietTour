using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VietTour.Controllers
{
	[Route("tours")]
	public class TourController : Controller
	{
		// GET: tours
		[HttpGet("")]
		public ActionResult Index()
		{
			return View();
		}

		// GET: tours/5
		[HttpGet("{id}")]
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: tours/create
		[HttpGet("create")]
		public ActionResult Create()
		{
			return View();
		}

		// POST: tours
		[HttpPost("")]
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

		// GET: tours/edit/5
		[HttpGet("edit/{id}")]
		public ActionResult Edit(int id)
		{
			return View();
		}

		// PUT: tours/5
		[HttpPut("{id}")]
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

		// DELETE: tours/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			return View();
		}
	}
}
