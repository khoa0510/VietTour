using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VietTour.Data.Repositories;
using VietTour.Areas.Admin.Models;

namespace VietTour.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly MainRepository _mainRepository;
		private readonly IMapper _mapper;

		public UserController(MainRepository mainRepository, IMapper mapper)
		{
			_mainRepository = mainRepository;
			_mapper = mapper;
		}

        //GetAllUser
        [HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Details(int id)
		{
			return View();
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			return View();
		}

		[HttpPost]
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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id)
		{
			bool err = false;
			//Thêm hàm check sau
			if (err)
			{
				return View();
			}
			else
			{
				return RedirectToAction(nameof(Index));
			}
		}
	}
}
