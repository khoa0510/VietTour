using System.ComponentModel.DataAnnotations;

namespace VietTour.Areas.Public.Models
{
    public class LogInViewModel
    {
        [Required]
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
