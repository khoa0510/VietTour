namespace VietTour.Models.ViewModels
{
    public class TourComponent
    {
        public int tourId { get; set; }
        // Ảnh của tour
        public string? imagesUrl { get; set; }

        // Title của tour

        public string? TourName { get; set; }

        // tóm tắt tour
        public string? Summary { get; set; }

        // mô tả tour
        // nếu có tóm tắt thì ko có mô tải tour vì mô tả trong detail
        //public string Description { get; set; }

        // giá tour
        public decimal Price { get; set; }
    }
}
