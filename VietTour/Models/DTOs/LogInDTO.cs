using System.ComponentModel.DataAnnotations;

namespace VietTour.Models.DTOs
{
    public class LogInDTO
    {
        //[Display (Name = "Email hoặc số điện thoại")]
        [Required(ErrorMessage ="Bạn phải nhập tài khoản")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Yêu cầu mật khẩu")]
        public string Password { get; set; }
    }
}
