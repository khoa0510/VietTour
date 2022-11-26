namespace VietTour.Models.ViewModels
{
    public class CreateTourViewModel
    {
        // tạo lập tour

        public string? TourName { get; set; }

        public string? Summary { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int ProvinceId { get; set; }
    }
}
