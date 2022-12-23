using System.ComponentModel.DataAnnotations;

namespace VietTour.Areas.Public.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string? Password { get; set; }
    }
}
