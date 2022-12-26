using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace VietTour.Areas.Admin.Models
{
    public class EditTourViewModel
    {
        public int TourId { get; set; }

        public string? TourName { get; set; }

        public string? Summary { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string ProvinceName { get; set; }

        public string Picture { get; set; }

        [FromForm]
        [NotMapped]
        public IFormFile PictureFile { get; set; }
    }
}
