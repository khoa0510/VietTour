using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VietTour.Data.Repositories;
using VietTour.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace VietTour.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Policy = "Employee")]
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
            TourViewModel tourViewModel = new()
            {
                tourList = _mainRepository.TourRepository.GetAll(pageNumber, pageSize, sortBy, search)
            };
            return View(tourViewModel);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}