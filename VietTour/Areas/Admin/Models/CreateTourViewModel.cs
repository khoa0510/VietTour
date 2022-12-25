using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [FromForm]
        [NotMapped]
        public IFormFile PictureFile { get; set; }
    }
}
