using Microsoft.AspNetCore.Mvc;

namespace TOUR.Controllers
{
    public class LoginController : Controller
    {
        /*Hiển thị trang Login khi bấm vào button Đăng nhập*/
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
