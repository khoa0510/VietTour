using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VietTour.Data.Repositories;
using VietTour.Models;
using VietTour.Models.Entities;

namespace VietTour.Controllers
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

        [HttpGet("index", Name = "home/index")]
        [Route("")]
		public IActionResult Index(int? page, string sortBy, string search)
		{
			int pageNumber = page ?? 1;
			int pageSize = 12;
			return View(_mainRepository.tourRepository.GetAll(pageNumber, pageSize, sortBy, search));
		}

        //GET : About
        [HttpGet("about", Name = "home/about")]
        [Route("about")]
		public IActionResult About()
        {
            return View();
        }

		// GET : Tour
        [HttpGet("tour", Name = "home/tour")]
        public IActionResult Tour()
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