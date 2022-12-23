using System.ComponentModel.DataAnnotations;

namespace VietTour.Areas.Public.Models
{
    public class SignUpViewModel
    {
        [Required]
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
