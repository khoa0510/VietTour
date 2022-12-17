using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VietTour.Data.Entities;
using VietTour.Data.Repositories;
using VietTour.Areas.Public.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;

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
        public ActionResult SignUp(SignUpViewModel signUpViewModel)
        {
            var user = _mapper.Map<User>(signUpViewModel);
            bool err = !_mainRepository.UserRepository.SignUp(user);
            if (err)
            {
                TempData["Status"] = "Tài khoản đã tồn tại";
                return View(signUpViewModel);
            }
            else
            {
                TempData["Status"] = "Đăng ký";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult LogIn()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInViewModel logInViewModel)
        {
            var user = _mapper.Map<User>(logInViewModel);
			User checkedUser = _mainRepository.UserRepository.VerifyPassword(user);
			if (checkedUser == null)
			{
                TempData["Status"] = "Sai số điện thoại hoặc mật khẩu";
                return View(logInViewModel);
			}
			else
            {
                var claims = new List<Claim>()
                {
                    new Claim("ID", checkedUser.CookieId??""),
                    new Claim("Username", checkedUser.Username??""),
                    new Claim("Email", checkedUser.Username??""),
                };
                if (checkedUser.Admin == true) claims.Add(new Claim("Role", "Admin"));
                else claims.Add(new Claim("Role", "User"));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                var authProperties = new AuthenticationProperties { };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);
                TempData["Status"] = "Đăng nhập";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (true)
            {
                TempData["Status"] = "Đã gửi thành công email, vui lòng kiểm tra hộp thư";
                return View(forgotPasswordViewModel);
            }
            else
            {
                /*MailAddress to = new MailAddress(User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value ?? "0");
                MailAddress from = new MailAddress("viettour@gmail.com");
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Thay đổi mật khẩu tài khoản Viettour";
                message.Body = "Đường dẫn thay đổi mật khẩu: ";
                SmtpClient client = new SmtpClient("smtp.gmail.com", 2525)
                {
                    Credentials = new NetworkCredential("email_username", "email_password"),
                    EnableSsl = true
                };
                try
                {
                    client.Send(message);
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine(ex.ToString());
                }*/
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Details()
        {
            string? id = User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value;
            if (id == null)
                return RedirectToAction("Index", "Home");
            User? user = _mainRepository.UserRepository.GetUserDetail(id);
            if (user == null)
                return RedirectToAction("Index", "Home");
            var userDetailViewModel = _mapper.Map<UserDetailViewModel>(user);
            return View(userDetailViewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit()
        {
            string? id = User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value;
            if (id == null)
                return RedirectToAction("Index", "Home");
            User? user = _mainRepository.UserRepository.GetUserDetail(id);
            if (user == null)
                return RedirectToAction("Index", "Home");
            var editUserViewModel = _mapper.Map<EditUserViewModel>(user);
            return View(editUserViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(EditUserViewModel editUserViewModel)
        {
            User user = _mapper.Map<User>(editUserViewModel);
            user.CookieId = User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value;
            if (user.CookieId == null)
                return RedirectToAction("Index", "Home");
            bool err = _mainRepository.UserRepository.EditUser(user);
            if (err)
            {
                TempData["Status"] = "Không thể cập nhật thông tin, vui lòng kiểm tra lại";
                return View(editUserViewModel);
            }
            else
            {
                TempData["Status"] = "Cập nhật thông tin thành công";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
