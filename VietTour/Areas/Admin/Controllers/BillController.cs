using Microsoft.AspNetCore.Mvc;

namespace VietTour.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BillController : Controller
	{
		//List all payment, can sort
		[HttpGet]
		public ActionResult Index(/*search*/string customer_name,/*filter*/ int startDate, int endDate)
		{
			return View();
		}

		/*// GET: bills/tour/5
		[HttpGet("/tour/{id?}")]
		public ActionResult GetBillGroupByTours(int? id)
		{
			return View();
		}

		// GET: bills/month/5
		[HttpGet("/month/{id?}")]
		public ActionResult GetBillGroupByMonth(int? id)
		{
			return View();
		}

		// GET: bills/trip/5
		[HttpGet("/trip/{id?}")]
		public ActionResult GetBillGroupByTrip(int? id)
		{
			return View();
		}*/
	}
}
