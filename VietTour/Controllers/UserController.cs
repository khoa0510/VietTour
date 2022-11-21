using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VietTour.Data.Repositories;
using VietTour.Models.Entities;
using VietTour.Models.DTOs;

namespace VietTour.Controllers
{
	public class UserController : Controller
	{
		private readonly MainRepository _mainRepository;
		private readonly IMapper _mapper;

		public UserController(MainRepository mainRepository, IMapper mapper)
		{
			_mainRepository = mainRepository;
			_mapper = mapper;
		}

		// GET: signup
		[HttpGet("signup", Name = "user/signup")]
		public ActionResult SignUp()
		{
			return View();
		}

		// POST: users/signup
		[HttpPost("users/signup")]
		[ValidateAntiForgeryToken]
		public ActionResult SignUp(IFormCollection collection) ///////////////////// Change IFormCollection to ViewModel
		{
			var user = _mapper.Map<User>(collection);
			bool err = !_mainRepository.userRepository.SignUp(user);
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


		// GET: login
		[HttpGet("login", Name = "user/login")]

        public ActionResult LogIn()
		{

			return View();
		}



		// POST: users/login
		[HttpPost("users/login")]
		[ValidateAntiForgeryToken]
		public ActionResult LogIn(IFormCollection collection) ///////////////////// Change IFormCollection to ViewModel
		{
			var user = _mapper.Map<User>(collection);
			bool err = !_mainRepository.userRepository.VerifyPassword(user);
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
        // GET: forgotpassword
        [HttpGet("forgotpassword", Name = "user/forgotpassword")]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: users/forgotpassword
        [HttpPost("users/forgotpassword")]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(IFormCollection collection)
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



        // GET: users //GetAllUser
        [HttpGet("users", Name = "user")]
		public ActionResult Index()
		{
			return View();
		}

		// GET: users/5
		[HttpGet("users/{id}", Name = "user/detail")]
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: users/5/edit
		[HttpGet("users/{id}/edit", Name = "user/edit")]
		public ActionResult Edit(int id)
		{
			return View();
		}

		// PUT: users/5
		[HttpPut("users/{id}")]
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

		// Delete: users/5
		[HttpDelete("users/{id}")]
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
