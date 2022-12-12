using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VietTour.Data.Entities;
using VietTour.Data.Repositories;
using VietTour.Areas.Public.Models;

namespace VietTour.Areas.Public.Controllers
{
    [Area("Public")]
    public class UserController : Controller
    {
        private readonly MainRepository _mainRepository;
        private readonly IMapper _mapper;

        public UserController(MainRepository mainRepository, IMapper mapper)
        {
            _mainRepository = mainRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
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

        [HttpGet]
        public ActionResult LogIn()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(IFormCollection form) ///////////////////// Change IFormCollection to ViewModel
        {
            /*var user = _mapper.Map<User>(collection);
			int userId = _mainRepository.userRepository.VerifyPassword(user);
			if (userId == 0)
			{
				return View(collection);
			}
			else*/
            Console.WriteLine("alllllllllllllllllllo");

            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid,"12323"),
                    new Claim(ClaimTypes.Name, "alo"),
                    new Claim(ClaimTypes.Role, "Admin"),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                var authProperties = new AuthenticationProperties { };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);
                return RedirectToAction("Index", "Home");

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
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

        [HttpGet]
        public ActionResult Details()
        {
            int id = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value ?? "0");
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            int id = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value ?? "0");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            int id = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value ?? "0");
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
    }
}
