using System.ComponentModel.DataAnnotations;

namespace VietTour.Areas.Admin.Models
{
    public class CreateTourViewModel
    {
        // tạo lập tour
        [Required]
        public string? TourName { get; set; }

        [Required]
        public string? Summary { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string? ProvinceName { get; set; }
    }
}
