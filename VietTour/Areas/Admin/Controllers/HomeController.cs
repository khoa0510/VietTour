using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VietTour.Data.Repositories;
using VietTour.Areas.Admin.Models;

namespace VietTour.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly MainRepository _mainRepository;
		public readonly IMapper _mapper;

		public HomeController(MainRepository mainRepository, IMapper mapper)
		{
			_mainRepository = mainRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult Index(int? page, string sortBy, string search)
		{
			int pageNumber = page ?? 1;
			int pageSize = 12;
			var tourList = _mainRepository.TourRepository.GetAll(pageNumber, pageSize, sortBy, search);
            return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}