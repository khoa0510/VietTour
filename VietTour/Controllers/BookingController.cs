using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VietTour.Controllers
{
	[Route("bookings")]
	public class BookingController : Controller
	{
		// GET: bookings
		[HttpGet("", Name = "booking")]
		public ActionResult Index()
		{
			return View();
		}

		// GET: bookings/5
		[HttpGet("{id}", Name = "booking/detail")]
		public ActionResult Details(int id)
		{
			return View();
		}

        // GET: bookings/create
        [HttpGet("create", Name = "booking/create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: bookings
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

		// GET: bookings/5/edit
		[HttpGet("{id}/edit", Name = "booking/edit")]
		public ActionResult Edit(int id)
		{
			return View();
		}

		// PUT: bookings/5
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

		// DELETE: BookingController/Delete/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return View();
		}
	}
}
