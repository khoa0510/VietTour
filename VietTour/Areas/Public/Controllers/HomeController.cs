using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VietTour.Data.Repositories;
using VietTour.Areas.Public.Models;

namespace VietTour.Areas.Public.Controllers
{
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
			var tourList = _mainRepository.tourRepository.GetAll(pageNumber, pageSize, sortBy, search);
            return View();
		}

        [HttpGet]
        public IActionResult About()
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