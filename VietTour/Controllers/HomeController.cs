using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VietTour.Data.Repositories;
using VietTour.Models;
using VietTour.Models.DTOs;
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

		[Route("")]
		public IActionResult Index(int? page, string sortBy, string search)
		{
			int pageNumber = page ?? 1;
			int pageSize = 12;
			return View(_mainRepository.tourRepository.GetAll(pageNumber, pageSize, sortBy, search));
		}

		[Route("about")]
		//public IActionResult AboutUs()
		//{
		//	return View();
		//}
		public IActionResult About()
        {
            return View();
        }
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