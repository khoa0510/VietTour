namespace VietTour.Areas.Shared.Models
{
    public class TourComponent
    {
        public int TourId { get; set; }
        // Ảnh của tour
        public string Image { get; set; }

        // Title của tour

        public string? TourName { get; set; }

        // tóm tắt tour
        public string? Summary { get; set; }

        // giá tour
        public decimal Price { get; set; }
    }
}
