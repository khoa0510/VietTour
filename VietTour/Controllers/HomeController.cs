using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VietTour.Data;
using VietTour.Data.Repositories;
using VietTour.Models;
using VietTour.Models.DTOs;

namespace VietTour.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly MainRepository _mainRepository;
		public readonly IMapper _mapper;

		public HomeController(ILogger<HomeController> logger, MainRepository mainRepository, IMapper mapper)
		{
			_logger = logger;
			_mainRepository = mainRepository;
			_mapper = mapper;
		}

		[Route("")]
		public IActionResult Index()
		{
			return View(_mainRepository.tourRepository.GetAll());
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