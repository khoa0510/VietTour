using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VietTour.Data;
using VietTour.Models;

namespace VietTour.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly TourData _tourData;

		public HomeController(ILogger<HomeController> logger, TourData tourData)
		{
			_logger = logger;
		}

		[Route("")]
		public IActionResult Index()
		{
			return View();
		}

		[Route("about")]
		public IActionResult AboutUs()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}